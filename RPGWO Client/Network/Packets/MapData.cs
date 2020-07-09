﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGWO_Client.Network.Packets
{
    public class MapData : Packet
    {
        // Mapview is 19 x 17

        public Int16 Xpos { get; set; }
        public Int16 Ypos { get; set; }
        public Int16 Zpos { get; set; }
        public byte[] MapTileData { get; set; } // TODO ::
        public byte BigViewReq { get; set; }

        public MapData() : base((byte)PacketTypes.MapData, 1299) // 0x514
        {
            // MapTileData = new byte[19 * 17 * 4]; 
        }

        public override bool Receive()
        {
            Xpos = ReadInt16();
            Ypos = ReadInt16();
            Zpos = ReadInt16();
            MapTileData = ReadBytes(19 * 17 * 4);
            BigViewReq = ReadByte();

            return true;
        }
    }
}