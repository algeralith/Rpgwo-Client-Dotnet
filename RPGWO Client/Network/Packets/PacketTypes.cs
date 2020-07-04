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
        ReqPlayerList = 6,
        PlayerList = 7,
        ClientList = 29,
        Text = 41,
        SkillDef = 67,
        ReqSkillDef = 68,
        RandomByte = 73,
        Info2 = 90,
        Ack = 255
    }
}
