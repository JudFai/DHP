using System;
using System.Collections.Generic;

namespace DotaHeroPicker.ServerLog
{
    public interface IDotaLobby
    {
        ulong ID { get; }
        DateTime LoggingTime { get; }
        List<IDotaPlayer> Players { get; }
        IDotaParty Party { get; }
    }
}
