using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RPGWO_Client.Resources
{
    // The goal of this class will be to handle the loading and caching of sprites.
    // Should support lazy and full loading.
    public class SpriteManager
    {
        private string _resourcePath = "";

        // Background Sprites
        private Dictionary<int, SpriteSheet> _animationSheets;
        private Dictionary<int, SpriteSheet> _backgrondSheets;
        private Dictionary<int, SpriteSheet> _chestSheets;
        private Dictionary<int, SpriteSheet> _headSheets;
        private Dictionary<int, SpriteSheet> _armSheets;
        private Dictionary<int, SpriteSheet> _legSheets;
        private Dictionary<int, SpriteSheet> _shieldSheets;
        private Dictionary<int, SpriteSheet> _weaponsSheets;
        private Dictionary<int, SpriteSheet> _itemSheets;
        private Dictionary<int, SpriteSheet> _playerSheets;

        // Light
        private SpriteSheet _lightingSheet;

        public SpriteManager(String resourcePath)
        {
            _resourcePath = resourcePath;

            // Initialize dictionarys.
            _animationSheets = new Dictionary<int, SpriteSheet>();
            _backgrondSheets = new Dictionary<int, SpriteSheet>();
            _chestSheets = new Dictionary<int, SpriteSheet>();
            _headSheets = new Dictionary<int, SpriteSheet>();
            _armSheets = new Dictionary<int, SpriteSheet>();
            _legSheets = new Dictionary<int, SpriteSheet>();
            _shieldSheets = new Dictionary<int, SpriteSheet>();
            _weaponsSheets = new Dictionary<int, SpriteSheet>();
            _itemSheets = new Dictionary<int, SpriteSheet>();
            _playerSheets = new Dictionary<int, SpriteSheet>();
        }

        // TODO :: Caching
        public Bitmap GetSprite(SpriteType type, int spriteId, ImageType imageType = ImageType.OnebyOne)
        {
            // Calculate what sheet the sprite is on
            int sheetNumber = spriteId / 100; //100 images per sheet.
            int spriteNumber = spriteId % 100;

            Dictionary<int, SpriteSheet> spriteSheet = _itemSheets; // Let _items be default for now

            switch (type)
            {
                case SpriteType.Animation:
                    spriteSheet = _animationSheets;
                    break;
                case SpriteType.Arms:
                    spriteSheet = _armSheets;
                    break;
                case SpriteType.Background:
                    spriteSheet = _backgrondSheets;
                    break;
                case SpriteType.Chest:
                    spriteSheet = _chestSheets;
                    break;
                case SpriteType.Head:
                    spriteSheet = _headSheets;
                    break;
                case SpriteType.Items:
                    spriteSheet = _itemSheets;
                    break;
                case SpriteType.Legs:
                    spriteSheet = _legSheets;
                    break;
                case SpriteType.Players:
                    spriteSheet = _playerSheets;
                    break;
                case SpriteType.Shields:
                    spriteSheet = _shieldSheets;
                    break;
                case SpriteType.Weapons:
                    spriteSheet = _weaponsSheets;
                    break;
                case SpriteType.Light:
                    return _lightingSheet.SubImage(spriteId);
            }

            return spriteSheet[sheetNumber].SubImage(spriteNumber, imageType);
        }

        public void Load()
        {
            try
            {
                // Grab a list of all resources
                string[] files = Directory.GetFiles(_resourcePath); // Using hex_reborn as test files TODO ::

                // List all background files
                string[] animations = files.Where(path => new Regex(@"^[aA-zZ.]*animation\d*.bmp$", RegexOptions.IgnoreCase).IsMatch(path)).ToArray();
                string[] backgrounds = files.Where(path => new Regex(@"^[aA-zZ.]*background\d*.bmp$", RegexOptions.IgnoreCase).IsMatch(path)).ToArray();
                string[] chests = files.Where(path => new Regex(@"^[aA-zZ.]*chest\d*.bmp$", RegexOptions.IgnoreCase).IsMatch(path)).ToArray();
                string[] heads = files.Where(path => new Regex(@"^[aA-zZ.]*head\d*.bmp$", RegexOptions.IgnoreCase).IsMatch(path)).ToArray();
                string[] arms = files.Where(path => new Regex(@"^[aA-zZ.]*arms\d*.bmp$", RegexOptions.IgnoreCase).IsMatch(path)).ToArray();
                string[] legs = files.Where(path => new Regex(@"^[aA-zZ.]*legs\d*.bmp$", RegexOptions.IgnoreCase).IsMatch(path)).ToArray();
                string[] shields = files.Where(path => new Regex(@"^[aA-zZ.]*shield\d*.bmp$", RegexOptions.IgnoreCase).IsMatch(path)).ToArray();
                string[] weapons = files.Where(path => new Regex(@"^[aA-zZ.]*weapon\d*.bmp$", RegexOptions.IgnoreCase).IsMatch(path)).ToArray();
                string[] items = files.Where(path => new Regex(@"^[aA-zZ.]*item\d*.bmp$", RegexOptions.IgnoreCase).IsMatch(path)).ToArray();
                string[] players = files.Where(path => new Regex(@"^[aA-zZ.]*player\d*.bmp$", RegexOptions.IgnoreCase).IsMatch(path)).ToArray();

                InitializeSheets(animations, _animationSheets);
                InitializeSheets(backgrounds, _backgrondSheets);
                InitializeSheets(chests, _chestSheets);
                InitializeSheets(heads, _headSheets);
                InitializeSheets(arms, _armSheets);
                InitializeSheets(legs, _legSheets);
                InitializeSheets(shields, _shieldSheets);
                InitializeSheets(weapons, _weaponsSheets);
                InitializeSheets(items, _itemSheets);
                InitializeSheets(players, _playerSheets);

                // Lighting file
                _lightingSheet = new SpriteSheet("Light.bmp");

            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("Ex"); // TODO :: Handle error properly.
            }
        }

        private void InitializeSheets(string[] filePaths, Dictionary<int, SpriteSheet> _sheets)
        {
            foreach (string file in filePaths)
            {
                // Try to extract the sprite sheet number
                Match match = Regex.Match(file, @"\d+");

                if (!match.Success)
                    continue; // Unsucessful match. TODO :: Error handling.

                int sheetNumber = Convert.ToInt32(match.Value);

                SpriteSheet spriteSheet;

                // Ensure the sheet has not been previous loaded.
                _sheets.TryGetValue(sheetNumber, out spriteSheet);

                if (spriteSheet != null)
                    continue; // Sprite sheet seems to already be loaded. Ignore.

                spriteSheet = new SpriteSheet(file);

                // Add sheet to dictionary.
                _sheets.Add(sheetNumber, spriteSheet);
            }
        }
    }
}
