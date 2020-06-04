using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGWO_Client.Network.Packets
{
    public sealed class Version : Packet
    {
        public string VersionName = "RPGWO 2";
        public string VersionVersion = "2.14";

        public Version() : base((byte)PacketTypes.Version, 41)
        {

        }

        public override bool Receive()
        {
            throw new NotImplementedException();
        }

        public override byte[] GetBytes()
        {
            AddString(VersionName, 20); // Should be position 1
            AddString(VersionVersion, 20); // Should be position 21

            return buffer;
        } 
    }
}
