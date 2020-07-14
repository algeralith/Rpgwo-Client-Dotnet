using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGWO_Client.Networking.Packets;

namespace RPGWO_Client.Networking
{
    public class PacketHandler
    {
        public Network Network { get; private set; }

        // Events
        public event EventHandler LoginSuccess; // Successful Login.
        public event EventHandler LoginFailure; // Unsucessful Login.

        // Main Menu.
        public event EventHandler<PlayerList> OnPlayerList; // Player list is received.
        public event EventHandler<ClientList> OnClientList;

        // Player Creation.
        public event EventHandler<PacketEventArgs> OnCreateDef;
        public event EventHandler<bool> OnPlayerCreate;
        public event EventHandler<bool> OnPlayerDelete;

        // Enter Game and Enter Final
        public event EventHandler<bool> OnGameEnter;
        public event EventHandler<bool> OnGameEnterFinal;

        // General.
        public event EventHandler<PacketEventArgs> OnSkillDef;
        public event EventHandler<Text> OnText;
        public event EventHandler<Attributes> OnAttributes;
        public event EventHandler<PlayerStats> OnPlayerStats;
        public event EventHandler<PlayerStats2> OnPlayerStats2;
        public event EventHandler<WorldState> OnWorldState;
        public event EventHandler<Skill> OnSkill;

        // Map related.
        public event EventHandler<MapData> OnMapData;
        public event EventHandler<PlayerLocation> OnPlayerLocation;
        public event EventHandler<MonsterLocation> OnMosterLocatiion;

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
                case PacketTypes.MapData:
                    Task.Run(() => OnMapData?.Invoke(this, (MapData)packet));
                    break;
                case PacketTypes.PlayerLocation:
                    Task.Run(() => OnPlayerLocation?.Invoke(this, (PlayerLocation)packet));
                    break;
                case PacketTypes.WorldState:
                    Task.Run(() => OnWorldState?.Invoke(this, (WorldState)packet));
                    break;
                case PacketTypes.PlayerStats:
                    Task.Run(() => OnPlayerStats?.Invoke(this, (PlayerStats)packet));
                    break;
                case PacketTypes.ClientList:
                    HandleClientList((ClientList)packet);
                    break;
                case PacketTypes.Skill:
                    Task.Run(() => OnSkill?.Invoke(this, (Skill)packet));
                    break;
                case PacketTypes.Attributes:
                    Task.Run(() => OnAttributes?.Invoke(this, (Attributes)packet));
                    break;
                case PacketTypes.Text:
                    HandleText((Text)packet);
                    break;
                case PacketTypes.PlayerStats2:
                    Task.Run(() => OnPlayerStats2?.Invoke(this, (PlayerStats2)packet));
                    break;
                case PacketTypes.CreateDef:
                    HandleCreateDef((CreateDef)packet);
                    break;
                case PacketTypes.SkillDef:
                    HandleSkillDef((SkillDef)packet);
                    break;
                case PacketTypes.MonsterLocation:
                    Task.Run(() => OnMosterLocatiion?.Invoke(this, (MonsterLocation)packet));
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

                Task.Run(() => LoginSuccess?.Invoke(this, EventArgs.Empty));
            }

            if (Network.NetworkState == NetworkState.PlayerDelete)
            {
                Task.Run(() => OnPlayerDelete?.Invoke(this, true));
            }

            if (Network.NetworkState == NetworkState.PlayerCreation)
            {
                Task.Run(() => OnPlayerCreate?.Invoke(this, true));
            }

            if (Network.NetworkState == NetworkState.EnterStart)
            {
                Task.Run(() => OnGameEnter?.Invoke(this, true));
            }

            if (Network.NetworkState == NetworkState.EnterFinal)
            {
                Task.Run(() => OnGameEnterFinal?.Invoke(this, true));
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
                Task.Run(() => OnPlayerDelete?.Invoke(this, true));
            }

            if (Network.NetworkState == NetworkState.PlayerCreation)
            {
                Task.Run(() => OnPlayerCreate?.Invoke(this, true));
            }

            if (Network.NetworkState == NetworkState.EnterStart)
            {
                Task.Run(() => OnGameEnter?.Invoke(this, true));
            }

            if (Network.NetworkState == NetworkState.EnterFinal)
            {
                Task.Run(() => OnGameEnterFinal?.Invoke(this, true));
            }
        }

        private void HandleCreateDef(CreateDef createDef)
        {
            PacketEventArgs packetEvent = new PacketEventArgs(createDef);

            Task.Run(() => OnCreateDef?.Invoke(this, packetEvent));
        }

        private void HandleSkillDef(SkillDef skillDef)
        {
            PacketEventArgs packetEvent = new PacketEventArgs(skillDef);

            Task.Run(() => OnSkillDef?.Invoke(this, packetEvent));
        }

        private void HandlePlayerList(PlayerList playerList)
        {
            Task.Run(() => OnPlayerList?.Invoke(this, playerList));
        }

        private void HandleText(Text text)
        {
            Task.Run(() => OnText?.Invoke(this, text));
        }

        private void HandleClientList(ClientList clientList)
        {
            Task.Run(() => OnClientList?.Invoke(this, clientList));
        }
    }
}
