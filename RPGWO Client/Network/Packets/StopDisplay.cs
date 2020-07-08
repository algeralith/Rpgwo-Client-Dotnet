using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGWO_Client.Network.Packets
{
    public class StopDisplay : Packet
    {
        public StopDisplay() : base((byte)PacketTypes.StopDisplay, 1)
        {

        }

        public override bool Receive()
        {
            return true;
        }
    }
}
