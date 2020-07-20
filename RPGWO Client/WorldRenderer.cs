using RPGWO_Client.Networking.Packets;
using RPGWO_Client.Resources;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPGWO_Client
{
    public class WorldRenderer
    {
        public World World { get; private set; }
        public ResourceManager ResourceManager { get; set; }

        private int _width = 19; // Should be constant
        private int _height = 17; // Should be constant.

        // Internal Image Size
        private int _internalwidth = 19 * 32;
        private int _internalheight = 17 * 32;

        public WorldRenderer(World world)
        {
            this.World = world;
        }

        public void RenderFrame()
        {
            Bitmap newFrame = new Bitmap(_internalwidth, _internalheight);

            using (Graphics graphics = Graphics.FromImage(newFrame))
            {
                for (int x = 0; x < _width; x++)
                {
                    for (int y = 0; y < _height; y++)
                    {
                        // Render background
                        int tile = World.GetTile(x, y);
                        Bitmap tileImage = ResourceManager.SpriteManager.GetSprite(SpriteType.Background, tile);
                        graphics.DrawImage(tileImage, new Rectangle(x * 32, y * 32, 32, 32), new Rectangle(0, 0, 32, 32), GraphicsUnit.Pixel);

                        // Dispose of tile Image //TODO :: Remove this once caching is in place
                        tileImage.Dispose();

                    }
                }

                // TODO :: No need to do this double loop. In the future, can just iterate over the item map. 
                for (int x = 0; x < _width; x++)
                {
                    for (int y = 0; y < _height; y++)
                    {
                        // Render Items
                        ItemLocation[] items = World.ItemMap.GetItems(x, y);

                        foreach (ItemLocation item in items)
                        {
                            Bitmap itemImage = ResourceManager.GetItemSprite(item.ItemID);
                            itemImage.MakeTransparent();

                            Rectangle destRect = new Rectangle(x * 32 - ((itemImage.Width / 32 - 1) * 32), (y * 32) - ((itemImage.Height / 32 - 1) * 32), itemImage.Width, itemImage.Height);

                            graphics.DrawImage(itemImage, destRect, new Rectangle(0, 0, itemImage.Width, itemImage.Height), GraphicsUnit.Pixel);

                            itemImage.Dispose();
                        }

                        // Render Players
                        PlayerLocation player = World.PlayerMap[x, y];

                        if (player != null)
                        {
                            // Paperdoll image, need to draw each individual component.
                            if (player.Image == 0)
                            {
                                Bitmap playerPart = ResourceManager.SpriteManager.GetSprite(SpriteType.Head, player.Head);
                                graphics.DrawImage(playerPart, new Rectangle(x * 32, y * 32, 32, 32), new Rectangle(0, 0, playerPart.Width, playerPart.Height), GraphicsUnit.Pixel);
                                playerPart.Dispose();

                                playerPart = ResourceManager.SpriteManager.GetSprite(SpriteType.Chest, player.Chest);
                                graphics.DrawImage(playerPart, new Rectangle(x * 32, y * 32, 32, 32), new Rectangle(0, 0, playerPart.Width, playerPart.Height), GraphicsUnit.Pixel);
                                playerPart.Dispose();

                                playerPart = ResourceManager.SpriteManager.GetSprite(SpriteType.Arms, player.Arms);
                                graphics.DrawImage(playerPart, new Rectangle(x * 32, y * 32, 32, 32), new Rectangle(0, 0, playerPart.Width, playerPart.Height), GraphicsUnit.Pixel);
                                playerPart.Dispose();

                                playerPart = ResourceManager.SpriteManager.GetSprite(SpriteType.Legs, player.Legs);
                                graphics.DrawImage(playerPart, new Rectangle(x * 32, y * 32, 32, 32), new Rectangle(0, 0, playerPart.Width, playerPart.Height), GraphicsUnit.Pixel);
                                playerPart.Dispose();

                                if (player.Shield != 0)
                                {
                                    playerPart = ResourceManager.SpriteManager.GetSprite(SpriteType.Shields, player.Shield);
                                    graphics.DrawImage(playerPart, new Rectangle(x * 32, y * 32, 32, 32), new Rectangle(0, 0, playerPart.Width, playerPart.Height), GraphicsUnit.Pixel);
                                    playerPart.Dispose();
                                }

                                if (player.Weapon != 0)
                                {
                                    playerPart = ResourceManager.SpriteManager.GetSprite(SpriteType.Weapons, player.Weapon);
                                    graphics.DrawImage(playerPart, new Rectangle(x * 32, y * 32, 32, 32), new Rectangle(0, 0, playerPart.Width, playerPart.Height), GraphicsUnit.Pixel);
                                    playerPart.Dispose();
                                }
                            }
                            else
                            {

                            }
                        }

                        // Render Light
                    }
                }


            }

            frmClient.Client.UpdateImage(newFrame);
            // newFrame.Save("1.bmp");
        }
    }
}
