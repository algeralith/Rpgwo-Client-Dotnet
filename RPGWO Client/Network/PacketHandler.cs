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
        public event EventHandler LoginSuccess; // Successful Login.
        public event EventHandler LoginFailure; // Unsucessful Login.
        public event EventHandler<PacketEventArgs> OnPlayerList; // Player list is received.
        public event EventHandler<PacketEventArgs> OnCreateDef;
        public event EventHandler<PacketEventArgs> OnSkillDef;
        public event EventHandler OnText; // Whenever a Text Packet is received.
        public event EventHandler<PacketEventArgs> OnClientList;
        public event EventHandler<bool> OnPlayerDelete;

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
                case PacketTypes.ClientList:
                    HandleClientList((ClientList)packet);
                    break;
                case PacketTypes.Text:
                    HandleText((Text)packet);
                    break;
                case PacketTypes.CreateDef:
                    HandleCreateDef((CreateDef)packet);
                    break;
                case PacketTypes.SkillDef:
                    HandleSkillDef((SkillDef)packet);
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

            if (Network.NetworkState == NetworkState.PlayerDelete)
            {
                OnPlayerDelete?.BeginInvoke(this, true, null, null);
            }
        }

        private void HandleNack()
        {
            if (Network.NetworkState == NetworkState.LoginSent)
            {
                // Login was Unsuccessful. Revert Network State.
                // Network.NetworkState = NetworkState.LoginScreen;
            }

            // TODO :: Consider having the handlers change the state of the network back
            if (Network.NetworkState == NetworkState.PlayerDelete)
            {
                OnPlayerDelete?.BeginInvoke(this, false, null, null);
            }
        }

        private void HandleCreateDef(CreateDef createDef)
        {
            PacketEventArgs packetEvent = new PacketEventArgs(createDef);

            OnCreateDef?.BeginInvoke(this, packetEvent, null, null);
        }

        private void HandleSkillDef(SkillDef skillDef)
        {
            PacketEventArgs packetEvent = new PacketEventArgs(skillDef);

            OnSkillDef?.BeginInvoke(this, packetEvent, null, null);
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
