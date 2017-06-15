using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaHeroPicker.Statistics
{
    public class DotaPlayerStatisticsWorker : IDotaPlayerStatisticsWorker
    {
        #region Constructors

        private DotaPlayerStatisticsWorker() { }

        #endregion

        #region IDotaPlayerStatisticsWorker Members

        public event EventHandler<List<IDotaPlayerStatistics>> DotaPlayersStatisticsReceived;

        public void StartGettingDotaPlayersStatistics()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
