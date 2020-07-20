using RPGWO_Client.Networking.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGWO_Client
{
    public class ItemMap
    {
        // In this case, I'll use a nested dictionary structure
        Dictionary<int, Dictionary<int, Dictionary<int, ItemLocation>>> _itemMap = new Dictionary<int, Dictionary<int, Dictionary<int, ItemLocation>>>();

        // Lookup table for all items
        Dictionary<int, ItemLocation> _itemLookup = new Dictionary<int, ItemLocation>();

        private int _width = 0;
        private int _height = 0;
        private int _depth = 0;

        public ItemMap(int width, int height, int depth)
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
                _itemMap.Add(x, new Dictionary<int, Dictionary<int, ItemLocation>>());

                for (int y = 0; y < _height; y++)
                {
                    _itemMap[x].Add(y, new Dictionary<int, ItemLocation>(20)); // Only going to use it to store 20 items
                }
            }
        }

        public void Clear()
        {
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    _itemMap[x][y].Clear();
                }
            }
        }

        public void AddModifyItem(ItemLocation itemLocation)
        {
            ItemLocation tmpLocation;

            // Check if the item is already within the map
            _itemLookup.TryGetValue(itemLocation.Index, out tmpLocation);

            // Item previously exists, remove their old entries
            if (tmpLocation != null)
            {
                _itemMap[tmpLocation.Xpos][tmpLocation.Ypos].Remove(tmpLocation.Index);
                _itemLookup.Remove(tmpLocation.Index);
            }

            // Add new item entries
            _itemMap[itemLocation.Xpos][itemLocation.Ypos].Add(itemLocation.Index, itemLocation);
            _itemLookup.Add(itemLocation.Index, itemLocation);
        }

        public void RemoveItem(ItemLocation itemLocation)
        {
            ItemLocation tmpLocation;

            _itemLookup.TryGetValue(itemLocation.Index, out tmpLocation);

            // Check to see if item even exists, if not, return
            if (tmpLocation == null)
            {
                return;
            }

            // Remove entries
            _itemMap[tmpLocation.Xpos][tmpLocation.Ypos].Remove(tmpLocation.Index);
            _itemLookup.Remove(tmpLocation.Index);
        }

        public ItemLocation[] GetItems(int x, int y)
        {
            return _itemMap[x][y].Values.ToArray();
        }
    }
}
