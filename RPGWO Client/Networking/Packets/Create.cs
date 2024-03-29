﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGWO_Client.Networking.Packets
{
    public class Create : Packet
    {
        // Name, 50 characters max
        public string Name { get; set; }

        // Health / Stamina / Mana
        public byte Life { get; set; }
        public Int32 Stamina { get; set; }
        public byte Mana { get; set; }

        // Attributes
        public byte Strength { get; set; }
        public byte Dexterity { get; set; }
        public byte Quickness { get; set; }
        public byte Intelligence { get; set; }
        public byte Wisdom { get; set; }

        // Skills -- Max of 20 skills
        // This packet is weird. 20 bytes for skills, then 3 empty bytes
        // Then 20 bytes for specs, then 1 empty byte
        public SkillDef[] Skills { get; private set; }

        // Player Images
        public byte Head { get; set; }
        public byte Arms { get; set; }
        public byte Chest { get; set; }
        public byte Legs { get; set; }

        public Create() : base((byte)PacketTypes.Create, 109)
        {
            Skills = new SkillDef[20];
        }

        public override byte[] GetBytes()
        {
            AddString(Name, 50);

            // Health / Stam / Mana
            AddByte(Life);
            AddInt32(Stamina);
            AddByte(Mana);

            // Attributes
            AddByte(Strength);
            AddByte(Dexterity);
            AddByte(Quickness);
            AddByte(Intelligence);
            AddByte(Wisdom);

            // Skills
            for (int i = 0; i < Skills.Length; i++)
            {
                if (Skills[i] == null)
                    AddByte(0);
                else
                    AddByte(Skills[i].SkillID);
            }

            // Three Empty Bytes
            AddByte(0);
            AddByte(0);
            AddByte(0);

            // Spec
            for (int i = 0; i < Skills.Length; i++)
            {
                if (Skills[i] == null)
                    AddByte(0);
                else if (Skills[i].Spec)
                    AddByte(1);
                else
                    AddByte(0);
            }

            // One Empty Byte
            AddByte(0);

            // Images
            AddByte(Head);
            AddByte(Arms);
            AddByte(Chest);
            AddByte(Legs);
            return base.GetBytes();
        }

        public override bool Receive()
        {
            throw new NotImplementedException();
        }
    }
}
