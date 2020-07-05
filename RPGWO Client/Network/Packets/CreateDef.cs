using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGWO_Client.Network.Packets
{
    public class CreateDef : Packet
    {
        public int SkillPoints { get; set; }
        public int Attributes { get; set; }

        public CreateDef() : base((byte)PacketTypes.CreateDef, 4)
        {

        }

        public override bool Receive()
        {
            SkillPoints = ReadInt16();
            Attributes = ReadInt16();

            return true;
        }
    }
}
