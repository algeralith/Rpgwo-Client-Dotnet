using RPGWO_Client.Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGWO_Client.Items
{
    public class ItemDef
    {

        public Int16 InUse { get; set; }
        public String Name { get; set; } // 30 Characters
        public Int16[] Animation { get; set; } = new Int16[10];
        public ImageType ImageType { get; set; }
        public ItemClass ItemClass { get; set; }
        public Int16 Burden { get; set; }
        public Int32 Value { get; set; }
        public bool OpenSightLine { get; set; }
        public bool BlockMovement { get; set; }
        public Int16 Food { get; set; }
        public Int16 Water { get; set; }
        public Int16 FoodLife { get; set; }
        public Int16 FoodStamina { get; set; }
        public Int16 FoodMana { get; set; }
        public Int16 PoisonDamage { get; set; }
        public Int16 PoisonCure { get; set; }
        public bool Readable { get; set; }
        public bool Stackable { get; set; }
        public Int16 Rarity { get; set; }
        public Int16 LightSource { get; set; }
        public Int16 WeaponMinRange { get; set; }
        public Int16 WeaponMaxRange { get; set; }
        public Int16 CombatSkillID { get; set; }
        public Int16 DamageLow { get; set; }
        public Int16 DamageHigh { get; set; }
        public Single AttackSpeed { get; set; }
        public bool MissleWeapon { get; set; }
        public Single MagicPower { get; set; }
        public Int16 EssenceSteal { get; set; }
        public bool TwoHanded { get; set; }
        public bool IgnoreShields { get; set; }
        public bool IgnoreArmor { get; set; }
        public Int16 WeaponAL { get; set; }
        public bool BreakShield { get; set; }
        public bool StaminaDamage { get; set; }
        public Int16 CriticalBonus { get; set; }
        public Int16 SkillReq { get; set; }
        public ArmorSpot ArmorSpot { get; set; }
        public Int16 ArmorLevel { get; set; }
        public Int16 MagicArmorLevel { get; set; }
        public WeaponDamageType WeaponDamageType { get; set; }
        public Int16 CutAL { get; set; }
        public Int16 BashAL { get; set; }
        public Int16 ThrustAL { get; set; }
        public Int16 FireAL { get; set; }
        public Int16 ColdAL { get; set; }
        public Int16 ElectricalAL { get; set; }
        public Int16 Warmth { get; set; }
        public bool IsAmmo { get; set; }
        public bool SelfRepair { get; set; }
        public bool DynamicDamage { get; set; }

        public static ItemDef[] ReadItems()
        {
            ItemDef[] itemDefs = null;

            using (BinaryReader reader = new BinaryReader(File.Open(@"C:\Users\Mark\Desktop\Hex-Backup-July-5-2020\server2\data\itemdef2.dat", FileMode.Open)))
            {
                int version = reader.ReadInt32();
                int itemCount = reader.ReadInt32();

                itemDefs = new ItemDef[itemCount];

                for (int i = 0; i < itemCount; i++)
                {
                    ItemDef itemDef = new ItemDef();

                    itemDef.InUse = reader.ReadInt16();
                    itemDef.Name = new String(reader.ReadChars(30));

                    for (int j = 0; j < 10; j++)
                        itemDef.Animation[j] = reader.ReadInt16();

                    itemDef.ImageType = (ImageType)reader.ReadByte();
                    itemDef.ItemClass = (ItemClass)reader.ReadInt16();
                    itemDef.Burden = reader.ReadInt16();
                    itemDef.Value = reader.ReadInt32();
                    itemDef.OpenSightLine = Convert.ToBoolean(reader.ReadInt16());
                    itemDef.BlockMovement = Convert.ToBoolean(reader.ReadInt16());
                    itemDef.Food = reader.ReadInt16();
                    itemDef.Water = reader.ReadInt16();
                    itemDef.FoodLife = reader.ReadInt16();
                    itemDef.FoodStamina = reader.ReadInt16();
                    itemDef.FoodMana = reader.ReadInt16();
                    itemDef.PoisonDamage = reader.ReadInt16();
                    itemDef.PoisonCure = reader.ReadInt16();
                    itemDef.Readable = Convert.ToBoolean(reader.ReadInt16());
                    itemDef.Stackable = Convert.ToBoolean(reader.ReadInt16());
                    itemDef.Rarity = reader.ReadInt16();
                    itemDef.LightSource = reader.ReadInt16(); // Probably always zero due to this being put into a packet instead.
                    itemDef.WeaponMinRange = reader.ReadInt16();
                    itemDef.WeaponMaxRange = reader.ReadInt16();
                    itemDef.CombatSkillID = reader.ReadInt16();
                    itemDef.DamageLow = reader.ReadInt16();
                    itemDef.DamageHigh = reader.ReadInt16();
                    itemDef.AttackSpeed = reader.ReadSingle();
                    itemDef.MissleWeapon = Convert.ToBoolean(reader.ReadInt16());
                    itemDef.MagicPower = reader.ReadSingle();
                    itemDef.EssenceSteal = reader.ReadInt16();
                    itemDef.TwoHanded = Convert.ToBoolean(reader.ReadInt16());
                    itemDef.IgnoreShields = Convert.ToBoolean(reader.ReadInt16());
                    itemDef.IgnoreArmor = Convert.ToBoolean(reader.ReadInt16());
                    itemDef.WeaponAL = reader.ReadInt16();
                    itemDef.BreakShield = Convert.ToBoolean(reader.ReadInt16());
                    itemDef.StaminaDamage = Convert.ToBoolean(reader.ReadInt16());
                    itemDef.CriticalBonus = reader.ReadInt16();
                    itemDef.SkillReq = reader.ReadInt16();
                    itemDef.ArmorSpot = (ArmorSpot)reader.ReadInt16();
                    itemDef.ArmorLevel = reader.ReadInt16();
                    itemDef.MagicArmorLevel = reader.ReadInt16();
                    itemDef.WeaponDamageType = (WeaponDamageType)reader.ReadInt16();
                    itemDef.CutAL = reader.ReadInt16();
                    itemDef.BashAL = reader.ReadInt16();
                    itemDef.ThrustAL = reader.ReadInt16();
                    itemDef.FireAL = reader.ReadInt16();  
                    itemDef.ColdAL = reader.ReadInt16();
                    itemDef.ElectricalAL = reader.ReadInt16();
                    itemDef.Warmth = reader.ReadInt16();
                    itemDef.IsAmmo = Convert.ToBoolean(reader.ReadInt16());
                    itemDef.SelfRepair = Convert.ToBoolean(reader.ReadInt16());
                    itemDef.DynamicDamage = Convert.ToBoolean(reader.ReadInt16());

                    reader.ReadBytes(96); // As far as I can tell, the remaining bytes are empty and never used.

                    itemDefs[i] = itemDef;
                }
            }

            return itemDefs;
        }

    }
}
