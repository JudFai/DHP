using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaHeroPicker.Statistics
{
    public interface IDotaPlayerStatisticsWorker : IDisposable
    {
        event EventHandler<List<IDotaPlayerStatistics>> DotaPlayersStatisticsReceived;
        void StartGettingDotaPlayersStatistics();
    }
}
