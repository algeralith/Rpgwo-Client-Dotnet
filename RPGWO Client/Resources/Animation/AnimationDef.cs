using System;
using System.Globalization;
using System.IO;

namespace RPGWO_Client.Resources.Animation
{
    public class AnimationDef
    {
        public bool InUse { get; set; }
        public string Name { get; set; } // 20 Characters
        public AnimationFrame[] AnimationFrame { get; set; } = new AnimationFrame[20];
        public bool Rotational { get; set; }
        public bool FireLine { get; set; }

        public static AnimationDef[] ReadItems()
        {
            AnimationDef[] animationDefs = null;

            using (BinaryReader reader = new BinaryReader(File.Open(@"C:\Users\Mark\Desktop\Hex-Backup-July-5-2020\server2\data\animation.dat", FileMode.Open))) // TODO :: 
            {
                int animationCount = reader.ReadInt16();
                animationDefs = new AnimationDef[animationCount];

                for (int i = 0; i < animationCount; i++)
                {
                    AnimationDef animationDef = new AnimationDef();

                    animationDef.InUse = Convert.ToBoolean(reader.ReadInt16());
                    animationDef.Name = new string(reader.ReadChars(20));

                    for (int j = 0; j < animationDef.AnimationFrame.Length; j++)
                    {
                        // Assume first frame always exists
                        int frame = reader.ReadInt16();

                        if (frame == 0)
                            continue; // No Frame

                        animationDef.AnimationFrame[j] = new AnimationFrame();
                        animationDef.AnimationFrame[j].Frame = frame;
                    }

                    for (int j = 0; j < animationDef.AnimationFrame.Length; j++)
                    {
                        Int16 frameSize = reader.ReadInt16();

                        if (animationDef.AnimationFrame[j] != null)
                            animationDef.AnimationFrame[j].FrameSize = frameSize;
                    }

                    for (int j = 0; j < animationDef.AnimationFrame.Length; j++)
                    {
                        string sound = new string(reader.ReadChars(50));

                        if (animationDef.AnimationFrame[j] != null)
                            animationDef.AnimationFrame[j].Sound = sound;
                    }

                    animationDef.Rotational = Convert.ToBoolean(reader.ReadInt16());
                    animationDef.FireLine = Convert.ToBoolean(reader.ReadInt16());

                    byte[] b = reader.ReadBytes(101); // Empty Bytes

                    if (animationDef.InUse)
                        animationDefs[i] = animationDef;
                }
            }

            return animationDefs;
        }
    }
}
