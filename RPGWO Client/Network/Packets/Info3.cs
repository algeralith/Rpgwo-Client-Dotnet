using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGWO_Client.Network.Packets
{
    public class Info3 : Packet
    {
        public byte Data1 { get; set; } // Only ever see it as 0
        public byte Data2 { get; set; } // Appears to reference in-game hour.

        public Info3() : base((byte)PacketTypes.Info3, 2)
        {

        }

        public override bool Receive()
        {
            throw new NotImplementedException();
        }
    }
}
