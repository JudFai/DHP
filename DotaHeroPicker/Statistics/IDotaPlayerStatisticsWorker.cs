using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaHeroPicker.Statistics
{
    public interface IDotaPlayerStatisticsWorker : IDisposable
    {
        List<IDotaPlayerStatistics> LastReceviedDotaPlayerStatisticsCollection { get; }
        event EventHandler<List<IDotaPlayerStatistics>> DotaPlayersStatisticsReceived;
        event EventHandler<bool> ReceivingDotaPlayersStatistics;
        void StartGettingDotaPlayersStatistics();
    }
}
