using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGWO_Client.Resources;

namespace RPGWO_Client.Resources.Monsters
{
    public class MonsterDef
    {
        public bool InUse { get; set; }
        public string Name { get; set; } // 50 Characters
        public Int16 Image { get; set; }
        public ImageType ImageType { get; set; }
        public Int16 Level { get; set; }
        public bool Attackable { get; set; }

        public static MonsterDef[] ReadItems()
        {
            MonsterDef[] monsterDefs = null;

            using (BinaryReader reader = new BinaryReader(File.Open(@"C:\Users\Mark\Desktop\Hex-Backup-July-5-2020\server2\data\monsterdef.dat", FileMode.Open)))
            {
                int monsterCount = reader.ReadInt32();

                for (int i = 0; i < monsterCount; i++)
                {
                    MonsterDef monsterDef = new MonsterDef();

                    monsterDef.InUse = Convert.ToBoolean(reader.ReadInt16());
                    reader.ReadInt16(); // Appears to always be blank
                    monsterDef.Name = new string(reader.ReadChars(50));
                    monsterDef.Image = reader.ReadInt16();
                    monsterDef.ImageType = (ImageType)reader.ReadInt16();
                    monsterDef.Level = reader.ReadInt16();
                    monsterDef.Attackable = Convert.ToBoolean(reader.ReadInt16());

                    reader.ReadBytes(100); // Empty 100 bytes

                    if (monsterDef.InUse)
                        monsterDefs[i] = monsterDef;
                }

            }
            return monsterDefs;
        }
    }
}
