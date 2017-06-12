using DotaHeroPicker.ServerLog;

namespace DotaHeroPicker.Statistics
{
    public interface IDotaPlayerStatistics
    {
        IDotaPlayer Player { get; }
        IDotaWinning Winning { get; }
    }
}
