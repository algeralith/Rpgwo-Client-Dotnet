using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using RPGWO_Client.Network.Packets;
using RPGWO_Client.Network;

namespace RPGWO_Client.Network
{
    public class RpgwoSocketEventArgs : SocketAsyncEventArgs
    {
        public Packet Packet { get; set; }

        public int TotalReceived { get; set; }

        public SendReceiveMode SendMode { get; set; }

        public SendReceiveMode ReceiveMode { get; set; }
    }
}
