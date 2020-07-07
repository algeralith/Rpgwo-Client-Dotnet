using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGWO_Client.Network.Packets
{
    public class PlayerStats : Packet
    {
        // Life
        public string Life { get; set; }
        // Max Life
        public string MaxLife { get; set; }
        // Stamina
        public string Stamina { get; set; }
        // Max Stamina
        public string MaxStamina { get; set; }
        // Total Exp
        public string TotalExp { get; set; }
        // Earned Exp
        public string EarnedExp { get; set; } // Spendable
        // Mana
        public string Mana { get; set; }
        // Max Mana
        public string MaxMana { get; set; }
        // Level
        public string Level { get; set; }
        // Next Level
        public string NextLevel { get; set; }
        // Vitae
        public byte Vitae { get; set; }
        // Vitae Exp
        public string VitaeExp { get; set; }
        // Poison
        public byte Poison { get; set; }

        public PlayerStats() : base((byte)PacketTypes.PlayerStats, 70)
        {

        }

        public override bool Receive()
        {
            Life = ReadBytesAsString(4);
            MaxLife = ReadBytesAsString(4);

            Stamina = ReadBytesAsString(4);
            MaxStamina = ReadBytesAsString(4);

            TotalExp = ReadBytesAsString(9);
            EarnedExp = ReadBytesAsString(9);

            Mana = ReadBytesAsString(4);
            MaxMana = ReadBytesAsString(4);

            Level = ReadBytesAsString(4);

            NextLevel = ReadBytesAsString(9);

            Vitae = ReadByte();

            // The next three bytes do not appear to be used.
            ReadBytes(3);

            VitaeExp = ReadBytesAsString(9);

            // Next Byte is not used.
            ReadByte();

            Poison = ReadByte(); 

            return true;
        }
    }
}
