using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGWO_Client.Network.Packets
{
    public class SkillDef : Packet
    {
        public string Name = ""; // 20 bytes
        public byte SkillID;
        public bool ClearList;
        public Int16 Value; // Not sure
        public byte SkillPoints;
        public byte Strength;
        public byte Dexterity;
        public byte Quickness;
        public byte Intelligence;
        public byte Wisdom;
        public byte Divisor;
        public byte Status; // Not sure
        public string Description = ""; // 100 Max

        public SkillDef() : base((byte)PacketTypes.SkillDef, 133)
        {

        }

        public override bool Receive()
        {
            Name = ReadString(20);
            SkillID = ReadByte();
            ClearList = ReadBool();
            Value = ReadInt16();
            SkillPoints = ReadByte();
            Strength = ReadByte();
            Dexterity = ReadByte();
            Quickness = ReadByte();
            Intelligence = ReadByte();
            Wisdom = ReadByte();
            Divisor = ReadByte();
            Status = ReadByte();
            Description = ReadString(100);

            return true;
        }

        public override byte[] GetBytes()
        {
            AddString(Name, 20);
            AddByte(SkillID);
            // Add Bool Clear
            AddString(Description, 100);
            return base.GetBytes();
        }
    }
}
