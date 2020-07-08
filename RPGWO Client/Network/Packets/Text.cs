using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGWO_Client.Network.Packets
{
    public class Text : Packet
    {
        public byte TextLength { get; set; } = 0;
        public byte Channel { get; set; } = 0;
        public int UUID { get; set; } = 0;
        public int ClientID { get; set; } = 0;

        // This part is sent in a second packet
        public string TextContent { get; set; }

        // Not part of the Packet Structure.
        private bool TextPart { get; set; }

        public Text() : base((byte)PacketTypes.Text, 10)
        {
            IsMultiPart = true; // Comes in as two packets.
            MultiComplete = false;
            TextPart = false;
        }

        public override byte[] GetBytes()
        {
            if (!TextPart) // Set up the first part
            {
                AddByte(TextLength); // Max Length is 255 TODO :: enforce this limit.
                AddByte(Channel);
                AddInt32(UUID);
                AddInt32(ClientID);

                TextPart = true;

                return base.GetBytes();
            }
            else
            {
                MultiComplete = true;
                byte[] tmpBuff = new byte[TextLength];
                Encoding.UTF8.GetBytes(TextContent).CopyTo(tmpBuff, 0);
                return tmpBuff;
            }
        }

        public override bool Receive()
        {
            if (!TextPart)
            {
                TextLength = ReadByte();
                Channel = ReadByte();
                UUID = ReadInt32();
                ClientID = ReadInt32();

                // Resize Buffer
                ResizeBuffer(this.buffer.Length + TextLength);

                TextPart = true;
                MultiComplete = true;

                return false; // We have not received all the data. Need second.s
            }
            else
            {
                // Prepare for 
            }

            return true;
        }
    }
}
