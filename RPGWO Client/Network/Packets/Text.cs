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
        public byte[] Unknown { get; private set; } // TODO :: Unsure of the remaining data.

        // Not part of the Packet Structure.
        public bool ReceivedText { get; set; }
        public Text() : base((byte)PacketTypes.Text, 10)
        {
            IsMultiPart = true; // Comes in as two packets.
            MultiComplete = false;

            ReceivedText = false;
            Unknown = new byte[9]; // TODO :: 
        }

        public void PrepareForText()
        {

        }

        public override bool Receive()
        {
            if (!ReceivedText)
            {
                TextLength = ReadByte();

                for (int i = 0; i < Unknown.Length; i++)
                    ReadByte();

                // Resize Buffer
                ResizeBuffer(this.buffer.Length + TextLength);

                ReceivedText = true;
                MultiComplete = true;

                return false; // We have not received all the data. Need second.s
            } else
            {
                // Prepare for 
            }

            return true;
        }
    }
}
