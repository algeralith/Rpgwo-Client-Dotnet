using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGWO_Client.Network
{
    public enum TextChannels
    {
        LightGrey = 0, // 200, 200, 200 -- Messages sent to client but not 
        Orange = 1, // 230, 145, 0 -- Welcome Ultra Admin! -- Server Welcome Message.
        LightOrange = 2, // 255, 255, 200 -- Last Motd / Post
        White = 3, // 255, 255, 255
        DarkBlue = 4, // 50, 50, 255
        MediumBlue = 5, // 150, 150, 255
        LightBlue = 6, // 200, 200, 255
        Brown = 7, // 191, 161, 109
        Pink = 8, // 245, 184, 205
        Yellow = 9, // 230, 230, 0 -- Battle Text Message.
        TextMsg = 10, // Text Message / Motd box.
        Unknown11 = 11, // Does not seem to be used 
        LightBlue2 = 12, // Same as 6, Light Blue
        DarkGrey = 13, // 150, 150, 150 -- Dark Grey
        DarkGrey2 = 14, // Same as 13
        LightBlue3 = 15, // Same as 6 and 12
        DarkGrey3 = 16
    }
}
