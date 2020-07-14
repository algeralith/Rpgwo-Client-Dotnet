using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGWO_Client.Networking.Packets
{
    public class Info2 : Packet
    {
        public byte[] Data1;

        public byte[] Data2;

        public Info2() : base((byte)PacketTypes.Info2, 120)
        {

        }

        public override byte[] GetBytes()
        {
            return base.GetBytes();
        }

        public override bool Receive()
        {
            throw new NotImplementedException();
        }
    }
}
    