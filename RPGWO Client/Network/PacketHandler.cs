using System;
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
        public EventHandler LoginSuccess; // Successful Login.
        public EventHandler LoginFailure; // Unsucessful Login.
        public EventHandler OnText; // Whenever a Text Packet is received.

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
                case PacketTypes.Text:
                    HandleText((Text)packet);
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
                // Login was Successful.
            }
        }

        private void HandleNack()
        {
            if (Network.NetworkState == NetworkState.LoginSent)
            {
                // Login was Unsuccessful.
            }
        }

        private void HandleText(Text text)
        {
            OnText?.BeginInvoke(this, EventArgs.Empty, null, null);
        }
    }
}
