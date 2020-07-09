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

        // Multipart
        public bool IsMultiPart { get; protected set; }
        public bool MultiComplete { get; protected set; }

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

        protected bool ResizeBuffer(int length)
        {
            if (length < buffer.Length)
            {
                // We can not decrease size, only increase.
                return false;
            }

            byte[] tmpBuff = new byte[length];

            buffer.CopyTo(tmpBuff, 0);

            buffer = tmpBuff;

            return true;
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

        public void AddInt32(int i)
        {
            Buffer.BlockCopy(BitConverter.GetBytes(i), 0, buffer, _writeHead, 4);
            _writeHead += 4;
        }

        public void AddString(String s, int maxLength, char initial)
        {
            if (s.Length > maxLength)
            {
                s = s.Substring(0, maxLength);
            }
            
            byte[] tmpBuff = Encoding.ASCII.GetBytes(new string(initial, 20));
            tmpBuff.CopyTo(buffer, _writeHead);

            byte[] stringBytes = Encoding.UTF8.GetBytes(s);
            stringBytes.CopyTo(buffer, _writeHead);

            _writeHead += maxLength;
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
        public bool ReadBool()
        {
            byte b = ReadByte();

            if (b == 0XFF)
                return true;
            else
                return false;
        }

        public byte ReadByte()
        {
            byte b = buffer[_readHead];
            _readHead++;
            return b;
        }

        public byte[] ReadBytes(int length)
        {
            byte[] b = new byte[length];
            Array.Copy(buffer, _readHead, b, 0, length);
            _readHead += length;

            return b;
        }

        public string ReadBytesAsString(int length)
        {
            // For playerstats the each byte represents its value in a string
            // i.e { 0x0, 0x0, 0x1, 0x2 } -> 0012 -> 12

            StringBuilder sb = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                byte b = ReadByte();
                sb.Append(b);
            }

            return sb.ToString().TrimStart('0');
        }

        public Int16 ReadInt16()
        {
            Int16 i = BitConverter.ToInt16(buffer, _readHead);
            _readHead += 2;
            return i;
        }

        public int ReadInt32()
        {
            int i = BitConverter.ToInt32(buffer, _readHead);
            _readHead += 4;
            return i;
        }

        public String ReadString(int maxLength)
        {
            String tmp = Encoding.UTF8.GetString(ReadBytes(maxLength)).TrimEnd('\0');

            return tmp;
        }
    }
}
