using DotaHeroPicker.Types;

namespace DotaHeroPicker.Statistics
{
    public interface IDotaHeroStatistics
    {
        DotaHero Hero { get; }
        IDotaWinning Winning { get; }
    }
}
