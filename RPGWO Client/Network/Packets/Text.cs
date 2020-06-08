using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGWO_Client.Network.Packets
{
    public class Text : Packet
    {
        public byte TextLength { get; set; }
        public byte Channel { get; set; }
        public int UUID { get; set; }
        public int ClientID { get; set; }

        // Not part of the Packet Structure.
        public bool ReceivedText { get; set; }
        public Text() : base((byte)PacketTypes.Text, 10)
        {
            IsMultiPart = true; // Comes in as two packets.
            MultiComplete = false;

            ReceivedText = false;
        }

        public void PrepareForText()
        {

        }

        public override bool Receive()
        {
            if (!ReceivedText)
            {
                TextLength = ReadByte();
                Channel = ReadByte();
                UUID = ReadInt32();
                ClientID = ReadInt32();

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
