using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGWO_Client.Networking;
using RPGWO_Client.Networking.Packets;

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
        }

        public Int16 GetTile(int x, int y)
        {
            return _mapData[17 * x + y];
        }

        private void Handler_OnMosterLocatiion(object sender, MonsterLocation e)
        {
            //throw new NotImplementedException();
        }

        private void Handler_OnPlayerLocation(object sender, PlayerLocation e)
        {
            //throw new NotImplementedException();
        }

        private void Handler_OnMapData(object sender, MapData e)
        {
            _xPos = e.Xpos;
            _yPos = e.Ypos;
            _zPos = e.Zpos;

            Array.Copy(e.Tiles, _mapData, e.Tiles.Length);
            WorldRenderer.RenderFrame();
        }
    }
}
