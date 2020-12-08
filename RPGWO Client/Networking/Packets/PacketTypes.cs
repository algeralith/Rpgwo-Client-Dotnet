using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGWO_Client.Networking.Packets
{
    public enum PacketTypes : byte
    {
        Nack = 0,
        Version = 2,
        Login = 4,
        Create = 5,
        ReqPlayerList = 6,
        PlayerList = 7,
        Logout = 8,
        Delete = 9,
        MapData = 10,
        Enter = 11,
        EnterFinal = 12,
        StartDisplay = 15,
        StopDisplay = 16,
        PlayerLocation = 17,
        ItemLocation = 19,
        Event = 21,
        WorldState = 22,
        PlayerStats = 27,
        ClientList = 29,
        Sound = 34,
        Skill = 36,
        Attributes = 37,
        ReqSkillList = 38,
        Text = 41,
        PlayerStats2 = 43,
        SpellDef = 61,
        RuneBag = 62,
        CreateDef = 65,
        SkillDef = 67,
        ReqSkillDef = 68,
        Animation2 = 70,
        MonsterLocation = 72,
        RandomByte = 73,
        Info2 = 90,
        Info3 = 91,
        Result = 102,
        Ack = 255
    }
}
