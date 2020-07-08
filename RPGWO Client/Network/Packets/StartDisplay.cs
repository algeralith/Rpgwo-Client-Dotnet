using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGWO_Client.Network.Packets
{
    public class StartDisplay : Packet
    {
        public StartDisplay() : base((byte)PacketTypes.StartDisplay, 1)
        {

        }

        public override bool Receive()
        {
            return true;
        }
    }
}
