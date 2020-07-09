﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGWO_Client.Network.Packets
{
    public class PlayerLocation : Packet
    {

        public byte Xpos { get; set; }
        public byte Ypos { get; set; }
        public byte ImageType { get; set; } // TODO :: Enum this.
        public byte Stealth { get; set; } // Bool or Byte?
        public byte Name { get; set; } // 50 characters
        public byte LifePercentage { get; set; }
        public byte Tame { get; set; }
        public byte pType { get; set; } // TODO 
        public string Index { get; set; } // Not sure if string, or int32. TODO :: 
        public string Level { get; set; } // 4 characters
        public byte Light { get; set; }
        public string Image { get; set; } // 4 characters
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
            ImageType = ReadByte();
            Stealth = ReadByte();
            Name = ReadByte();
            LifePercentage = ReadByte();
            Tame = ReadByte();
            pType = ReadByte();
            Index = ReadBytesAsString(4);
            Level = ReadBytesAsString(4);
            Light = ReadByte();
            Image = ReadBytesAsString(4);
            Head = ReadByte();
            Arms = ReadByte();
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