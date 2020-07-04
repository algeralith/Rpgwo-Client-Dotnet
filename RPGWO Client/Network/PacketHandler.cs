﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGWO_Client.Network.Packets;

namespace RPGWO_Client.Network
{
    public class PacketHandler
    {
        public Network Network { get; private set; }

        // Events
        public event EventHandler LoginSuccess; // Successful Login.
        public event EventHandler LoginFailure; // Unsucessful Login.
        public event EventHandler<PacketEventArgs> OnPlayerList; // Player list is received.
        public event EventHandler OnText; // Whenever a Text Packet is received.
        public event EventHandler<PacketEventArgs> OnClientList;

        public PacketHandler(Network network)
        {
            Network = network;
        }

        public void HandlePacket(Packet packet)
        {
            switch((PacketTypes)packet.PacketID)
            {
                case PacketTypes.Nack:
                    HandleNack();
                    break;
                case PacketTypes.PlayerList:
                    HandlePlayerList((PlayerList)packet);
                    break;
                case PacketTypes.Text:
                    HandleText((Text)packet);
                    break;
                case PacketTypes.ClientList:
                    HandleClientList((ClientList)packet);
                    break;
                case PacketTypes.Ack:
                    HandleAck();
                    break;
                default:
                    break;
            }
        }

        private void HandleAck()
        {
            if (Network.NetworkState == NetworkState.LoginSent)
            {
                // Login was Successful. Update state to show we are currently at the main menu.
                Network.NetworkState = NetworkState.MainMenu;

                LoginSuccess?.BeginInvoke(this, EventArgs.Empty, null, null);
            }
        }

        private void HandleNack()
        {
            if (Network.NetworkState == NetworkState.LoginSent)
            {
                // Login was Unsuccessful. Revert Network State.
                // Network.NetworkState = NetworkState.LoginScreen;
            }
        }

        private void HandlePlayerList(PlayerList playerList)
        {
            PacketEventArgs packetEvent = new PacketEventArgs(playerList);

            OnPlayerList?.BeginInvoke(this, packetEvent, null, null);
        }

        private void HandleText(Text text)
        {
            OnText?.BeginInvoke(this, EventArgs.Empty, null, null);
        }

        private void HandleClientList(ClientList clientList)
        {
            PacketEventArgs packetEvent = new PacketEventArgs(clientList);

            OnClientList?.BeginInvoke(this, packetEvent, null, null);
        }
    }
}
