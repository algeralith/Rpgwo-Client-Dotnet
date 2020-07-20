using RPGWO_Client.Resources.Items;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGWO_Client.Resources
{
    // To make things easier and more accessible, this class will be designed to hold all our loaded resources.
    public class ResourceManager
    {
        private string _resourceDirectory;

        public SpriteManager SpriteManager { get; private set; }

        public ItemDef[] ItemDefinitions { get; private set; }

        public ItemUse[] ItemUsages { get; private set; }

        public ResourceManager(string resourceDirectory)
        {
            _resourceDirectory = resourceDirectory;

            SpriteManager = new SpriteManager(_resourceDirectory);

            Load();
        }

        private void Load()
        {
            SpriteManager.Load();

            ItemDefinitions = ItemDef.ReadItems();
        }

        public Bitmap GetItemSprite(int itemId)
        {
            ItemDef item = ItemDefinitions[itemId];

            if (item == null)
                return null;

            return SpriteManager.GetSprite(SpriteType.Items, item.Animation[0], item.ImageType);
        }
    }
}
