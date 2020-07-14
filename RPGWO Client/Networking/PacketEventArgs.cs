using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGWO_Client.Networking.Packets;

namespace RPGWO_Client.Networking
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
