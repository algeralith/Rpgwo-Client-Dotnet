using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGWO_Client.Network.Packets;

namespace RPGWO_Client.Network
{
    public class PacketEventArgs : EventArgs
    {
        public Packet Packet { get; private set; }

        public PacketEventArgs(Packet packet)
        {
            this.Packet = packet;
        }
    }
}
