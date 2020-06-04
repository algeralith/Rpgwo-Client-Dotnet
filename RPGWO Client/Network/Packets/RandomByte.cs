using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGWO_Client.Network.Packets
{
    public class RandomByte : Packet
    { 
        public Int16 randomByte = 0;

        public RandomByte() : base((byte)PacketTypes.RandomByte, 2)
        {
        }

        public override bool Receive()
        {
            randomByte = ReadInt16();
            return true;
        }
    }
}
