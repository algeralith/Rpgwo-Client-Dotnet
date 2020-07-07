using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGWO_Client.Network.Packets
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
        Enter = 11,
        WorldState = 22,
        PlayerStats = 26,
        ClientList = 29,
        ReqSkillList = 38,
        Text = 41,
        PlayerStats2 = 43,
        RuneBag = 62,
        CreateDef = 65,
        SkillDef = 67,
        ReqSkillDef = 68,
        RandomByte = 73,
        Info2 = 90,
        Ack = 255
    }
}
