using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGWO_Client.Networking.Packets
{
    public class ReqSkillList : Packet
    {
        public ReqSkillList() : base((byte)PacketTypes.ReqSkillList, 1)
        {

        }

        public override bool Receive()
        {
            throw new NotImplementedException();
        }
    }
}
