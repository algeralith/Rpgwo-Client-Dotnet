﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Input;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using RPGWO_Client.Network.Packets;

namespace RPGWO_Client.Network
{
    public class Network
    {
        public static Dictionary<byte, Type> Packets { get; private set; }
        public PacketHandler Handler { get; }

        private Socket _clientSock;
        private IPEndPoint _serverEndPoint;

        // Security
        private RSecurity _rSecurity;

        public NetworkState NetworkState = NetworkState.None;
        private ReceiveMode _receiveMode = ReceiveMode.Checksum; // Client starts sending checksum.
        private SendMode sendMode = SendMode.None;

        public bool Connected { get; private set; }

        // Connection Events
        public event EventHandler OnConnect;
        public event EventHandler OnDisconnect;


        // Register all Packets here. For now at least.
        static Network()
        {
            RegisterPacket((byte)PacketTypes.Nack, typeof(Nack));
            RegisterPacket((byte)PacketTypes.Version, typeof(Packets.Version));
            RegisterPacket((byte)PacketTypes.Login, typeof(Login)); // Sent Only
            RegisterPacket((byte)PacketTypes.Text, typeof(Text));
            RegisterPacket((byte)PacketTypes.RandomByte, typeof(RandomByte));
            RegisterPacket((byte)PacketTypes.ClientList, typeof(ClientList)); // TODO :: Handler
            RegisterPacket((byte)PacketTypes.Info2, typeof(Info2)); // Sent Only
            RegisterPacket((byte)PacketTypes.Ack, typeof(Ack));
        }

        public Network(String addr, int port)
        {
            try
            {
                // Parse the Address
                _serverEndPoint = new IPEndPoint(IPAddress.Parse(addr), port);

                // Create Socket
                _clientSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // Create Packet Handler
                Handler = new PacketHandler();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Connect()
        {
            try
            {
                SocketAsyncEventArgs args = new SocketAsyncEventArgs();
                args.RemoteEndPoint = _serverEndPoint;
                args.Completed += new EventHandler<SocketAsyncEventArgs>(OnConnectionComplete);

                _clientSock.ConnectAsync(args);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void OnConnectionComplete(object sender, SocketAsyncEventArgs e)
        {
            try
            {
                Console.WriteLine(e.SocketError);
                // Start receiving
                Receive();

                // Send Version
                Send(new Packets.Version(), SendMode.None);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Receive()
        {
            if (_clientSock == null || _clientSock.Connected == false)
            {
                // Socket has been D/C'd, handle disconnect
                return;
            }

            try
            {
                SocketAsyncEventArgs args = new SocketAsyncEventArgs();
                byte[] packetID = new byte[1];

                args.SetBuffer(packetID, 0, 1); // Set args to return with only with the header of the next packet.
                args.Completed += new EventHandler<SocketAsyncEventArgs>(OnHeaderComplete);

                _clientSock.ReceiveAsync(args);
            }
            catch (Exception ex)
            {
                // Something went wrong, D/C and handle
            }
        }

        private void OnHeaderComplete(object sender, SocketAsyncEventArgs e)
        {
            if (_clientSock == null || _clientSock.Connected == false)
            {
                // Socket has been D/C'd, handle disconnect
                return;
            }

            // Check for errors
            if (e.SocketError != SocketError.Success)
            {
                // TODO :: Handle Error
                Console.WriteLine(e.SocketError);
                return;
            }

            // Grab the Packet ID
            byte packetID = e.Buffer[0];

            // Create a new Packet based on ID
            Type packetType = Packets[packetID];

            if (packetType == null)  // Unregistered Packet. Error. TODO
            {
                Console.WriteLine("Unknown packet: " + packetID);
            }

            Packet packet = (Packet)Activator.CreateInstance(packetType);

            // Check to see if the packet as more data
            if (packet.Size < e.BytesTransferred)
            {
                // We have the entire packet, Send to handler
                HandlePacket(packet);

                // Start receiving again
                Receive();
            }
            else
            {
                RpgwoSocketEventArgs args = new RpgwoSocketEventArgs();
                args.Packet = packet; // Set the packet we are receiving

                byte[] buffer = null;
                switch (_receiveMode)
                {
                    case ReceiveMode.None: // No extra data appended
                        buffer = new byte[packet.Size];
                        break;

                    case ReceiveMode.Checksum: // Extra byte for checksum
                        buffer = new byte[packet.Size + 1];
                        break;

                    case ReceiveMode.ChecksumRnd: // Extra byte for checksum and rnd
                        buffer = new byte[packet.Size + 2];
                        break;
                }

                args.SetBuffer(buffer, 0, buffer.Length);
                args.ReceiveMode = _receiveMode;
                args.Completed += new EventHandler<SocketAsyncEventArgs>(ReceivePacketData);

                _clientSock.ReceiveAsync(args);
            }
        }

        private void ReceivePacketData(object sender, SocketAsyncEventArgs e)
        {
            if (_clientSock == null || _clientSock.Connected == false)
            {
                // Socket has been D/C'd, handle disconnect
                return;
            }

            RpgwoSocketEventArgs args = (RpgwoSocketEventArgs)e;
            int received = args.BytesTransferred;

            // Check to see if we have received the entire packet
            if (received + args.TotalReceived < args.Buffer.Length)
            {
                // We still need more of the packet
                RpgwoSocketEventArgs args2 = new RpgwoSocketEventArgs();

                args2.Packet = args.Packet;
                args2.TotalReceived += received;
                args2.SetBuffer(args.Buffer, args2.TotalReceived, args.Buffer.Length - args2.TotalReceived);
                args2.Completed += new EventHandler<SocketAsyncEventArgs>(ReceivePacketData);

                _clientSock.ReceiveAsync(args2);
            }
            else
            {
                // Build up the packet before sending off to be handled
                switch (args.ReceiveMode)
                {
                    case ReceiveMode.None: // No extra data appended
                        args.Packet.AddBytes(args.Buffer);
                        break;

                    case ReceiveMode.Checksum: // Extra byte for checksum
                        args.Packet.AddBytes(args.Buffer, 0, args.Buffer.Length - 1);
                        args.Packet.CRC = args.Buffer[args.Buffer.Length - 1];
                        break;

                    case ReceiveMode.ChecksumRnd: // Extra byte for checksum and rnd
                        args.Packet.AddBytes(args.Buffer, 0, args.Buffer.Length - 2);
                        args.Packet.Rnd = args.Buffer[args.Buffer.Length - 2];
                        args.Packet.CRC = args.Buffer[args.Buffer.Length - 1];
                        break;
                }

                // TODO :: Verify.

                // Populate the packet with its data.
                bool packetCompleted = args.Packet.Receive();

                if (args.Packet.IsMultiPart) // See if any parts need receiving.
                {
                    // Check to see if all parts are received.
                    if (!packetCompleted)
                    {
                        byte[] buffer = new byte[args.Packet.Remaining() + 2]; // Assume security is inherited from parent.

                        RpgwoSocketEventArgs args2 = new RpgwoSocketEventArgs();

                        args2.Packet = args.Packet;
                        args2.ReceiveMode = args.ReceiveMode;
                        args2.SetBuffer(buffer, 0, buffer.Length);
                        args2.Completed += new EventHandler<SocketAsyncEventArgs>(ReceivePacketData);

                        _clientSock.ReceiveAsync(args2);
                        return; // TODO :: Refactor out this bit of code.
                    }
                }

                // Send packet off to be handled
                HandlePacket(args.Packet);

                // Start receiving again
                Receive();
            }
        }

        private void HandlePacket(Packet packet)
        {
            // Certain Packets need to not leave the networking class.
            // Handle these packets before dispatching to our Packet Handler.
            Console.WriteLine("Handling: " + packet.PacketID);
            switch ((PacketTypes)packet.PacketID)
            {
                case PacketTypes.Nack:
                    HandleNack();
                    break;
                case PacketTypes.Ack:
                    HandleAck();
                    break;
                case PacketTypes.RandomByte:
                    HandleRndByte((RandomByte)packet);
                    break;
                default:
                    Handler.HandlePacket(packet);
                    break;
            }
        }

        public void Send(Packet packet, SendMode sendMode)
        {
            if (_clientSock == null || _clientSock.Connected == false)
            {
                // Socket has been D/C'd, handle disconnect
                return;
            }

            try
            {
                byte[] buffer = null;

                switch (sendMode)
                {
                    case SendMode.None:
                        buffer = new byte[packet.Size + 1]; // Need to add PacketID before sending
                        break;
                    case SendMode.Checksum:
                        buffer = new byte[packet.Size + 2]; // Need to add Checksum, plus previous
                        break;
                    case SendMode.ChecksumRnd:
                        buffer = new byte[packet.Size + 3]; // Need to add RND, plus previous
                        break;
                    default:
                        Console.WriteLine("Unknown SendMode: " + sendMode);
                        break;
                }

                // Set Packet ID
                buffer[0] = packet.PacketID;

                // Copy packet contents
                packet.GetBytes().CopyTo(buffer, 1);

                SocketAsyncEventArgs args = new SocketAsyncEventArgs();
                args.Completed += new EventHandler<SocketAsyncEventArgs>(OnSendComplete);

                args.SetBuffer(buffer, 0, buffer.Length);

                _clientSock.SendAsync(args);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void OnSendComplete(object sender, SocketAsyncEventArgs e)
        {

        }

        private void HandleAck()
        {
            switch (NetworkState)
            {
                case NetworkState.None:
                    // Server has veried client version.
                    NetworkState = NetworkState.VersionVerified;

                    // Notify that connection has been established.
                    // TODO :: Async invoke.
                    OnConnect?.Invoke(this, null);
                    break;
                default:
                    Console.WriteLine("Unhandled Network State in Ack: " + NetworkState);
                    break;
            }
        }

        private void HandleNack()
        {
            switch (NetworkState)
            {
                case NetworkState.None:
                    // Server has failed to verify client version.
                    NetworkState = NetworkState.VersionVerified;
                    break;
                default:
                    Console.WriteLine("Unhandled Network State in Nack: " + NetworkState);
                    break;
            }
        }

        private void HandleRndByte(RandomByte packet)
        {
            // Set up packet security
            _rSecurity = new RSecurity(packet.randomByte, 1001); // Server expects 1001 bytes to use

            // Update Receive / Send modee
            _receiveMode = ReceiveMode.ChecksumRnd; // Tell Socket to expect packets to use both Checksum and Random.
        }

        public static void RegisterPacket(Byte packetID, Type packetType)
        {
            if (Packets == null)
            {
                Packets = new Dictionary<byte, Type>(256);
            }

            if (Packets.ContainsKey(packetID))
            {
                // Packet already registered. Error.
                Console.WriteLine("Packet ID already in use.");
                return;
            }

            Packets.Add(packetID, packetType);
        }
    }
}
