using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaHeroPicker.Statistics
{
    public interface IDotaWinning
    {
        double Percentage { get; }
        TimeSpan Duration { get; }
        int Matches { get; }
        int Wins { get; }
        int Loses { get; }
    }
}
