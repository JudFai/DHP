using System.Collections.Generic;

namespace DotaHeroPicker.ServerLog
{
    public interface IDotaParty
    {
        ulong ID { get; }
        List<IDotaPlayer> Players { get; }
    }
}
