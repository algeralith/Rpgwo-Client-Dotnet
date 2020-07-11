using System;
using System.Collections.Generic;
using System.Text;
using RPGWO_Client.Network;
using RPGWO_Client.Network.Packets;
using Discord;
using Discord.API;
using Discord.Commands;
using Discord.Net;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace RPGWO_Headless
{
    public class HeadlessClient
    {
        public Network Network { get; private set; } // Refactor out into more generic "Server" class in the future
        public DiscordSocketClient discord;

        private string userName = "";
        private string password = "";

        private PlayerList Players { get; set; }

        public HeadlessClient(String ipAddress, int port)
        {
            // Set up networking
            this.Network = new Network(ipAddress, port);
            // discord = new DiscordSocketClient();

            InitializeRpgwoEvents();
            // InitializeDiscordEvents();
        }
        private void InitializeRpgwoEvents()
        {
            // Network Events
            Network.OnConnect += Network_OnConnect;
            Network.OnDisconnect += Network_OnDisconnect;

            // Client Events
            Network.Handler.OnPlayerList += Handler_OnPlayerList;
            Network.Handler.OnGameEnter += Handler_OnGameEnter;
            Network.Handler.OnText += Handler_OnText;
        }

        public void InitializeDiscordEvents()
        {
            discord.Log += Discord_Log;
            discord.MessageReceived += Discord_MessageReceived;
        }

        public async Task Start()
        {
            // Try to connect to the rpgwo server
            Network.Connect();

            // await discord.LoginAsync(TokenType.Bot, "");
            // await discord.StartAsync();

            await Task.Delay(-1);
        }

        //
        // Discord Events
        //
        private Task Discord_MessageReceived(SocketMessage arg)
        {
            return Task.Run(() => { });
        }

        private Task Discord_Log(LogMessage arg)
        {
            return Task.Run(() => {
                Console.WriteLine(arg);
            });
        }

        //
        // Rpgwo Events
        //
        private void Handler_OnText(object sender, Text e)
        {
            Console.WriteLine("Channel: " + e.Channel);
            Console.WriteLine(e.TextContent);
        }

        private void Handler_OnGameEnter(object sender, bool e)
        {
            if (e)
            {
                // Send CPU info
                Network.SendText("@cpu DiscordBot", 105);

                // Send Final Enter
                Network.SendEnterFinal();
            }
            else
            {
                // TODO :: Failed to enter game.
            }
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
