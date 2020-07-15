using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RPGWO_Client.Resources.Items
{
    public class ItemUse
    {
        public bool InUse { get; set; }
        public Int16 MakePVP { get; set; } // 0, Nothing. 1 MakePVP, 2 MakeNonPVP
        public Int16 ItemTool { get; set; }
        public Int16 ItemFocus { get; set; }
        public Int16[] SuccessItem { get; set; } = new Int16[10];
        public Int16[] SuccessItemQty { get; set; } = new Int16[10];
        public bool SetResurrectSpot { get; set; }
        public bool PublicUse { get; set; }
        public bool Warp { get; set; }
        public Int16 Mortarspeed { get; set; }
        public bool UseItemSkillReq { get; set; }
        public Int16 SuccessTool { get; set; }
        public Int16 SuccessFocus { get; set; }
        public Int16[] FailedItem { get; set; } = new Int16[10];
        public Int16[] FailedItemQty { get; set; } = new Int16[10];
        public Int16 FailedTool { get; set; }
        public Int16 FailedFocus { get; set; }
        public Int16 Skill { get; set; }
        public Int16 SkillMin { get; set; }
        public Int16 SkillMax { get; set; }
        public Int16 SkillXPSuccess { get; set; }
        public Int16 SkillXPFailure { get; set; }
        public Int16 SurfaceWater { get; set; }
        public bool NeedFlatSurface { get; set; }
        public Int16 Range { get; set; }
        public bool UsePlayerPosition { get; set; }
        public bool NeedUnLevelSurface { get; set; }
        public string SuccessMsg { get; set; } // 50 Characters
        public string FailedMsg { get; set; } // 50 Characters
        public bool LockFocus { get; set; } = false;
        public Int16 KeyFocus { get; set; } = 0;
        public Int16 StaminaCost { get; set; } = 1;
        public bool ShowWriting { get; set; }
        public bool DispKeyFocus { get; set; }
        public bool PreserveData { get; set; }
        public bool OwnLand { get; set; }
        public bool DigUnderGround { get; set; }
        public bool SurfaceOnly { get; set; }
        public bool UnderGroundOnly { get; set; }
        public Int16 PickLock { get; set; }
        public bool SetWriting { get; set; }
        public bool SetAim { get; set; }
        public bool SetFocusData8 { get; set; }
        public Int16 FocusData8 { get; set; }
        public bool UseAllQty { get; set; }
        public Int16 FailedDamage { get; set; }
        public bool DisarmTrap { get; set; }
        public bool PlotUse { get; set; }
        public bool ResetItemUse { get; set; }
        public bool ResetWeapon { get; set; }
        public bool ResetArmor { get; set; }
        public bool RaiseLand { get; set; }
        public bool LowerLand { get; set; }
        public bool RenewInnRoom { get; set; }
        public Int16 FishVariance { get; set; }
        public bool NotOnPlayer { get; set; }
        public Int16 GiveSkillBonus { get; set; }
        public Int16 ReverseTool { get; set; }
        public Int16 Heal { get; set; }
        public Int16 HealPoison { get; set; }
        public Int16 PlayerUsageTimeout { get; set; }
        public Int16 MonsterID { get; set; }
        public Int16 SurfaceGround { get; set; }
        public Int16 Animation { get; set; }
        public Int16 Drunk { get; set; }
        public Int16 SurfaceUnderground { get; set; }
        public Int16 Revive { get; set; }
        public Int16 Mana { get; set; }
        public Int16 Mortardamage { get; set; }
        public Int16 AddSurfaceWater { get; set; }
        public Int16 AddAirWater { get; set; }
        public bool AddTame { get; set; }
        public bool Perks { get; set; }
        public Int16 MagicBonus { get; set; }
        public Int16 FactionRank { get; set; }
        public bool Trigger { get; set; }
        public Int16 SetFocusData1 { get; set; }
        public string FocusSubType { get; set; } // 20 Characters
        public string ToolSubType { get; set; } // 20 Characters
        public Int16 InvasionDamage { get; set; }
        public Int16 BuildWork { get; set; }
        public Int16 BuildNeeded { get; set; }
        public Int16 BuildItem { get; set; }

        public static ItemUse[] ReadItems(string filePath)
        {
            List<ItemUse> itemUsages = new List<ItemUse>();

            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                long usageCount = reader.BaseStream.Length / 495; // Each entry is 495 bytes in length

                for (int i = 0; i < usageCount; i++)
                {
                    ItemUse itemUse = new ItemUse();

                    itemUse.InUse = Convert.ToBoolean(reader.ReadInt16());

                    if (!itemUse.InUse)
                    {
                        reader.BaseStream.Position += 493; // Not in use, might as well just skip reading.
                        continue;
                    }

                    itemUse.MakePVP = reader.ReadInt16();
                    itemUse.ItemTool = reader.ReadInt16();
                    itemUse.ItemFocus = reader.ReadInt16();

                    // 0 by default
                    for (int j = 0; j < itemUse.SuccessItem.Length; j++)
                    {
                        itemUse.SuccessItem[j] = reader.ReadInt16(); // The documents say 1-10, but it appears the 10th can not be set
                    }

                    // 1 by default
                    for (int j = 0; j < itemUse.SuccessItemQty.Length; j++)
                    {
                        itemUse.SuccessItemQty[j] = reader.ReadInt16(); // Refer to SuccessItem, appears to be 1-9 only.
                    }

                    itemUse.SetResurrectSpot = Convert.ToBoolean(reader.ReadInt16());
                    itemUse.PublicUse = Convert.ToBoolean(reader.ReadInt16());
                    itemUse.Warp = Convert.ToBoolean(reader.ReadInt16());

                    Int16 unknown3 = reader.ReadInt16(); // 1
                    if (unknown3 != 1)
                        Console.WriteLine();
                    Int16 unknown4 = reader.ReadInt16();

                    if (unknown4 != 0)
                        Console.WriteLine();

                    itemUse.Mortarspeed = reader.ReadInt16();
                    itemUse.UseItemSkillReq = Convert.ToBoolean(reader.ReadInt16());
                    itemUse.SuccessTool = reader.ReadInt16();
                    itemUse.SuccessFocus = reader.ReadInt16();

                    // 0 by default
                    for (int j = 0; j < itemUse.FailedItem.Length; j++)
                    {
                        itemUse.FailedItem[j] = reader.ReadInt16(); // The documents say 1-10, but it appears the 10th can not be set
                    }

                    // 1 by default
                    for (int j = 0; j < itemUse.FailedItemQty.Length; j++)
                    {
                        itemUse.FailedItemQty[j] = reader.ReadInt16(); // Refer to SuccessItem, appears to be 1-9 only.
                    }

                    itemUse.FailedTool = reader.ReadInt16();
                    itemUse.FailedFocus = reader.ReadInt16();
                    itemUse.Skill = reader.ReadInt16();
                    itemUse.SkillMin = reader.ReadInt16();
                    itemUse.SkillMax = reader.ReadInt16();
                    itemUse.SkillXPSuccess = reader.ReadInt16();
                    itemUse.SkillXPFailure = reader.ReadInt16();
                    itemUse.SurfaceWater = reader.ReadInt16();
                    itemUse.NeedFlatSurface = Convert.ToBoolean(reader.ReadInt16());
                    itemUse.Range = reader.ReadInt16();

                    // The follow two are an oddity. It requires an = followed by a value, but it appears to
                    // be boolean in the end. 
                    itemUse.UsePlayerPosition = Convert.ToBoolean(reader.ReadInt16());
                    itemUse.NeedUnLevelSurface = Convert.ToBoolean(reader.ReadInt16());

                    itemUse.SuccessMsg = new String(reader.ReadChars(50));
                    itemUse.FailedMsg = new String(reader.ReadChars(50));
                    itemUse.LockFocus = Convert.ToBoolean(reader.ReadInt16());
                    itemUse.KeyFocus = reader.ReadInt16();
                    itemUse.StaminaCost = reader.ReadInt16();
                    itemUse.ShowWriting = Convert.ToBoolean(reader.ReadInt16());
                    itemUse.DispKeyFocus = Convert.ToBoolean(reader.ReadInt16());
                    itemUse.PreserveData = Convert.ToBoolean(reader.ReadInt16());
                    itemUse.OwnLand = Convert.ToBoolean(reader.ReadInt16());
                    itemUse.DigUnderGround = Convert.ToBoolean(reader.ReadInt16());
                    itemUse.SurfaceOnly = Convert.ToBoolean(reader.ReadInt16());
                    itemUse.UnderGroundOnly = Convert.ToBoolean(reader.ReadInt16());


                    itemUse.PickLock = reader.ReadInt16();
                    itemUse.SetWriting = Convert.ToBoolean(reader.ReadInt16());

                    Int16 unknown6 = reader.ReadInt16();
                    Int16 unknown7 = reader.ReadInt16();
                    Int16 unknown8 = reader.ReadInt16();


                    itemUse.SetAim = Convert.ToBoolean(reader.ReadInt16());

                    // The Follow is not known.
                    itemUse.UseAllQty = Convert.ToBoolean(reader.ReadInt16()); // This appears to not work, in fact. Makes no difference in hex comparision.


                    itemUse.FocusData8 = reader.ReadInt16();
                    itemUse.SetFocusData8 = Convert.ToBoolean(reader.ReadInt16());
                    itemUse.FailedDamage = reader.ReadInt16();
                    itemUse.DisarmTrap = Convert.ToBoolean(reader.ReadInt16());
                    itemUse.PlotUse = Convert.ToBoolean(reader.ReadInt16());
                    itemUse.ResetItemUse = Convert.ToBoolean(reader.ReadInt16());
                    itemUse.ResetWeapon = Convert.ToBoolean(reader.ReadInt16());
                    itemUse.ResetArmor = Convert.ToBoolean(reader.ReadInt16());
                    itemUse.RaiseLand = Convert.ToBoolean(reader.ReadInt16());
                    itemUse.LowerLand = Convert.ToBoolean(reader.ReadInt16());
                    itemUse.RenewInnRoom = Convert.ToBoolean(reader.ReadInt16());
                    itemUse.FishVariance = reader.ReadInt16();
                    itemUse.NotOnPlayer = Convert.ToBoolean(reader.ReadInt16());
                    itemUse.GiveSkillBonus = reader.ReadInt16();

                    Int16 unknown9 = reader.ReadInt16();
                    Int16 unknown10 = reader.ReadInt16();

                    itemUse.ReverseTool = reader.ReadInt16();
                    itemUse.Heal = reader.ReadInt16();
                    itemUse.HealPoison = reader.ReadInt16();
                    itemUse.PlayerUsageTimeout = reader.ReadInt16();
                    itemUse.MonsterID = reader.ReadInt16();
                    itemUse.SurfaceGround = reader.ReadInt16();
                    itemUse.Animation = reader.ReadInt16();
                    itemUse.Drunk = reader.ReadInt16();

                    Int16 unknown11 = reader.ReadInt16();
                    Int16 unknown12 = reader.ReadInt16();
                    Int16 unknown13 = reader.ReadInt16(); // 1

                    itemUse.SurfaceGround = reader.ReadInt16();
                    itemUse.Revive = reader.ReadInt16();
                    itemUse.Mana = reader.ReadInt16();
                    itemUse.Mortardamage = reader.ReadInt16();

                    Int16[] Unknowns = new Int16[21];

                    for (int j = 0; j < Unknowns.Length; j++)
                    {
                        Unknowns[j] = reader.ReadInt16();
                    }

                    itemUse.AddSurfaceWater = reader.ReadInt16();
                    itemUse.AddAirWater = reader.ReadInt16();
                    itemUse.AddTame = Convert.ToBoolean(reader.ReadInt16());
                    itemUse.Perks = Convert.ToBoolean(reader.ReadInt16());
                    itemUse.MagicBonus = reader.ReadInt16();

                    Int16[] Unknowns2 = new Int16[10];

                    for (int j = 0; j < Unknowns2.Length; j++)
                    {
                        Unknowns2[j] = reader.ReadInt16();
                    }

                    itemUse.FactionRank = reader.ReadInt16();
                    itemUse.Trigger = Convert.ToBoolean(reader.ReadInt16());
                    itemUse.SetFocusData1 = reader.ReadInt16();
                    itemUse.FocusSubType = new string(reader.ReadChars(20));
                    itemUse.ToolSubType = new string(reader.ReadChars(20));

                    Int16 unknown16 = reader.ReadInt16();

                    itemUse.InvasionDamage = reader.ReadInt16();
                    itemUse.BuildNeeded = reader.ReadInt16();
                    itemUse.BuildWork = reader.ReadInt16();
                    itemUse.BuildItem = reader.ReadInt16();

                    reader.ReadBytes(41);

                    itemUsages.Add(itemUse);
                }
            }

            return itemUsages.ToArray();
        }
    }
}
