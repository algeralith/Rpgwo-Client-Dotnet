using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGWO_Client.Network.Packets
{
    public class Text : Packet
    {
        public byte TextLength { get; private set; }
        public bool ReceivedText { get; set; }
        public Text() : base((byte)PacketTypes.Text, 10)
        {
            ReceivedText = false;
        }

        public override bool Receive()
        {
            TextLength = ReadByte();

            return true;
        }
    }
}
