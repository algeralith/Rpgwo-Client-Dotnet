using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGWO_Client.Network.Packets
{
    public class TextContent : Packet
    {
        public byte Length { get; private set; }

        public TextContent(byte textLength) : base(textLength)
        {
            Length = textLength;
        }

        public override bool Receive()
        {
            throw new NotImplementedException();
        }
    }
}
