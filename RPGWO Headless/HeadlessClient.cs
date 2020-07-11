using System;
using System.Collections.Generic;
using System.Text;
using RPGWO_Client.Network;
using RPGWO_Client.Network.Packets;

namespace RPGWO_Headless
{
    public class HeadlessClient
    {
        public Network Network { get; private set; } // Refactor out into more generic "Server" class in the future
        private string userName = "";
        private string password = "";

        private PlayerList Players { get; set; }

        public HeadlessClient(String ipAddress, int port)
        {
            // Set up networking
            this.Network = new Network(ipAddress, port);

            InitializeEvents();
        }
        public void Start()
        {
            // Try to connect to the rpgwo server
            Network.Connect();

            while(true)
            {

            }
        }

        private void InitializeEvents()
        {
            // Network Events
            Network.OnConnect += Network_OnConnect;
            Network.OnDisconnect += Network_OnDisconnect;

            // Client Events
            Network.Handler.OnPlayerList += Handler_OnPlayerList;
        }

        private void Handler_OnPlayerList(object sender, PlayerList e)
        {
            Players = e;

            // Login
            Enter enter = new Enter();
            enter.Name = Players.PlayerNames[0];

            // Set Network state to entering -- TODO :: 
            Network.NetworkState = NetworkState.EnterStart;
            Network.Send(enter);
        }

        // Unsuccessful connect / Disconnected
        private void Network_OnDisconnect(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        // Successful connection to server
        private void Network_OnConnect(object sender, EventArgs e)
        {
            Console.WriteLine("Connected.");
            Network.SendInfo2();
            Network.SendLogin(userName, password);
            Network.SendPlayerListReq();
        }
    }
}
