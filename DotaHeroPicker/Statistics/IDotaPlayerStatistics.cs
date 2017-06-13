using System.Collections.Generic;
using DotaHeroPicker.ServerLog;
using DotaHeroPicker.Types;

namespace DotaHeroPicker.Statistics
{
    public interface IDotaPlayerStatistics
    {
        IDotaPlayer Player { get; }
        IDotaWinning Winning { get; }
        List<IDotaHeroStatistics> FavoriteHeroes { get; }
        string Nickname { get; }
    }
}
