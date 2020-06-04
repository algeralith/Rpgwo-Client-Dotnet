using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGWO_Client.Network.Packets
{
    public class ClientList : Packet
    {
        public String Name { get; set; }

        public bool ClearList { get; set; }

        public ClientList() : base((byte)PacketTypes.ClientList, 21)
        {

        }

        public override bool Receive()
        {
            Name = ReadString(20);

            return true;
        }
    }
}
