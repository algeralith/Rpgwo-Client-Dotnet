using RPGWO_Client.Resources;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGWO_Client
{
    public class WorldRenderer
    {
        public World World { get; private set; }
        public SpriteManager SpriteManager { get; set; }

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
                // Render background
                for (int x = 0; x < _width; x++)
                {
                    for (int y = 0; y < _height; y++)
                    {
                        int tile = World.GetTile(x, y);
                        Bitmap tileImage = SpriteManager.GetBackground(tile);
                        graphics.DrawImage(tileImage, new Rectangle(x * 32, y * 32, 32, 32), new Rectangle(0, 0, 32, 32), GraphicsUnit.Pixel);

                        // Dispose of tile Image //TODO :: Remove this once caching is in place
                        tileImage.Dispose();
                    }
                }
            }
        }
    }
}
