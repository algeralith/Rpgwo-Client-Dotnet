using RPGWO_Client.Networking.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGWO_Client
{
    public class PlayerMap
    {
        Dictionary<int, Dictionary<int, Dictionary<int, PlayerLocation>>> _playerMap = new Dictionary<int, Dictionary<int, Dictionary<int, PlayerLocation>>>();

        // Lookup table for all players
        Dictionary<int, PlayerLocation> _playerLookup = new Dictionary<int, PlayerLocation>();

        private int _width = 0;
        private int _height = 0;
        private int _depth = 0;

        public PlayerMap(int width, int height, int depth)
        {
            _width = width;
            _height = height;
            _depth = depth;

            Initialize();
        }

        private void Initialize()
        {
            for (int x = 0; x < _width; x++)
            {
                _playerMap.Add(x, new Dictionary<int, Dictionary<int, PlayerLocation>>());

                for (int y = 0; y < _height; y++)
                {
                    _playerMap[x].Add(y, new Dictionary<int, PlayerLocation>(1)); // Only going to use it to store 1 player
                }
            }
        }

        public void Clear()
        {
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    _playerMap[x][y].Clear();
                }
            }
        }

        public void AddModifyPlayer(PlayerLocation playerLocation)
        {
            PlayerLocation tmpLocation;

            // Check if the player is already within the map
            _playerLookup.TryGetValue(playerLocation.Index, out tmpLocation);

            // player previously exists, remove their old entries
            if (tmpLocation != null)
            {
                _playerMap[tmpLocation.Xpos][tmpLocation.Ypos].Remove(tmpLocation.Index);
                _playerLookup.Remove(tmpLocation.Index);
            }

            // Add new item entries
            _playerMap[playerLocation.Xpos][playerLocation.Ypos].Add(playerLocation.Index, playerLocation);
            _playerLookup.Add(playerLocation.Index, playerLocation);
        }

        public void RemovePlayer(PlayerLocation playerLocation)
        {
            PlayerLocation tmpLocation;

            _playerLookup.TryGetValue(playerLocation.Index, out tmpLocation);

            // Check to see if player even exists, if not, return
            if (tmpLocation == null)
            {
                return;
            }

            // Remove entries
            _playerMap[tmpLocation.Xpos][tmpLocation.Ypos].Remove(tmpLocation.Index);
            _playerLookup.Remove(tmpLocation.Index);
        }

        public PlayerLocation GetPlayer(int x, int y)
        {
            var tmp = _playerMap[x][y].Values.ToArray();

            if (tmp.Length == 0)
            {
                return null;
            }

            return tmp[0];
        }

        public PlayerLocation[] GetPlayers(int x, int y)
        {
            return _playerMap[x][y].Values.ToArray();
        }
    }
}
