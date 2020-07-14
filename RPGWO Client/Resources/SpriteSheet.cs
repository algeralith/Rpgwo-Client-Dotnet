using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGWO_Client.Resources
{
    public class SpriteSheet
    {
        private string _spritePath = "";

        // All sprite sheets are 320x320 px
        private int _width = 320;
        private int _height = 320;

        private Bitmap _spriteSheet;

        public SpriteSheet(string spritePath)
        {
            _spritePath = spritePath;
        }

        ~SpriteSheet()
        {
            // Ensure that sprite sheet is disposed of.
            if (_spriteSheet != null)
            {
                _spriteSheet.Dispose();
                _spriteSheet = null;
            }
        }

        public void Load()
        {
            if (_spriteSheet != null)
                return; // Sprite sheet is already loaded.

            try
            {
                _spriteSheet = new Bitmap(_spritePath);

                _width = _spriteSheet.Width;
                _height = _spriteSheet.Height;
            } 
            catch (FileNotFoundException ex)
            {
                // TODO :: Handle this exception. Though it should never occur.
                Console.WriteLine(ex);
            }
        }

        // Indexes are between 0-99
        public Bitmap SubImage(int index, ImageType spriteSize = ImageType.OnebyOne)
        {
            if (_spriteSheet == null)
                Load();

            // Calculate the point
            int x = (index % 10) * 32; // 10 being SpriteSheetWidth / SpriteWidth -> 320 / 32
            int y = (index / 10) * 32;

            // Create image to copy on to
            int newSpriteWidth = 0;
            int newSpriteHeight = 0;

            switch (spriteSize)
            {
                case ImageType.OnebyOne:
                    newSpriteWidth = 32;
                    newSpriteHeight = 32;
                    break;
                case ImageType.OneByTwo:
                    newSpriteWidth = 32;
                    newSpriteHeight = 64;
                    break;
                case ImageType.TwoByTwo:
                    newSpriteWidth = 64;
                    newSpriteHeight = 64;
                    break;
            }

            // Verify that the bounds does not exceed 
            // Out of Memory exception is thrown when size of rectangle exceeds bitmap bounds
            // Though, this should never occur
            if (x + newSpriteWidth > _spriteSheet.Width)
                newSpriteWidth = _spriteSheet.Width - x;

            if (y + newSpriteHeight > _spriteSheet.Height)
                newSpriteHeight = _spriteSheet.Height - y;

            Rectangle rectangle = new Rectangle(x, y, newSpriteWidth, newSpriteHeight);

            // Copy section into temporary bmp.
            Bitmap bitmap = _spriteSheet.Clone(rectangle, _spriteSheet.PixelFormat);

            return bitmap;
        }
    }
}
