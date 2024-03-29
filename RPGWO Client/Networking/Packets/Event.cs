﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGWO_Client.Networking.Packets
{
    public class Event : Packet
    {
        public byte EventId { get; set; }
        public byte Xpos { get; set; }
        public byte Ypos { get; set; }
        public byte Result { get; set; }
        public byte Data1 { get; set; }
        public byte Data2 { get; set; }

        public Event() : base((byte)PacketTypes.Event, 6)
        {

        }

        public override bool Receive()
        {
            EventId = ReadByte();
            Xpos = ReadByte();
            Ypos = ReadByte();
            Result = ReadByte();
            Data1 = ReadByte();
            Data2 = ReadByte();

            return true;
        }
    }
}
