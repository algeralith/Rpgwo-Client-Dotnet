//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Windows;
//using System.Windows.Input;
//using System.IO;
//using System.Net.Sockets;


//namespace RPGWO_Client.Network
//{
    
//    /////////////////////////////////////////////////

//    class PktVersionClass
//    {
//        public const byte PacketID = 2;
//        public const byte PacketLength = 42;

//        public byte[] dataBuffer;


//        // packet data
//        public string VersionName = "RPGWO 3";
//        public string VersionVersion = "3.4";


//        public PktVersionClass()
//        {
//            dataBuffer = new byte[PacketLength];
//        }

//        public byte[] GetData()
//        {
//            dataBuffer = new byte[PacketLength];

//            dataBuffer[0] = PacketID;

//            System.Text.Encoding.UTF8.GetBytes(VersionName).CopyTo(dataBuffer, 1);

//            System.Text.Encoding.UTF8.GetBytes(VersionVersion).CopyTo(dataBuffer, 21);

//            return dataBuffer;
//        }


//        /*
//                public void Send(Socket socket)
//                {
//                    dataBuffer = new byte[PacketLength];

//                    dataBuffer[0] = PacketID;

//                    System.Text.Encoding.UTF8.GetBytes(VersionName).CopyTo(dataBuffer, 1);

//                    System.Text.Encoding.UTF8.GetBytes(VersionVersion).CopyTo(dataBuffer, 21);

//                    //dataBuffer[3] = 0;
//                    //dataBuffer[3] = MiscClass.CalcCheckSum(dataBuffer);

//                    //socket.Send(dataBuffer);

//                    SocketAsyncEventArgs x = new SocketAsyncEventArgs();
//                    x.SetBuffer(dataBuffer, 0, PacketLength);

//                    socket.SendAsync(x);
//                }
//        */


//    }

//    /////////////////////////////////////////////////

//    class PktLogonClass
//    {
//        public const byte PacketID = 4;
//        public const byte PacketLength = 142;

//        public byte[] dataBuffer;


//        // packet data
//        public string UserName;
//        public string Password;
//        //public bool flgNewUser;
//        public string Email;


//        public PktLogonClass()
//        {
//            dataBuffer = new byte[PacketLength];
//        }

//        public byte[] GetData()
//        {
//            dataBuffer = new byte[PacketLength];

//            dataBuffer[0] = PacketID;

//            if (UserName != null)
//            {
//                //UserName = UserName.PadRight(20 - UserName.Length, ' ');
//                System.Text.Encoding.UTF8.GetBytes(UserName).CopyTo(dataBuffer, 1);
//                //Log.Add("username=>" + UserName + "<=");
//            }

//            if (Password != null)
//            {
//                //Password = Password.PadRight(20 - Password.Length, ' ');
//                System.Text.Encoding.UTF8.GetBytes(Password).CopyTo(dataBuffer, 21);
//            }

//            //dataBuffer[41] = Convert.ToByte(flgNewUser);

//            if (Email != null)
//            {
//                //Email = Email.PadRight(100 - Email.Length, ' ');
//                System.Text.Encoding.UTF8.GetBytes(Email).CopyTo(dataBuffer, 42);
//            }

//            return dataBuffer;
//        }
//    }

//    /////////////////////////////////////////////////

//    class PktRequestClass
//    {
//        public const byte PacketID = 101;
//        public const byte PacketLength = 14;

//        public byte[] dataBuffer;


//        /*
//         * Catagory:
//         1 = req all mail
//         2 = set mail as read : data1 = mailIndex
//         3 = delete mail : data1 = mailIndex, -999 = ALL
//         4 = multi-use : data1 = UseIndex, data2 = CarryIndex, data3 = InContainerIndex
//         5 = map light mode : data1 = Zpos
//         * 
//         New for silverlight
//         * 
//         * 10 = request players (replaces pktReqPlayerList)
//         * 11 = request skill def (replaces pktReqSkillDef)
//         * 12 = enter final (replaces pktEnterFinal)
//         * 13 = exit world (replaces pktExitWorld)
//         * 14 = skill/stat xp check, data1 = 0-50 skill, 100+ attrib life, stam, mana, str, dex, quick, intel, wis
//         */


//        // packet data
//        public byte Catagory;
//        public int Data1;
//        public int Data2;
//        public int Data3;



//        public PktRequestClass(byte inCatagory, int inData1, int inData2, int inData3)
//        {
//            dataBuffer = new byte[PacketLength];

//            Catagory = inCatagory;
//            Data1 = inData1;
//            Data2 = inData2;
//            Data3 = inData3;
//        }

//        public byte[] GetData()
//        {
//            dataBuffer = new byte[PacketLength];

//            dataBuffer[0] = PacketID;

//            dataBuffer[1] = Catagory;

//            BitConverter.GetBytes(Data1).CopyTo(dataBuffer, 2);

//            BitConverter.GetBytes(Data2).CopyTo(dataBuffer, 6);

//            BitConverter.GetBytes(Data3).CopyTo(dataBuffer, 10);

//            return dataBuffer;
//        }
//    }

//    /////////////////////////////////////////////////

//    class PktPlayerListClass
//    {
//        public const byte PacketID = 7;
//        public const byte PacketLength = 251 + 1;       // + 1 for crc

//        public int RecvCount;

//        public byte[] dataBuffer;


//        // packet data
//        public string[] PlayerName = new string[5];



//        public PktPlayerListClass()
//        {
//            dataBuffer = new byte[PacketLength];
//        }


//        public bool Recv()
//        {
//            dataBuffer[0] = PacketID;


//            PlayerName[0] = System.Text.Encoding.UTF8.GetString(dataBuffer, 1, 50);
//            PlayerName[1] = System.Text.Encoding.UTF8.GetString(dataBuffer, 51, 50);
//            PlayerName[2] = System.Text.Encoding.UTF8.GetString(dataBuffer, 101, 50);
//            PlayerName[3] = System.Text.Encoding.UTF8.GetString(dataBuffer, 151, 50);
//            PlayerName[4] = System.Text.Encoding.UTF8.GetString(dataBuffer, 201, 50);


//            byte crc = dataBuffer[251];
//            dataBuffer[251] = 0;

//            return crc == MiscClass.CalcCheckSum(dataBuffer);
//        }
//    }

//    /////////////////////////////////////////////////

//    class PktSkillDefClass
//    {
//        public const byte PacketID = 67;
//        public const byte PacketLength = 134 + 1;       // + 1 for crc

//        public int RecvCount;

//        public byte[] dataBuffer;


//        // packet data
//        public string SkillName;    // 20
//        public byte SkillID;
//        public bool flgClearList;
//        public short Value;
//        public byte SkillPoints;
//        public byte Strength;
//        public byte Dexterity;
//        public byte Quickness;
//        public byte Intelligence;
//        public byte Wisdom;
//        public byte Divisor;
//        public byte Status;
//        public byte Spec;
//        public string Description;  // 100


//        public PktSkillDefClass()
//        {
//            dataBuffer = new byte[PacketLength];
//        }


//        public bool Recv()
//        {
//            try
//            {
//                dataBuffer[0] = PacketID;


//                SkillName = System.Text.Encoding.UTF8.GetString(dataBuffer, 1, 20);

//                SkillID = dataBuffer[21];
//                flgClearList = BitConverter.ToBoolean(dataBuffer, 22);
//                Value = BitConverter.ToInt16(dataBuffer, 23);
//                SkillPoints = dataBuffer[25];
//                Strength = dataBuffer[26];
//                Dexterity = dataBuffer[27];
//                Quickness = dataBuffer[28];
//                Intelligence = dataBuffer[29];
//                Wisdom = dataBuffer[30];
//                Divisor = dataBuffer[31];
//                Status = dataBuffer[32];
//                Spec = dataBuffer[33];

//                Description = System.Text.Encoding.UTF8.GetString(dataBuffer, 34, 100);

//                byte crc = dataBuffer[134];
//                dataBuffer[134] = 0;

//                /*
//                                Log.Add("SkillDef crc = " + crc + " : CalcCRC = " + MiscClass.CalcCheckSum(dataBuffer) + " : " + SkillName);

//                                if (crc != MiscClass.CalcCheckSum(dataBuffer))
//                                {
//                                    string s1 = "Data=>";
//                                    for (int i = 0; i < 134; i++)
//                                        s1 += dataBuffer[i].ToString() + ":";

//                                    Log.Add(s1);
//                                }
//                 */

//                return crc == MiscClass.CalcCheckSum(dataBuffer);
//            }
//            catch (Exception err)
//            {
//                Log.Add("Error_pktSkillDef_Recv : " + err.Message);
//            }

//            return false;
//        }
//    }

//    /////////////////////////////////////////////////

//    class PktCreateDefClass
//    {
//        public const byte PacketID = 65;
//        public const byte PacketLength = 5 + 1;       // + 1 for crc

//        public int RecvCount;

//        public byte[] dataBuffer;


//        // packet data
//        public short SkillPoints;
//        public short AttributePoints;


//        public PktCreateDefClass()
//        {
//            dataBuffer = new byte[PacketLength];
//        }


//        public bool Recv()
//        {
//            dataBuffer[0] = PacketID;

//            SkillPoints = BitConverter.ToInt16(dataBuffer, 1);
//            AttributePoints = BitConverter.ToInt16(dataBuffer, 3);

//            byte crc = dataBuffer[5];
//            dataBuffer[5] = 0;

//            return crc == MiscClass.CalcCheckSum(dataBuffer);
//        }
//    }

//    /////////////////////////////////////////////////

//    class PktCreateClass
//    {
//        public const byte PacketID = 5;
//        public const byte PacketLength = 110;

//        public byte[] dataBuffer;


//        // packet data
//        public string PlayerName;   // 50

//        public byte Life;
//        public byte Stamina;
//        public byte Mana;

//        public byte Strength;
//        public byte Dexterity;
//        public byte Quickness;
//        public byte Intelligence;
//        public byte Wisdom;

//        public byte[] TrainedSkillID = new byte[21];
//        public byte[] SpecSkillID = new byte[21];



//        public PktCreateClass()
//        {
//            dataBuffer = new byte[PacketLength];
//        }


//        public byte[] GetData()
//        {
//            dataBuffer = new byte[PacketLength];

//            dataBuffer[0] = PacketID;

//            if (PlayerName != null)
//                System.Text.Encoding.UTF8.GetBytes(PlayerName).CopyTo(dataBuffer, 1);

//            dataBuffer[51] = Life;
//            dataBuffer[52] = Stamina;
//            dataBuffer[56] = Mana;

//            dataBuffer[57] = Strength;
//            dataBuffer[58] = Dexterity;
//            dataBuffer[59] = Quickness;
//            dataBuffer[60] = Intelligence;
//            dataBuffer[61] = Wisdom;

//            for (int i = 0; i <= 20; i++)
//            {
//                dataBuffer[62 + i] = TrainedSkillID[i];
//                dataBuffer[85 + i] = SpecSkillID[i];
//            }

//            return dataBuffer;
//        }
//    }

//    /////////////////////////////////////////////////

//    class PktEnterClass
//    {
//        public const byte PacketID = 11;
//        public const byte PacketLength = 51;

//        public byte[] dataBuffer;


//        // packet data
//        public string PlayerName;


//        public PktEnterClass()
//        {
//            dataBuffer = new byte[PacketLength];
//        }

//        public byte[] GetData()
//        {
//            dataBuffer = new byte[PacketLength];

//            dataBuffer[0] = PacketID;

//            if (PlayerName != null)
//            {
//                System.Text.Encoding.UTF8.GetBytes(PlayerName).CopyTo(dataBuffer, 1);
//            }

//            return dataBuffer;
//        }
//    }

//    /////////////////////////////////////////////////

//    class PktWorldStateClass
//    {
//        public const byte PacketID = 22;
//        public const byte PacketLength = 10 + 1;       // + 1 for crc

//        public int RecvCount;

//        public byte[] dataBuffer;


//        // packet data
//        public short MapSize;
//        public byte Year;
//        public byte Month;
//        public byte Day;
//        public byte Hour;
//        public byte Minute;
//        public byte Dark;
//        public byte Temperature;



//        public PktWorldStateClass()
//        {
//            dataBuffer = new byte[PacketLength];
//        }

//        public bool Recv()
//        {
//            dataBuffer[0] = PacketID;

//            MapSize = BitConverter.ToInt16(dataBuffer, 1);

//            Year = dataBuffer[3];
//            Month = dataBuffer[4];
//            Day = dataBuffer[5];
//            Hour = dataBuffer[6];
//            Minute = dataBuffer[7];
//            Dark = dataBuffer[8];
//            Temperature = dataBuffer[9];

//            byte crc = dataBuffer[10];
//            dataBuffer[10] = 0;

//            //Event.Add(Event.EventEnum.Event_PopupMsg, 0.1, "CRC = " + crc + "," + MiscClass.CalcCheckSum(dataBuffer));

//            return crc == MiscClass.CalcCheckSum(dataBuffer);
//        }

//    }

//    /////////////////////////////////////////////////

//    class PktPlayerStatsClass
//    {
//        public const byte PacketID = 27;
//        public const byte PacketLength = 33 + 1;       // + 1 for crc

//        public int RecvCount;

//        public byte[] dataBuffer;


//        // packet data
//        public short Life;
//        public short MaxLife;
//        public short Stamina;
//        public short MaxStamina;
//        public short Mana;
//        public short MaxMana;

//        public int TotalExp;
//        public int EarnedExp;
//        public short Level;
//        public int NextLevel;

//        public byte Vitae;
//        public int VitaeExp;

//        public byte Poison;



//        public PktPlayerStatsClass()
//        {
//            dataBuffer = new byte[PacketLength];
//        }


//        public bool Recv()
//        {
//            dataBuffer[0] = PacketID;

//            Life = BitConverter.ToInt16(dataBuffer, 1);
//            MaxLife = BitConverter.ToInt16(dataBuffer, 3);
//            Stamina = BitConverter.ToInt16(dataBuffer, 5);
//            MaxStamina = BitConverter.ToInt16(dataBuffer, 7);
//            Mana = BitConverter.ToInt16(dataBuffer, 9);
//            MaxMana = BitConverter.ToInt16(dataBuffer, 11);

//            TotalExp = BitConverter.ToInt32(dataBuffer, 13);
//            EarnedExp = BitConverter.ToInt32(dataBuffer, 17);
//            Level = BitConverter.ToInt16(dataBuffer, 21);
//            NextLevel = BitConverter.ToInt32(dataBuffer, 23);

//            Vitae = dataBuffer[27];
//            VitaeExp = BitConverter.ToInt32(dataBuffer, 28);

//            Poison = dataBuffer[32];

//            byte crc = dataBuffer[33];
//            dataBuffer[33] = 0;

//            return crc == MiscClass.CalcCheckSum(dataBuffer);
//        }
//    }


//    /////////////////////////////////////////////////

//    class PktPlayerStats2Class
//    {
//        public const byte PacketID = 43;
//        public const byte PacketLength = 13 + 1;       // + 1 for crc

//        public int RecvCount;

//        public byte[] dataBuffer;


//        // packet data
//        public short Burden;
//        public short MaxBurden;
//        public short Food;
//        public short MaxFood;
//        public short Water;
//        public short MaxWater;


//        public PktPlayerStats2Class()
//        {
//            dataBuffer = new byte[PacketLength];
//        }


//        public bool Recv()
//        {
//            dataBuffer[0] = PacketID;

//            Burden = BitConverter.ToInt16(dataBuffer, 1);
//            MaxBurden = BitConverter.ToInt16(dataBuffer, 3);
//            Food = BitConverter.ToInt16(dataBuffer, 5);
//            MaxFood = BitConverter.ToInt16(dataBuffer, 7);
//            Water = BitConverter.ToInt16(dataBuffer, 9);
//            MaxWater = BitConverter.ToInt16(dataBuffer, 11);

//            byte crc = dataBuffer[13];
//            dataBuffer[13] = 0;

//            return crc == MiscClass.CalcCheckSum(dataBuffer);
//        }
//    }

//    /////////////////////////////////////////////////

//    class PktAttribClass
//    {
//        public const byte PacketID = 37;
//        public const byte PacketLength = 11 + 1;       // + 1 for crc

//        public int RecvCount;

//        public byte[] dataBuffer;


//        // packet data
//        public short Strength;
//        public short Dexterity;
//        public short Quickness;
//        public short Intelligence;
//        public short Wisdom;


//        public PktAttribClass()
//        {
//            dataBuffer = new byte[PacketLength];
//        }


//        public bool Recv()
//        {
//            dataBuffer[0] = PacketID;

//            Strength = BitConverter.ToInt16(dataBuffer, 1);
//            Dexterity = BitConverter.ToInt16(dataBuffer, 3);
//            Quickness = BitConverter.ToInt16(dataBuffer, 5);
//            Intelligence = BitConverter.ToInt16(dataBuffer, 7);
//            Wisdom = BitConverter.ToInt16(dataBuffer, 9);

//            byte crc = dataBuffer[11];
//            dataBuffer[11] = 0;

//            return crc == MiscClass.CalcCheckSum(dataBuffer);
//        }
//    }

//    /////////////////////////////////////////////////

//    class PktSkillClass
//    {
//        public const byte PacketID = 36;
//        public const byte PacketLength = 34 + 1;       // + 1 for crc

//        public int RecvCount;

//        public byte[] dataBuffer;


//        // packet data
//        public string SkillName;    // 20

//        public byte SkillID;
//        public byte ClearList;
//        public short Value;
//        public byte SkillPoints;

//        public byte Strength;
//        public byte Dexterity;
//        public byte Quickness;
//        public byte Intelligence;
//        public byte Wisdom;
//        public byte Divisor;

//        public byte Status;
//        public byte Spec;


//        public PktSkillClass()
//        {
//            dataBuffer = new byte[PacketLength];
//        }


//        public bool Recv()
//        {
//            dataBuffer[0] = PacketID;

//            SkillName = System.Text.Encoding.UTF8.GetString(dataBuffer, 1, 20);

//            SkillID = dataBuffer[21];
//            ClearList = dataBuffer[22];
//            Value = BitConverter.ToInt16(dataBuffer, 23);
//            SkillPoints = dataBuffer[25];

//            Strength = dataBuffer[26];
//            Dexterity = dataBuffer[27];
//            Quickness = dataBuffer[28];
//            Intelligence = dataBuffer[29];
//            Wisdom = dataBuffer[30];
//            Divisor = dataBuffer[31];

//            Status = dataBuffer[32];
//            Spec = dataBuffer[33];

//            byte crc = dataBuffer[34];
//            dataBuffer[34] = 0;

//            return crc == MiscClass.CalcCheckSum(dataBuffer);
//        }
//    }

//    /////////////////////////////////////////////////


//    public class PktItemLocationClass
//    {
//        public const byte PacketID = 19;
//        public const byte PacketLength = 26 + 1;       // + 1 for crc

//        public int RecvCount;

//        public byte[] dataBuffer;


//        // packet data

//        public short ItemID;
//        public byte Quality;
//        public byte SpellID;
//        public byte Xpos;
//        public byte Ypos;
//        public ItemSpotEnum Spot;       // see item spot enum
//        public int Index;
//        public byte OpenSightCount;
//        public byte LightSource;    // 13

//        public byte MagicWeaponDamage;      // 17
//        public byte SkillBonusID;
//        public short SkillBonusValue;
//        public byte NoDisplay;
//        public int Quantity;



//        public PktItemLocationClass()
//        {
//            dataBuffer = new byte[PacketLength];
//        }


//        public bool Recv()
//        {
//            dataBuffer[0] = PacketID;

//            ItemID = BitConverter.ToInt16(dataBuffer, 1);

//            Quality = dataBuffer[3];
//            SpellID = dataBuffer[4];
//            Xpos = dataBuffer[5];
//            Ypos = dataBuffer[6];
//            Spot = (ItemSpotEnum)dataBuffer[7];
//            Index = BitConverter.ToInt32(dataBuffer, 8);
//            OpenSightCount = dataBuffer[12];
//            LightSource = dataBuffer[13];

//            MagicWeaponDamage = dataBuffer[17];
//            SkillBonusID = dataBuffer[18];
//            SkillBonusValue = BitConverter.ToInt16(dataBuffer, 19);

//            NoDisplay = dataBuffer[21];
//            Quantity = BitConverter.ToInt32(dataBuffer, 22);

//            byte crc = dataBuffer[26];
//            dataBuffer[26] = 0;

//            return crc == MiscClass.CalcCheckSum(dataBuffer);
//        }
//    }

//    /////////////////////////////////////////////////

//    class PktRuneBagClass
//    {
//        public const byte PacketID = 62;
//        public const byte PacketLength = 101 + 1;       // + 1 for crc

//        public int RecvCount;

//        public byte[] dataBuffer;


//        // packet data
//        public byte[] RuneBag;



//        public PktRuneBagClass()
//        {
//            dataBuffer = new byte[PacketLength];
//        }


//        public bool Recv()
//        {
//            dataBuffer[0] = PacketID;

//            RuneBag = new byte[101];

//            for (int i = 1; i < 101; i++)
//                RuneBag[i] = dataBuffer[i];

//            byte crc = dataBuffer[101];
//            dataBuffer[101] = 0;

//            //Event.Add(Event.EventEnum.Event_PopupMsg, 0.1, "CRC =" + crc + "," + MiscClass.CalcCheckSum(dataBuffer));

//            return crc == MiscClass.CalcCheckSum(dataBuffer);
//        }
//    }

//    /////////////////////////////////////////////////

//    class PktTradeInfoClass
//    {
//        public const byte PacketID = 50;
//        public const byte PacketLength = 45 + 1;    // + 1 for crc

//        public int RecvCount;

//        public byte[] dataBuffer;


//        // packet data
//        public string Name1;   // 20
//        public string Name2;   // 20

//        public long Gold2;


//        public PktTradeInfoClass()
//        {
//            dataBuffer = new byte[PacketLength];
//        }

//        public bool Recv()
//        {
//            dataBuffer[0] = PacketID;

//            Name1 = System.Text.Encoding.UTF8.GetString(dataBuffer, 1, 20);
//            Name2 = System.Text.Encoding.UTF8.GetString(dataBuffer, 21, 20);

//            Gold2 = BitConverter.ToInt32(dataBuffer, 41);

//            byte crc = dataBuffer[45];
//            dataBuffer[45] = 0;

//            //Event.Add(Event.EventEnum.Event_PopupMsg, 0.1, "CRC = " + crc + "," + MiscClass.CalcCheckSum(dataBuffer));

//            return crc == MiscClass.CalcCheckSum(dataBuffer);
//        }

//    }

//    /////////////////////////////////////////////////

//    class PktSoundClass
//    {
//        public const byte PacketID = 34;
//        public const byte PacketLength = 22 + 1;       // + 1 for crc

//        public int RecvCount;

//        public byte[] dataBuffer;


//        // packet data
//        public string SoundName;    // 20

//        public byte Loop;


//        public PktSoundClass()
//        {
//            dataBuffer = new byte[PacketLength];
//        }


//        public bool Recv()
//        {
//            dataBuffer[0] = PacketID;

//            SoundName = System.Text.Encoding.UTF8.GetString(dataBuffer, 1, 20);

//            Loop = dataBuffer[21];

//            byte crc = dataBuffer[22];
//            dataBuffer[22] = 0;

//            return crc == MiscClass.CalcCheckSum(dataBuffer);
//        }
//    }

//    /////////////////////////////////////////////////

//    class PktTextClass
//    {
//        public const byte PacketID = 41;
//        public const byte PacketLength = 11 + 1;       // + 1 for crc

//        public byte[] dataBuffer;

//        public int RecvCount;


//        // packet data
//        public byte TextSize;
//        public byte Channel;
//        public int UUID;
//        public int ClientID;


//        public PktTextClass()
//        {
//            dataBuffer = new byte[PacketLength];
//        }


//        public byte[] GetData()
//        {
//            dataBuffer = new byte[PacketLength - 1];      // don't send crc in packet

//            dataBuffer[0] = PacketID;

//            dataBuffer[1] = TextSize;
//            dataBuffer[2] = Channel;

//            BitConverter.GetBytes(UUID).CopyTo(dataBuffer, 3);
//            BitConverter.GetBytes(ClientID).CopyTo(dataBuffer, 7);

//            return dataBuffer;
//        }

//        public bool Recv()
//        {
//            dataBuffer[0] = PacketID;

//            TextSize = dataBuffer[1];
//            Channel = dataBuffer[2];

//            UUID = BitConverter.ToInt32(dataBuffer, 3);
//            ClientID = BitConverter.ToInt32(dataBuffer, 7);

//            byte crc = dataBuffer[11];
//            dataBuffer[11] = 0;

//            return crc == MiscClass.CalcCheckSum(dataBuffer);
//        }
//    }

//    /////////////////////////////////////////////////

//    class PktMapDataClass
//    {
//        public const byte PacketID = 10;
//        public const short PacketLength = 1320 + 8 + 1;       // + 1 for crc

//        public byte[] dataBuffer;

//        public int RecvCount;


//        // packet data
//        public short Xpos;
//        public short Ypos;
//        public short Zpos;
//        public short[] MapData = new short[22 * 2 * 15 * 2];
//        public byte BigViewReq;


//        public PktMapDataClass()
//        {
//            dataBuffer = new byte[PacketLength];
//        }


//        public bool Recv()
//        {
//            dataBuffer[0] = PacketID;

//            Xpos = BitConverter.ToInt16(dataBuffer, 1320 + 1);
//            Ypos = BitConverter.ToInt16(dataBuffer, 1320 + 3);
//            Zpos = BitConverter.ToInt16(dataBuffer, 1320 + 5);

//            BigViewReq = dataBuffer[1320 + 7];  // ???


//            /*
//            for (int i = 0; i < 21; i++)
//            {
//                for (int j = 0; j < 14; j++)
//                {
//                    GameState.SurfaceMap[i, j] = dataBuffer[i * 14 + j * 2 + 1];
//                    GameState.HeightMap[i, j] = dataBuffer[i * 14 + j * 2 + 1 + 1];
//                }
//            }
//            */


//            byte crc = dataBuffer[1320 + 8];
//            dataBuffer[1320 + 8] = 0;

//            return crc == MiscClass.CalcCheckSum(dataBuffer);
//        }
//    }

//    /////////////////////////////////////////////////

//    class PktMapChangeClass
//    {
//        public const byte PacketID = 26;
//        public const byte PacketLength = 5 + 1;       // + 1 for crc

//        public int RecvCount;

//        public byte[] dataBuffer;


//        // packet data
//        public byte Xpos;
//        public byte Ypos;
//        public short Image;


//        public PktMapChangeClass()
//        {
//            dataBuffer = new byte[PacketLength];
//        }


//        public bool Recv()
//        {
//            dataBuffer[0] = PacketID;

//            Xpos = dataBuffer[1];
//            Ypos = dataBuffer[2];

//            Image = BitConverter.ToInt16(dataBuffer, 3);

//            byte crc = dataBuffer[5];
//            dataBuffer[5] = 0;

//            return crc == MiscClass.CalcCheckSum(dataBuffer);
//        }
//    }

//    /////////////////////////////////////////////////

//    class PktLineMapDataClass
//    {
//        public const byte PacketID = 24;
//        public const byte PacketLength = 52 + 1;       // + 1 for crc

//        public int RecvCount;

//        public byte[] dataBuffer;


//        // packet data
//        public short Xpos;
//        public short Ypos;
//        public short Zpos;
//        public byte Direction;
//        //public short[] MapData = new short[22 * 2];
//        public byte[] SurfaceData = new byte[22];
//        public byte[] HeightData = new byte[22];


//        public PktLineMapDataClass()
//        {
//            dataBuffer = new byte[PacketLength];
//        }


//        public bool Recv()
//        {
//            dataBuffer[0] = PacketID;

//            Xpos = BitConverter.ToInt16(dataBuffer, 1);
//            Ypos = BitConverter.ToInt16(dataBuffer, 3);
//            Zpos = BitConverter.ToInt16(dataBuffer, 5);

//            Direction = dataBuffer[7];

//            // need to get map data  

//            for (int i = 0; i < 22; i++)
//            {
//                SurfaceData[i] = dataBuffer[8 + i * 2];
//                HeightData[i] = dataBuffer[8 + i * 2 + 1];
//            }


//            byte crc = dataBuffer[52];
//            dataBuffer[52] = 0;

//            return crc == MiscClass.CalcCheckSum(dataBuffer);
//        }
//    }

//    /////////////////////////////////////////////////

//    class PktPlayerLocationClass
//    {
//        public const byte PacketID = 17;
//        public const byte PacketLength = 81 + 1;       // + 1 for crc

//        public byte[] dataBuffer;

//        public int RecvCount;

//        // packet data
//        public byte Xpos;
//        public byte Ypos;
//        public byte ImageType;      // imagetype, 0 1x1, 1 1x2, 2 2x2
//        public byte Stealth;
//        public string Name;         // 50
//        public byte LifePercent;
//        public byte Tame;
//        public byte pType;
//        public short Index;
//        public short Level;
//        public byte Light;
//        public short Image;
//        public byte Head;
//        public byte Arms;
//        public byte Chest;
//        public byte Legs;
//        public byte Weapon;
//        public byte Sheild;
//        public byte Wearing;
//        public byte StaminaPercent;
//        public byte ManaPercent;
//        public byte Facing;



//        public PktPlayerLocationClass()
//        {
//            dataBuffer = new byte[PacketLength];
//        }


//        public bool Recv()
//        {
//            dataBuffer[0] = PacketID;

//            Xpos = dataBuffer[1];
//            Ypos = dataBuffer[2];
//            ImageType = dataBuffer[3];
//            Stealth = dataBuffer[4];

//            Name = System.Text.Encoding.UTF8.GetString(dataBuffer, 5, 50);

//            LifePercent = dataBuffer[55];
//            Tame = dataBuffer[56];
//            pType = dataBuffer[57];

//            Index = BitConverter.ToInt16(dataBuffer, 58);
//            Level = BitConverter.ToInt16(dataBuffer, 62);

//            Light = dataBuffer[66];

//            Image = BitConverter.ToInt16(dataBuffer, 67);

//            Head = dataBuffer[71];
//            Arms = dataBuffer[72];
//            Chest = dataBuffer[73];
//            Legs = dataBuffer[74];
//            Weapon = dataBuffer[75];
//            Sheild = dataBuffer[76];
//            Wearing = dataBuffer[77];
//            StaminaPercent = dataBuffer[78];
//            ManaPercent = dataBuffer[79];

//            Facing = dataBuffer[80];


//            byte crc = dataBuffer[81];
//            dataBuffer[81] = 0;

//            return crc == MiscClass.CalcCheckSum(dataBuffer);
//        }
//    }

//    /////////////////////////////////////////////////

//    class PktMonsterLocationClass
//    {
//        public const byte PacketID = 72;
//        public const byte PacketLength = 12 + 1;       // + 1 for crc

//        public byte[] dataBuffer;

//        public int RecvCount;

//        // packet data
//        public byte Xpos;
//        public byte Ypos;
//        public short MonsterID;
//        public short pIndex;
//        public byte LifePercent;
//        public byte StaminaPercent;
//        public byte ManaPercent;
//        public byte Stealth;
//        public byte Facing;


//        public PktMonsterLocationClass()
//        {
//            dataBuffer = new byte[PacketLength];
//        }


//        public bool Recv()
//        {
//            dataBuffer[0] = PacketID;

//            Xpos = dataBuffer[1];
//            Ypos = dataBuffer[2];
//            MonsterID = BitConverter.ToInt16(dataBuffer, 3);
//            pIndex = BitConverter.ToInt16(dataBuffer, 5);

//            LifePercent = dataBuffer[7];
//            StaminaPercent = dataBuffer[8];
//            ManaPercent = dataBuffer[9];
//            Stealth = dataBuffer[10];
//            Facing = dataBuffer[11];

//            byte crc = dataBuffer[12];
//            dataBuffer[12] = 0;

//            return crc == MiscClass.CalcCheckSum(dataBuffer);
//        }
//    }

//    /////////////////////////////////////////////////

//    class PktStartDisplayClass
//    {
//        public const byte PacketID = 15;
//        public const byte PacketLength = 8 + 1;       // + 1 for crc

//        public int RecvCount;

//        public byte[] dataBuffer;


//        // packet data
//        public byte Monster;
//        public short Xpos, Ypos, Zpos;


//        public PktStartDisplayClass()
//        {
//            dataBuffer = new byte[PacketLength];
//        }


//        public bool Recv()
//        {
//            dataBuffer[0] = PacketID;

//            Monster = dataBuffer[1];

//            Xpos = BitConverter.ToInt16(dataBuffer, 2);
//            Ypos = BitConverter.ToInt16(dataBuffer, 4);
//            Zpos = BitConverter.ToInt16(dataBuffer, 6);

//            byte crc = dataBuffer[8];
//            dataBuffer[8] = 0;

//            return crc == MiscClass.CalcCheckSum(dataBuffer);
//        }
//    }

//    /////////////////////////////////////////////////

//    class PktStartLineDisplayClass
//    {
//        public const byte PacketID = 25;
//        public const byte PacketLength = 2 + 1;       // + 1 for crc

//        public int RecvCount;

//        public byte[] dataBuffer;


//        // packet data
//        public byte Direction;


//        public PktStartLineDisplayClass()
//        {
//            dataBuffer = new byte[PacketLength];
//        }


//        public bool Recv()
//        {
//            dataBuffer[0] = PacketID;

//            Direction = dataBuffer[1];

//            byte crc = dataBuffer[2];
//            dataBuffer[2] = 0;

//            return crc == MiscClass.CalcCheckSum(dataBuffer);
//        }
//    }

//    /////////////////////////////////////////////////

//    class PktStopDisplayClass
//    {
//        public const byte PacketID = 16;
//        public const byte PacketLength = 2 + 1;       // + 1 for crc

//        public int RecvCount;

//        public byte[] dataBuffer;


//        // packet data
//        public byte BigViewReq;


//        public PktStopDisplayClass()
//        {
//            dataBuffer = new byte[PacketLength];
//        }


//        public bool Recv()
//        {
//            dataBuffer[0] = PacketID;

//            BigViewReq = dataBuffer[1];

//            byte crc = dataBuffer[2];
//            dataBuffer[2] = 0;

//            return crc == MiscClass.CalcCheckSum(dataBuffer);
//        }
//    }

//    /////////////////////////////////////////////////

//    class PktStartSecureTradeClass
//    {
//        public const byte PacketID = 76;
//        public const byte PacketLength = 21 + 1;       // + 1 for crc

//        public int RecvCount;

//        public byte[] dataBuffer;


//        // packet data
//        public string Name;         // 20



//        public PktStartSecureTradeClass()
//        {
//            dataBuffer = new byte[PacketLength];
//        }


//        public bool Recv()
//        {
//            dataBuffer[0] = PacketID;

//            Name = System.Text.Encoding.UTF8.GetString(dataBuffer, 1, 20);

//            byte crc = dataBuffer[21];
//            dataBuffer[21] = 0;

//            return crc == MiscClass.CalcCheckSum(dataBuffer);
//        }
//    }

//    /////////////////////////////////////////////////

//    class PktSecureTradeClass
//    {
//        public const byte PacketID = 75;
//        public const byte PacketLength = 30 + 1;       // + 1 for crc

//        public int RecvCount;

//        public byte[] dataBuffer;


//        //' Action = 0 -> cancel, 1 -> accept, 2 -> success
//        //' Action = 10 -> player trade add, 11 -> player trade remove, 12 -> player trade update
//        //' Action = 20 -> other trade add, 21 -> other trade remove, 22 -> other trade update
//        //' Action = 30 -> player inv add, 31 -> player inv remove, 32 -> player inv update

//        // packet data
//        public byte Action;
//        public short ItemID;
//        public byte MagicDamage;
//        public byte Quality;
//        public byte SpellID;
//        public byte CarryIndex;
//        public int Value;
//        public byte SkillID;
//        public short SkillValue;
//        public int Quantity;
//        public byte SpellValue;


//        public PktSecureTradeClass()
//        {
//            dataBuffer = new byte[PacketLength];
//        }


//        public bool Recv()
//        {
//            dataBuffer[0] = PacketID;


//            Action = dataBuffer[1];
//            ItemID = BitConverter.ToInt16(dataBuffer, 2);
//            MagicDamage = dataBuffer[4];
//            Quality = dataBuffer[5];
//            SpellID = dataBuffer[6];
//            CarryIndex = dataBuffer[7];
//            Value = BitConverter.ToInt32(dataBuffer, 8);
//            SkillID = dataBuffer[17];
//            SkillValue = BitConverter.ToInt16(dataBuffer, 18);
//            Quantity = BitConverter.ToInt32(dataBuffer, 20);
//            SpellValue = dataBuffer[29];


//            byte crc = dataBuffer[30];
//            dataBuffer[30] = 0;

//            return crc == MiscClass.CalcCheckSum(dataBuffer);
//        }
//    }

//    /////////////////////////////////////////////////

//    class PktEventClass
//    {
//        public const byte PacketID = 33;
//        public const byte PacketLength = 7 + 1;       // + 1 for crc

//        public int RecvCount;

//        public byte[] dataBuffer;

//        /*
//        Enum PktEventEnum
//            peeMoveResult
//            peeAttackResult        ' attacker rcv after an attack attempt, data1 is T/F for success, data2 is target pindex
//            peeDefendResult        ' defender rcv after an attack on them, data1 is T/F, data2 is attacker pindex
//            peeItemMoveResult      ' fail or success
//            peeDeath               ' player died, show animation?
//        End Enum
//        */

//        // packet data
//        public byte Event;
//        public byte Xpos;
//        public byte Ypos;
//        public byte Result;
//        public byte Data1;
//        public byte Data2;


//        public PktEventClass()
//        {
//            dataBuffer = new byte[PacketLength];
//        }


//        public bool Recv()
//        {
//            dataBuffer[0] = PacketID;

//            Event = dataBuffer[1];
//            Xpos = dataBuffer[2];
//            Ypos = dataBuffer[3];
//            Result = dataBuffer[4];
//            Data1 = dataBuffer[5];
//            Data2 = dataBuffer[6];

//            byte crc = dataBuffer[7];
//            dataBuffer[7] = 0;

//            return crc == MiscClass.CalcCheckSum(dataBuffer);
//        }
//    }

//    /////////////////////////////////////////////////

//    class PktResultClass
//    {
//        public const byte PacketID = 102;
//        public const byte PacketLength = 10 + 1;       // + 1 for crc

//        public int RecvCount;

//        public byte[] dataBuffer;

//        /*
//' Catagory:
//' 1 = new mail : result = true/false : data1 = new count
//' 2 = delete mail : result = true/false : data1 = MailIndex
//' 3 = carry item qty update : result = carryindex : data1 = qty
//' 4 = carry item delete : result = carryindex
//' 5 = map light mode : result = 0(follow sun/time), 1(underground) : data1 = zpos
//' 6 = UUID name request : result = 0(deleted), data1=UUID
//        */

//        // packet data
//        public byte Catagory;
//        public int Result;
//        public int Data1;


//        public PktResultClass()
//        {
//            dataBuffer = new byte[PacketLength];
//        }


//        public bool Recv()
//        {
//            dataBuffer[0] = PacketID;

//            Catagory = dataBuffer[1];
//            Result = BitConverter.ToInt32(dataBuffer, 2);
//            Data1 = BitConverter.ToInt32(dataBuffer, 6);

//            byte crc = dataBuffer[10];
//            dataBuffer[10] = 0;

//            return crc == MiscClass.CalcCheckSum(dataBuffer);
//        }
//    }

//    /////////////////////////////////////////////////

//    class PktAnimationClass
//    {
//        public const byte PacketID = 35;
//        public const byte PacketLength = 31 + 1;       // + 1 for crc

//        public int RecvCount;

//        public byte[] dataBuffer;

//        /*
//Enum pktAnimationEnum
//    paeAttack = 1
//    paeDefend = 2
//    paeWarpIn = 3
//    paeWarpOut = 4
//    paeHeal = 5
//    paeRevive = 6
//    paeLevelUp = 7
//    paeBlackHole = 8
//    paeLightning = 9
//    paeIceSpell = 10
//    paeNovaSpell = 11
//    paeBlueBubble = 12
//    paeHeroSpell = 13
//    paeBlueFlash = 14
//    paeRedBubble = 15
//    paeFlame = 16
//    paeBlueOval = 17
//    paeTrap = 18
//    paeFizzle = 19
//    paeFrost = 20
//    paeBlade = 21
//End Enum
//        */

//        // packet data
//        public byte Image;
//        public short Xpos;
//        public short Ypos;
//        public string Sound;        // 20
//        public byte WaitCount;


//        public PktAnimationClass()
//        {
//            dataBuffer = new byte[PacketLength];
//        }


//        public bool Recv()
//        {
//            dataBuffer[0] = PacketID;

//            Image = dataBuffer[1];
//            Xpos = BitConverter.ToInt16(dataBuffer, 2);
//            Ypos = BitConverter.ToInt16(dataBuffer, 6);

//            Sound = System.Text.Encoding.UTF8.GetString(dataBuffer, 10, 20);

//            WaitCount = dataBuffer[30];

//            byte crc = dataBuffer[31];
//            dataBuffer[31] = 0;

//            return crc == MiscClass.CalcCheckSum(dataBuffer);
//        }
//    }

//    /////////////////////////////////////////////////

//    class PktAnimation2Class
//    {
//        public const byte PacketID = 70;
//        public const byte PacketLength = 7 + 1;       // + 1 for crc

//        public int RecvCount;

//        public byte[] dataBuffer;

//        // packet data
//        public short AnimationID;
//        public short Xpos;
//        public short Ypos;


//        public PktAnimation2Class()
//        {
//            dataBuffer = new byte[PacketLength];
//        }


//        public bool Recv()
//        {
//            dataBuffer[0] = PacketID;

//            AnimationID = BitConverter.ToInt16(dataBuffer, 1);
//            Xpos = BitConverter.ToInt16(dataBuffer, 3);
//            Ypos = BitConverter.ToInt16(dataBuffer, 5);

//            byte crc = dataBuffer[7];
//            dataBuffer[7] = 0;

//            return crc == MiscClass.CalcCheckSum(dataBuffer);
//        }
//    }

//    /////////////////////////////////////////////////

//    class PktProjectileClass
//    {
//        public const byte PacketID = 74;
//        public const byte PacketLength = 11 + 1;       // + 1 for crc

//        public int RecvCount;

//        public byte[] dataBuffer;

//        // packet data
//        public short AnimationID;
//        public short XposStart;
//        public short YposStart;
//        public short XposStop;
//        public short YposStop;


//        public PktProjectileClass()
//        {
//            dataBuffer = new byte[PacketLength];
//        }


//        public bool Recv()
//        {
//            dataBuffer[0] = PacketID;

//            AnimationID = BitConverter.ToInt16(dataBuffer, 1);
//            XposStart = BitConverter.ToInt16(dataBuffer, 3);
//            YposStart = BitConverter.ToInt16(dataBuffer, 5);
//            XposStop = BitConverter.ToInt16(dataBuffer, 7);
//            YposStop = BitConverter.ToInt16(dataBuffer, 9);

//            byte crc = dataBuffer[11];
//            dataBuffer[11] = 0;

//            return crc == MiscClass.CalcCheckSum(dataBuffer);
//        }
//    }

//    /////////////////////////////////////////////////

//    class PktPlayerInfoClass
//    {
//        public const byte PacketID = 45;
//        public const byte PacketLength = 69 + 1;       // + 1 for crc

//        public int RecvCount;

//        public byte[] dataBuffer;

//        // packet data
//        public string Name;         // 50
//        public short Level;
//        public byte LifePercent;
//        public byte StaminaPercent;
//        public byte ManaPercent;
//        public byte Image;
//        public short Strength;
//        public short Dexterity;
//        public short Quickness;
//        public short Intelligence;
//        public short Wisdom;
//        public byte Poison;
//        public byte Vitae;



//        public PktPlayerInfoClass()
//        {
//            dataBuffer = new byte[PacketLength];
//        }


//        public bool Recv()
//        {
//            dataBuffer[0] = PacketID;

//            Name = System.Text.Encoding.UTF8.GetString(dataBuffer, 1, 50);

//            Level = BitConverter.ToInt16(dataBuffer, 51);
//            LifePercent = dataBuffer[53];
//            StaminaPercent = dataBuffer[54];
//            ManaPercent = dataBuffer[55];
//            Image = dataBuffer[56];

//            Strength = BitConverter.ToInt16(dataBuffer, 57);
//            Dexterity = BitConverter.ToInt16(dataBuffer, 59);
//            Quickness = BitConverter.ToInt16(dataBuffer, 61);
//            Intelligence = BitConverter.ToInt16(dataBuffer, 63);
//            Wisdom = BitConverter.ToInt16(dataBuffer, 65);

//            Poison = dataBuffer[67];
//            Vitae = dataBuffer[68];


//            byte crc = dataBuffer[69];
//            dataBuffer[69] = 0;

//            return crc == MiscClass.CalcCheckSum(dataBuffer);
//        }
//    }

//    /////////////////////////////////////////////////

//    class PktPlayerInfo2Class
//    {
//        public const byte PacketID = 52;
//        public const byte PacketLength = 165 + 1;       // + 1 for crc

//        public int RecvCount;

//        public byte[] dataBuffer;

//        // packet data
//        public string Name;         // 50
//        public short Level;
//        public short Life;
//        public short Stamina;
//        public short Mana;

//        public short MeleeAttack;
//        public short MeleeDefense;
//        public short MagicDefense;
//        public short MagicAttack;
//        public short MissleAttack;
//        public short MissleDefense;

//        public string Guild;        // 30

//        public short WeaponID;
//        public short ArmorID;
//        public short SheildID;
//        public short HeadID;
//        public short LegID;

//        public byte flgPK;
//        public short Image;

//        public string Owner;        // 50



//        public PktPlayerInfo2Class()
//        {
//            dataBuffer = new byte[PacketLength];
//        }


//        public bool Recv()
//        {
//            dataBuffer[0] = PacketID;

//            Name = System.Text.Encoding.UTF8.GetString(dataBuffer, 1, 50);

//            Level = BitConverter.ToInt16(dataBuffer, 51);
//            Life = BitConverter.ToInt16(dataBuffer, 53);
//            Stamina = BitConverter.ToInt16(dataBuffer, 55);
//            Mana = BitConverter.ToInt16(dataBuffer, 57);


//            MeleeAttack = BitConverter.ToInt16(dataBuffer, 60);
//            MeleeDefense = BitConverter.ToInt16(dataBuffer, 62);
//            MagicDefense = BitConverter.ToInt16(dataBuffer, 64);
//            MagicAttack = BitConverter.ToInt16(dataBuffer, 66);
//            MissleAttack = BitConverter.ToInt16(dataBuffer, 68);
//            MissleDefense = BitConverter.ToInt16(dataBuffer, 70);

//            Guild = System.Text.Encoding.UTF8.GetString(dataBuffer, 72, 30);

//            WeaponID = BitConverter.ToInt16(dataBuffer, 102);
//            ArmorID = BitConverter.ToInt16(dataBuffer, 104);
//            SheildID = BitConverter.ToInt16(dataBuffer, 106);
//            HeadID = BitConverter.ToInt16(dataBuffer, 108);
//            LegID = BitConverter.ToInt16(dataBuffer, 110);

//            flgPK = dataBuffer[112];

//            Image = BitConverter.ToInt16(dataBuffer, 113);

//            Owner = System.Text.Encoding.UTF8.GetString(dataBuffer, 115, 50);


//            byte crc = dataBuffer[165];
//            dataBuffer[165] = 0;

//            return crc == MiscClass.CalcCheckSum(dataBuffer);
//        }
//    }

//    /////////////////////////////////////////////////

//    class PktTraderItemClass
//    {
//        public const byte PacketID = 49;
//        public const byte PacketLength = 29 + 1;       // + 1 for crc

//        public int RecvCount;

//        public byte[] dataBuffer;

//        /*
//        ' itemType = 0 -> trader add, 1 -> trader remove, 2 -> trader update
//        ' itemType = 10 -> player add, 11 -> player remove, 12 -> player update
//        */

//        // packet data
//        public byte ItemType;
//        public short ItemID;
//        public byte MagicDamage;
//        public byte Quality;
//        public byte SpellID;
//        public byte CarryIndex;
//        public int Value;
//        public byte SkillID;
//        public short SkillValue;
//        public int Quantity;



//        public PktTraderItemClass()
//        {
//            dataBuffer = new byte[PacketLength];
//        }


//        public bool Recv()
//        {
//            dataBuffer[0] = PacketID;

//            ItemType = dataBuffer[1];
//            ItemID = BitConverter.ToInt16(dataBuffer, 2);
//            MagicDamage = dataBuffer[4];
//            Quality = dataBuffer[5];
//            SpellID = dataBuffer[6];
//            CarryIndex = dataBuffer[7];

//            Value = BitConverter.ToInt32(dataBuffer, 8);
//            SkillID = dataBuffer[17];
//            SkillValue = BitConverter.ToInt16(dataBuffer, 18);
//            Quantity = BitConverter.ToInt32(dataBuffer, 20);


//            byte crc = dataBuffer[29];
//            dataBuffer[29] = 0;

//            return crc == MiscClass.CalcCheckSum(dataBuffer);
//        }
//    }

//    /////////////////////////////////////////////////

//    class PktContainerTextClass
//    {
//        public const byte PacketID = 66;
//        public const byte PacketLength = 228 + 1;       // + 1 for crc

//        public int RecvCount;

//        public byte[] dataBuffer;


//        // packet data
//        public short ContainerIndex;
//        public string Text;


//        public PktContainerTextClass()
//        {
//            dataBuffer = new byte[PacketLength];
//        }


//        public bool Recv()
//        {
//            dataBuffer[0] = PacketID;

//            ContainerIndex = BitConverter.ToInt16(dataBuffer, 1);

//            Text = System.Text.Encoding.UTF8.GetString(dataBuffer, 3, 225);


//            byte crc = dataBuffer[228];
//            dataBuffer[228] = 0;

//            return crc == MiscClass.CalcCheckSum(dataBuffer);
//        }
//    }

//    /////////////////////////////////////////////////

//    class PktGambleClass
//    {
//        public const byte PacketID = 59;
//        public const byte PacketLength = 13 + 1;       // + 1 for crc

//        public int RecvCount;

//        public byte[] dataBuffer;


//        // packet data
//        public byte Slot1;
//        public byte Slot2;
//        public byte Slot3;
//        public int Winnings;


//        public PktGambleClass()
//        {
//            dataBuffer = new byte[PacketLength];
//        }


//        public bool Recv()
//        {
//            dataBuffer[0] = PacketID;

//            Slot1 = dataBuffer[1];
//            Slot2 = dataBuffer[2];
//            Slot3 = dataBuffer[3];
//            Winnings = BitConverter.ToInt32(dataBuffer, 4);


//            byte crc = dataBuffer[29];
//            dataBuffer[29] = 0;

//            return crc == MiscClass.CalcCheckSum(dataBuffer);
//        }
//    }

//    /////////////////////////////////////////////////

//    class PktMailClass
//    {
//        public const byte PacketID = 77;
//        public const short PacketLength = 295 + 1;       // + 1 for crc

//        public int RecvCount;

//        public byte[] dataBuffer;


//        // packet data
//        public string Subject;      // 30
//        public byte flgNew;
//        public DateTime SendRealDate;
//        public string FromName;      // 50
//        public string Text;         // 200
//        public int MailIndex;



//        public PktMailClass()
//        {
//            dataBuffer = new byte[PacketLength];
//        }


//        public bool Recv()
//        {
//            dataBuffer[0] = PacketID;

//            Subject = System.Text.Encoding.UTF8.GetString(dataBuffer, 1, 30);

//            flgNew = dataBuffer[31];

//            //SendRealDate = BitConverter.ToInt64(dataBuffer, 32);      // how to convert???
//            SendRealDate = DateTime.Now;

//            FromName = System.Text.Encoding.UTF8.GetString(dataBuffer, 41, 50);

//            Text = System.Text.Encoding.UTF8.GetString(dataBuffer, 91, 200);

//            MailIndex = BitConverter.ToInt32(dataBuffer, 291);


//            byte crc = dataBuffer[295];
//            dataBuffer[295] = 0;

//            return crc == MiscClass.CalcCheckSum(dataBuffer);
//        }
//    }

//    /////////////////////////////////////////////////

//    class PktSpellDefClass
//    {
//        public const byte PacketID = 61;
//        public const byte PacketLength = 154 + 1;       // + 1 for crc

//        public int RecvCount;

//        public byte[] dataBuffer;


//        // packet data
//        public short SpellID;
//        public short ManaCost;
//        public byte Target;
//        public byte Range;
//        public byte LOS;
//        public string Name;     // 30
//        public string Description;      // 100
//        public byte Found;
//        public short Rune1;
//        public short Rune2;
//        public short Rune3;
//        public short Rune4;
//        public short Rune5;



//        public PktSpellDefClass()
//        {
//            dataBuffer = new byte[PacketLength];
//        }


//        public bool Recv()
//        {
//            dataBuffer[0] = PacketID;

//            SpellID = BitConverter.ToInt16(dataBuffer, 1);
//            ManaCost = BitConverter.ToInt16(dataBuffer, 8);

//            Target = dataBuffer[10];
//            Range = dataBuffer[11];

//            LOS = dataBuffer[12];

//            Name = System.Text.Encoding.UTF8.GetString(dataBuffer, 13, 30);
//            Description = System.Text.Encoding.UTF8.GetString(dataBuffer, 43, 100);

//            Found = dataBuffer[143];

//            Rune1 = BitConverter.ToInt16(dataBuffer, 144);
//            Rune2 = BitConverter.ToInt16(dataBuffer, 146);
//            Rune3 = BitConverter.ToInt16(dataBuffer, 148);
//            Rune4 = BitConverter.ToInt16(dataBuffer, 150);
//            Rune5 = BitConverter.ToInt16(dataBuffer, 152);


//            byte crc = dataBuffer[154];
//            dataBuffer[154] = 0;

//            return crc == MiscClass.CalcCheckSum(dataBuffer);
//        }
//    }

//    /////////////////////////////////////////////////

//    class PktISOMapLineDataClass
//    {
//        public const byte PacketID = 107;
//        public const short PacketLength = 50 + 1;       // + 1 for crc

//        public int RecvCount;

//        public byte[] dataBuffer;


//        // packet data
//        public byte MapLocation;
//        public byte[] Height = new byte[24];
//        public byte[] Surface = new byte[24];


//        public PktISOMapLineDataClass()
//        {
//            dataBuffer = new byte[PacketLength];
//        }


//        public bool Recv()
//        {
//            dataBuffer[0] = PacketID;

//            MapLocation = dataBuffer[1];

//            for (int i = 0; i < 24; i++)
//            {
//                Height[i] = dataBuffer[2 + i * 2];
//                Surface[i] = dataBuffer[2 + i * 2 + 1];
//            }

//            byte crc = dataBuffer[50];
//            dataBuffer[50] = 0;

//            return crc == MiscClass.CalcCheckSum(dataBuffer);
//        }
//    }

//    /////////////////////////////////////////////////

//    class PktMovePlayerClass
//    {
//        public const byte PacketID = 14;
//        public const byte PacketLength = 3;

//        public byte[] dataBuffer;


//        // packet data
//        public byte Direction;
//        public byte ViewOffset;



//        public PktMovePlayerClass(byte inDirection, byte inViewOffset)
//        {
//            dataBuffer = new byte[PacketLength];

//            Direction = inDirection;
//            ViewOffset = inViewOffset;
//        }

//        public byte[] GetData()
//        {
//            dataBuffer = new byte[PacketLength];

//            dataBuffer[0] = PacketID;

//            dataBuffer[1] = Direction;
//            dataBuffer[2] = ViewOffset;

//            return dataBuffer;
//        }
//    }

//    /////////////////////////////////////////////////

//    class PktAttackClass
//    {
//        public const byte PacketID = 30;
//        public const byte PacketLength = 3;

//        public byte[] dataBuffer;


//        // packet data
//        public short PlayerIndex;


//        public PktAttackClass(short inPlayerIndex)
//        {
//            dataBuffer = new byte[PacketLength];

//            PlayerIndex = inPlayerIndex;
//        }

//        public byte[] GetData()
//        {
//            dataBuffer = new byte[PacketLength];

//            dataBuffer[0] = PacketID;

//            BitConverter.GetBytes(PlayerIndex).CopyTo(dataBuffer, 1);

//            return dataBuffer;
//        }
//    }

//    /////////////////////////////////////////////////

//    class PktRaiseAttributeClass
//    {
//        public const byte PacketID = 31;
//        public const byte PacketLength = 2;

//        public byte[] dataBuffer;

//        /*
//        Public Enum PktRaiseAttributeEnum
//            pralife
//            prastamina
//            praMana
//            praStrength
//            praDexterity
//            praQuickness
//            praIntelligence
//            praWisdom
//        End Enum
//        */

//        // packet data
//        public byte Attrib;


//        public PktRaiseAttributeClass(byte inAttrib)
//        {
//            dataBuffer = new byte[PacketLength];

//            Attrib = inAttrib;
//        }

//        public byte[] GetData()
//        {
//            dataBuffer = new byte[PacketLength];

//            dataBuffer[0] = PacketID;

//            dataBuffer[1] = Attrib;

//            return dataBuffer;
//        }
//    }

//    /////////////////////////////////////////////////

//    class PktDeleteClass
//    {
//        public const byte PacketID = 9;
//        public const byte PacketLength = 51;

//        public byte[] dataBuffer;


//        // packet data
//        public string PlayerName;


//        public PktDeleteClass()
//        {
//            dataBuffer = new byte[PacketLength];
//        }

//        public byte[] GetData()
//        {
//            dataBuffer = new byte[PacketLength];

//            dataBuffer[0] = PacketID;

//            if (PlayerName != null)
//            {
//                System.Text.Encoding.UTF8.GetBytes(PlayerName).CopyTo(dataBuffer, 1);
//            }

//            return dataBuffer;
//        }
//    }

//    /////////////////////////////////////////////////

//    class PktMoveItemClass
//    {
//        public const byte PacketID = 40;
//        public const byte PacketLength = 30;

//        public byte[] dataBuffer;

//        //' ID, xxx(2), pIndex, xpos, ypos, zpos, type(of move), new iindex(9), qty(9)

//        // packet data
//        public short pIndex;
//        public short Xpos;
//        public short Ypos;
//        public short Zpos;
//        public byte MoveType;
//        public int iIndex;
//        public int Qty;


//        public PktMoveItemClass(short _pIndex, short _Xpos, short _Ypos, short _Zpos, byte _MoveType, int _iIndex, int _Qty)
//        {
//            dataBuffer = new byte[PacketLength];

//            pIndex = _pIndex;
//            Xpos = _Xpos;
//            Ypos = _Ypos;
//            Zpos = _Zpos;
//            MoveType = _MoveType;
//            iIndex = _iIndex;
//            Qty = _Qty;
//        }

//        public byte[] GetData()
//        {
//            dataBuffer = new byte[PacketLength];

//            dataBuffer[0] = PacketID;

//            BitConverter.GetBytes(pIndex).CopyTo(dataBuffer, 3);

//            BitConverter.GetBytes(Xpos).CopyTo(dataBuffer, 5);
//            BitConverter.GetBytes(Ypos).CopyTo(dataBuffer, 7);
//            BitConverter.GetBytes(Zpos).CopyTo(dataBuffer, 9);

//            dataBuffer[11] = MoveType;

//            BitConverter.GetBytes(iIndex).CopyTo(dataBuffer, 12);

//            BitConverter.GetBytes(Qty).CopyTo(dataBuffer, 21);

//            return dataBuffer;
//        }
//    }

//    /////////////////////////////////////////////////

//    class PktUseItemClass
//    {
//        public const byte PacketID = 42;
//        public const byte PacketLength = 34;

//        public byte[] dataBuffer;

//        //' ID, iindex(9), usetype(1), iIndex2(9), useID(2), xpos(2), ypos(2), data1(2), data2(2), data3(2), data4(2)

//        // usetype
//        // 0 - eat
//        // 1 - merge/stack carry items
//        // 2 - split carry item
//        // 3 - auto-stack
//        // 10 - use player item on map item
//        // 20 - use player item on empty map
//        // 30 - use player item on player item
//        // 40 - use hand on map item
//        // 50 - use hand on player item
//        // 60 - use hand on slot machine/gamble
//        // 70 - use player item on player

//        // packet data
//        public int ItemIndex;
//        public byte UseType;
//        public int ItemIndex2;
//        public short UseID;
//        public short Xpos;
//        public short Ypos;
//        public short Data1;
//        public short Data2;
//        public short Data3;
//        public short Data4;


//        public PktUseItemClass(int _ItemIndex, byte _UseType, int _ItemIndex2, short _UseID, short _Xpos, short _Ypos, short _Data1, short _Data2, short _Data3, short _Data4)
//        {
//            dataBuffer = new byte[PacketLength];

//            ItemIndex = _ItemIndex;
//            UseType = _UseType;
//            ItemIndex2 = _ItemIndex2;
//            UseID = _UseID;
//            Xpos = _Xpos;
//            Ypos = _Ypos;
//            Data1 = _Data1;
//            Data2 = _Data2;
//            Data3 = _Data3;
//            Data4 = _Data4;
//        }

//        public byte[] GetData()
//        {
//            dataBuffer = new byte[PacketLength];

//            dataBuffer[0] = PacketID;

//            BitConverter.GetBytes(ItemIndex).CopyTo(dataBuffer, 1);

//            dataBuffer[10] = UseType;

//            BitConverter.GetBytes(ItemIndex2).CopyTo(dataBuffer, 11);

//            BitConverter.GetBytes(UseID).CopyTo(dataBuffer, 20);

//            BitConverter.GetBytes(Xpos).CopyTo(dataBuffer, 22);
//            BitConverter.GetBytes(Ypos).CopyTo(dataBuffer, 24);

//            BitConverter.GetBytes(Data1).CopyTo(dataBuffer, 26);
//            BitConverter.GetBytes(Data2).CopyTo(dataBuffer, 28);
//            BitConverter.GetBytes(Data3).CopyTo(dataBuffer, 30);
//            BitConverter.GetBytes(Data4).CopyTo(dataBuffer, 32);

//            return dataBuffer;
//        }
//    }

//    /////////////////////////////////////////////////

//    class PktTrainSkillClass
//    {
//        public const byte PacketID = 39;
//        public const byte PacketLength = 2;

//        public byte[] dataBuffer;


//        // packet data
//        public byte SkillID;


//        public PktTrainSkillClass(byte _SkillID)
//        {
//            dataBuffer = new byte[PacketLength];

//            SkillID = _SkillID;
//        }

//        public byte[] GetData()
//        {
//            dataBuffer = new byte[PacketLength];

//            dataBuffer[0] = PacketID;

//            dataBuffer[1] = SkillID;

//            return dataBuffer;
//        }
//    }

//    /////////////////////////////////////////////////

//    class PktUnTrainSkillClass
//    {
//        public const byte PacketID = 53;
//        public const byte PacketLength = 2;

//        public byte[] dataBuffer;


//        // packet data
//        public byte SkillID;


//        public PktUnTrainSkillClass(byte _SkillID)
//        {
//            dataBuffer = new byte[PacketLength];

//            SkillID = _SkillID;
//        }

//        public byte[] GetData()
//        {
//            dataBuffer = new byte[PacketLength];

//            dataBuffer[0] = PacketID;

//            dataBuffer[1] = SkillID;

//            return dataBuffer;
//        }
//    }

//    /////////////////////////////////////////////////

//    class PktWaterClass
//    {
//        public const byte PacketID = 108;
//        public const byte PacketLength = 4 + 1;       // + 1 for crc

//        public int RecvCount;

//        public byte[] dataBuffer;


//        // packet data
//        public byte Xpos;
//        public byte Ypos;
//        public byte Depth;


//        public PktWaterClass()
//        {
//            dataBuffer = new byte[PacketLength];
//        }


//        public bool Recv()
//        {
//            dataBuffer[0] = PacketID;

//            Xpos = dataBuffer[1];
//            Ypos = dataBuffer[2];
//            Depth = dataBuffer[3];


//            byte crc = dataBuffer[4];
//            dataBuffer[4] = 0;

//            return crc == MiscClass.CalcCheckSum(dataBuffer);
//        }
//    }

//    /////////////////////////////////////////////////

//}
