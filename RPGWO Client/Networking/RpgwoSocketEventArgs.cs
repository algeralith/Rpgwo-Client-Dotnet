using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using RPGWO_Client.Networking.Packets;
using RPGWO_Client.Networking;

namespace RPGWO_Client.Networking
{
    public class RpgwoSocketEventArgs : SocketAsyncEventArgs
    {
        public Packet Packet { get; set; }

        public int TotalReceived { get; set; }

        public SendReceiveMode SendMode { get; set; }

        public SendReceiveMode ReceiveMode { get; set; }
    }
}
