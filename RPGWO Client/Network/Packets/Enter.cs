using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGWO_Client.Network.Packets
{
    public class Enter : Packet
    {
        // 50 Characters
        public string Name { get; set; }

        public Enter() : base((byte)PacketTypes.Enter, 50)
        {

        }

        public override bool Receive()
        {
            throw new NotImplementedException();
        }

        public override byte[] GetBytes()
        {
            AddString(Name, 50);
            return base.GetBytes();
        }
    }
}
