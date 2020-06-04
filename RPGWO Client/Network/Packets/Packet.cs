using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGWO_Client.Network.Packets
{
    public abstract class Packet
    {
        public byte PacketID { get; }

        // Security Fields
        public byte CRC { get; set; }
        public byte Rnd { get; set; }

        // Packet contents
        protected byte[] buffer { get; private set; }

        private int _writeHead = 0;
        private int _readHead = 0;

        public Packet(byte packetID, int size)
        {
            this.PacketID = packetID;
            this.buffer = new byte[size];
        }

        // Not every packet will have a header. Mostly for TextContent
        public Packet(int size)
        {
            this.buffer = new byte[size];
        }

        public virtual byte[] GetBytes()
        {
            return buffer;
        }

        public abstract bool Receive();

        public int Size
        {
            get
            {
                if (buffer == null)
                    return 0;
                else
                    return buffer.Length;
            }
        }
        
        public int Remaining()
        {
            return Math.Max(buffer.Length - _writeHead, 0);
        }
        
        public void AdvanceWriteHead(int length)
        {
            _writeHead += length; // TODO :: I hate this type of function, redo it at some point.
        }

        // Add Methods
        public void AddBool(bool b)
        {
            if (b == true)
                AddByte(0xFF);
            else
                AddByte(0x00);
        }

        public void AddByte(byte b)
        {
            buffer[_writeHead] = b;
            _writeHead++;
        }

        public void AddBytes(byte[] data)
        {
            // TODO :: Make sure not to overflow past end of buffer
            data.CopyTo(buffer, _writeHead);

            _writeHead += data.Length;
        }

        public void AddBytes(byte[] data, int pos, int count)
        {
            // TODO :: Make sure not to overflow past end of buffer
            Buffer.BlockCopy(data, pos, buffer, _writeHead, count);

            _writeHead += count;
        }

        public void AddString(String s, int maxLength)
        {
            if (s.Length > maxLength)
            {
                s = s.Substring(0, maxLength);
            }

            byte[] stringBytes = Encoding.UTF8.GetBytes(s);
            stringBytes.CopyTo(buffer, _writeHead);

            _writeHead += maxLength;
        }

        // Read Methods
        public byte ReadByte()
        {
            byte b = buffer[_readHead];
            _readHead++;
            return b;
        }

        public Int16 ReadInt16()
        {
            Int16 i = BitConverter.ToInt16(buffer, _readHead);
            _readHead++;
            return i;
        }

        public String ReadString(int maxLength)
        {
            return "";
        }
    }
}
