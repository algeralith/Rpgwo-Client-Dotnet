﻿using RPGWO_Client.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGWO_Client.Networking.Packets
{
    public class PlayerLocation : Packet
    {

        public byte Xpos { get; set; }
        public byte Ypos { get; set; }
        public ImageType ImageType { get; set; } // TODO :: Enum this.
        public byte Stealth { get; set; } // Bool or Byte?
        public string Name { get; set; } // 50 characters
        public byte LifePercentage { get; set; }
        public byte Tame { get; set; }
        public byte pType { get; set; } // TODO 
        public Int32 Index { get; set; } // Not sure if string, or int32. TODO :: 
        public int Level { get; set; } // 4 characters
        public byte Light { get; set; }
        public int Image { get; set; } // 4 characters
        public byte Head { get; set; }
        public byte Arms { get; set; }
        public byte Chest { get; set; }
        public byte Legs { get; set; }
        public byte Weapon { get; set; }
        public byte Shield { get; set; }
        public byte Wearing { get; set; }
        public byte StaminaPercentage { get; set; }
        public byte ManaPercentage { get; set; }

        public PlayerLocation() : base((byte)PacketTypes.PlayerLocation, 79)
        {

        }

        public override bool Receive()
        {
            Xpos = ReadByte();
            Ypos = ReadByte();
            ImageType = (ImageType)ReadByte();
            Stealth = ReadByte();
            Name = ReadString(50);
            LifePercentage = ReadByte();
            Tame = ReadByte();
            pType = ReadByte(); // 57
            Index = ReadStringAsInt(4);
            Level = ReadStringAsInt(4); // Does not appear to be sent.
            Light = ReadByte(); // 66
            Image = ReadStringAsInt(4);
            Head = ReadByte(); // 71
            Arms = ReadByte();
            Chest = ReadByte();
            Legs = ReadByte();
            Weapon = ReadByte();
            Shield = ReadByte();
            Wearing = ReadByte();
            StaminaPercentage = ReadByte();
            ManaPercentage = ReadByte();

            return true;
        }
    }
}
