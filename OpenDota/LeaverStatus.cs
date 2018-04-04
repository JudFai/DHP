using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDota
{
    public enum LeaverStatus : byte
    {
        /// <summary>
        /// Finished match, no abandon
        /// </summary>
        None = 0,
        /// <summary>
        /// Player DC, no abandon
        /// </summary>
        Disconnected = 1,
        /// <summary>
        /// Player DC > 5min, abandon
        /// </summary>
        DisconnectedTooLong = 2,
        /// <summary>
        /// Player dc, clicked leave, abandon
        /// </summary>
        Abandoned = 3,
        /// <summary>
        /// Player AFK, abandon
        /// </summary>
        Afk = 4,
        /// <summary>
        /// Never connected, no abandon
        /// </summary>
        NeverConnected = 5,
        /// <summary>
        /// Too long to connect, no abandon
        /// </summary>
        NeverConnectedTooLong = 6
    }
}
