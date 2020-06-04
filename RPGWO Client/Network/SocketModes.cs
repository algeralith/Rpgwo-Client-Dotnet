using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGWO_Client.Network
{
    // Send Mode
    public enum SendMode
    {
        None,
        Checksum,
        ChecksumRnd
    }

    public enum ReceiveMode
    {
        None,
        Checksum,
        ChecksumRnd
    }
}
