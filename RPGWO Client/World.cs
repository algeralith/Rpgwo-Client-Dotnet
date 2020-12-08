using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGWO_Client.Networking;
using RPGWO_Client.Networking.Packets;
using RPGWO_Client.Resources.Items;

namespace RPGWO_Client
{
    public class World
    {
        public Network Network { get; set; }
        public WorldRenderer WorldRenderer { get; set; }

        private Int16 _xPos = 0;
        private Int16 _yPos = 0;
        private Int16 _zPos = 0;

        private Int16[] _mapData = new Int16[19 * 17]; // TODO :: Should make these numbers a client level constant

        public ItemMap ItemMap { get; private set; }  = new ItemMap(19, 17, 20); // 20 items per tile is allowed.
        public PlayerLocation[,] PlayerMap { get; private set; } = new PlayerLocation[19, 17];

        public World(Network network)
        {
            this.Network = network;

            InitializeEvents();
        }

        private void InitializeEvents()
        {
            Network.Handler.OnMapData += Handler_OnMapData;
            Network.Handler.OnPlayerLocation += Handler_OnPlayerLocation;
            Network.Handler.OnMosterLocatiion += Handler_OnMosterLocatiion;
            Network.Handler.OnItemLocation += Handler_OnItemLocation;

            // Render Triggers
            Network.Handler.OnStartDisplay += Handler_OnStartDisplay;
            Network.Handler.OnStopDisplay += Handler_OnStopDisplay;
        }
        public Int16 GetTile(int x, int y)
        {
            return _mapData[17 * x + y];
        }

        private void Handler_OnStartDisplay(object sender, StartDisplay e)
        {
            WorldRenderer.Enabled = false;
            // TODO :: Consider, this might be a race condition issue.
            // The client will be receiving data as I'm trying to clear the maps
            // Might be best to add a semaphore or lock around here to keep things in order
            ItemMap.Clear();
            PlayerMap = new PlayerLocation[19, 17];
        }

        private void Handler_OnStopDisplay(object sender, StopDisplay e)
        {
            // WorldRenderer.RenderFrame();
            // frmClient.Client.Startdrawing(); // TODO :: Is this the best way?
            WorldRenderer.Enabled = true;
        }

        private void Handler_OnItemLocation(object sender, ItemLocation e)
        {
            Console.WriteLine(e.Spot);

            switch(e.Spot)
            {
                case ItemSpot.Map:
                    Console.WriteLine(e);
                    ItemMap.AddModifyItem(e);
                    break;

                case ItemSpot.None:
                    ItemMap.RemoveItem(e);
                    break;
            }
        }

        private void Handler_OnMosterLocatiion(object sender, MonsterLocation e)
        {
            //throw new NotImplementedException();
        }

        private void Handler_OnPlayerLocation(object sender, PlayerLocation e)
        {
            PlayerMap[e.Xpos, e.Ypos] = e; // TODO :: Somehow, I got an index out of range here. Investigate.
        }

        private void Handler_OnMapData(object sender, MapData e)
        {
            _xPos = e.Xpos;
            _yPos = e.Ypos;
            _zPos = e.Zpos;

            Array.Copy(e.Tiles, _mapData, e.Tiles.Length);
        }
    }
}
