using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGWO_Client.Network.Packets
{
    public class ReqPlayerList : Packet
    {
        public ReqPlayerList() : base((byte)PacketTypes.ReqPlayerList, 1)
        {

        }

        public override bool Receive()
        {
            throw new NotImplementedException();
        }
    }
}
