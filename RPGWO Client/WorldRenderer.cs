using RPGWO_Client.Networking.Packets;
using RPGWO_Client.Resources;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
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

        // Light Map
        public byte[,] _lightMap = new byte[19, 17]; // Should be constant.

        public bool[,] _visibleMap = new bool[19, 17];

        SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1);

        public WorldRenderer(World world)
        {
            this.World = world;

            for (int x = 0; x < _lightMap.GetLength(0); x++)
            {
                for (int y = 0; y < _lightMap.GetLength(1); y++)
                {
                    _lightMap[x, y] = 7;
                }
            }
        }

        public void RenderFrame()
        {
            semaphoreSlim.Wait();

            for (int x = 0; x < _lightMap.GetLength(0); x++)
            {
                for (int y = 0; y < _lightMap.GetLength(1); y++)
                {
                    _lightMap[x, y] = 7;
                }
            }

            Bitmap newFrame = new Bitmap(_internalwidth, _internalheight);

            using (Graphics graphics = Graphics.FromImage(newFrame))
            {
                // Flush the screen white
                graphics.Clear(Color.White);

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

                            Rectangle destRect = new Rectangle(x * 32 - ((itemImage.Width / 32 - 1) * 32), (y * 32) - ((itemImage.Height / 32 - 1) * 32), itemImage.Width, itemImage.Height);

                            graphics.DrawImage(itemImage, destRect, new Rectangle(0, 0, itemImage.Width, itemImage.Height), GraphicsUnit.Pixel);

                            itemImage.Dispose();

                            // Update Light
                            AddLightSource(x, y, item.LightSource);
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

                    }
                }

                SetVisible(10, 9);

                for (int x = 0; x < _width; x++)
                {
                    for (int y = 0; y < _height; y++)
                    {
                        if (_visibleMap[x, y])
                            continue;

                        graphics.FillRectangle(Brushes.Black, x * 32, y * 32, 32, 32);
                        // graphics.FillRectangle(Brushes.Black, x * 32, y * 32, 32, 32);
                    }
                }

                for (int x = 0; x < _width; x++)
                {
                    for (int y = 0; y < _height; y++)
                    {
                        Bitmap lightMap = ResourceManager.SpriteManager.GetSprite(SpriteType.Light, _lightMap[x, y]);
                        graphics.DrawImage(lightMap, new Rectangle(x * 32, y * 32, 32, 32), new Rectangle(0, 0, lightMap.Width, lightMap.Height), GraphicsUnit.Pixel);
                        lightMap.Dispose();
                    }

                }

            }

            frmClient.Client.UpdateImage(newFrame);
            semaphoreSlim.Release();
            // newFrame.Save("1.bmp");
        }

        public void AddLightSource(int x, int y, int lightValue)
        {
            for (int i = -lightValue; i <= lightValue; i++)
            {
                for (int j = -lightValue; j <= lightValue; j++)
                {
                    int x2 = x + i;
                    int y2 = y + j;

                    if (x2 < 0 || x2 >= 19 || y2 < 0 || y2 >= 17)
                        continue;

                    int value = (int)Math.Floor(Math.Sqrt(i * i + j * j) + .2d);
                    value = lightValue - value;

                    if (value > 7) // Max light source size
                        value = 7;

                    _lightMap[x2, y2] = (byte)(Math.Max(_lightMap[x2, y2] - Math.Max(0, value), 0));
                }
            }

            Console.WriteLine();
        }

        // Sight calculations. Entirely based off the code from Mickey's dungeon fate source.
        // As far as I understand, it is just a basic implementation of raycasting.
        // TODO  :: Look into other forms of raycasting and their benefits in the future.
        private void SetVisible(int xExt, int yExt)
        {
            for (int x = 0; x < _visibleMap.GetLength(0); x++)
            {
                for (int y = 0; y < _visibleMap.GetLength(1); y++)
                {
                    _visibleMap[x, y] = false;
                }
            }

            for (int i = -xExt; i <= xExt; i++)
            {
                for (int j = -yExt; j <= yExt; j++)
                {
                    int x = 9 + i; // TODO :: This is the player's coordinate in the grid.
                    int y = 8 + j;


                    if (x < 0 || x >= 19 || y < 0 || y >= 17)
                        continue;

                    if (OpenSightLine(9, 8, x, y))
                    {
                        _visibleMap[x, y] = true;

                        if (OpenSghtLineHelper(x, y))
                        {
                            for (int k = -1; k <= 1; k++)
                            {
                                for (int l = -1; l <= 1; l++)
                                {
                                    int x2 = x + k;
                                    int y2 = y + l;

                                    if (x2 < 0 || x2 >= 19 || y2 < 0 || y2 >= 17)
                                        continue;

                                    _visibleMap[x2, y2] = true;
                                }
                            }
                        }
                    }
                }
            }
        }

        private bool OpenSightLine(int x1, int y1, int x2, int y2)
        {
            // We are standing right next to the tile, therefore we can see it
            // Return true
            if (Distance(x1, y1, x2, y2) <= 1)
                return true;

            if (x2 == 0 && y2 == 7)
                Console.WriteLine();

            int run = x1 - x2;
            int rise = y1 - y2;

            int xStart;
            int xStop;
            int yStart;
            int yStop;

            if (x1 > x2)
            {
                xStart = x2;
                xStop = x1;
            }
            else
            {
                xStart = x1;
                xStop = x2;
            }

            if (y1 > y2)
            {
                yStart = y2;
                yStop = y1;
            }
            else
            {
                yStart = y1;
                yStop = y2;
            }

            int xPos, yPos;
            double slope;

            if (run == 0)
            {
                // Vertical line
                xPos = x1;

                for (int i = yStart; i <= yStop; i++)
                {
                    if ((xPos != x1 || i != y1) && (xPos != x2 || i != y2))
                    {
                        if (!OpenSghtLineHelper(xPos, i))
                            return false;
                    }
                }

                return true;
            }

            if (rise == 0)
            {
                // Horizontal line
                yPos = y1;

                for (int i = xStart; i <= xStop; i++)
                {
                    if ((i != x1 || yPos != y1) && (i != x2 || yPos != y2))
                    {
                        if (!OpenSghtLineHelper(i, yPos))
                            return false;
                    }
                }

                return true;
            }

            if (Math.Abs(run) > Math.Abs(rise))
            {
                Console.WriteLine("3");
                // x move
                slope = (double)rise / run;

                for (int i = 0; i <= xStop - xStart; i++)
                {
                    yPos = (int)(Math.Round(slope * i));

                    if (slope > 0)
                    {
                        yPos = yPos + yStart;
                    }
                    else
                    {
                        yPos = yPos + yStart + Math.Abs(rise);
                    }

                    if ((i + xStart != x1 || yPos != y1) && (i + xStart != x2 || yPos != y2))
                    {
                        Console.WriteLine((i + xStart).ToString() + "," + yPos.ToString());
                        if (!OpenSghtLineHelper(i + xStart, yPos))
                            return false;
                    }
                }

                return true;

            }

            if (Math.Abs(rise) >= Math.Abs(run))
            {
                slope = (double)rise / run;

                for (int i = 0; i <= yStop - yStart; i++)
                {
                    xPos = (int)(Math.Round(i / slope));
                    
                    if (slope > 0)
                    {
                        xPos = xPos + xStart;
                    }
                    else
                    {
                        xPos = xPos + xStart + Math.Abs(run);
                    }

                    if ((xPos != x1 || i + yStart != y1) && (xPos != x2 || i + yStart != y2))
                    {
                        if (!OpenSghtLineHelper(xPos, i + yStart))
                            return false;
                    }
                }

                return true;
            }

            return true;
        }

        private bool OpenSghtLineHelper(int x, int y)
        {
            // Check bounds
            if (x < 0 || x >= 19 || y < 0 || y >= 17)
                return false;

            foreach (ItemLocation item in World.ItemMap.GetItems(x, y))
            {
                if (item != null)
                {
                    if (item.NoOpenSight)
                    {
                        return false;
                    }
                }
            }

            return true;
        }


        private int Distance(int x1, int y1, int x2, int y2)
        {
            int x = Math.Abs(x1 - x2);
            int y = Math.Abs(y1 - y2);

            if (x > y)
                return x;
            else
                return y;
        }
    }
}
