using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaHeroPicker.ServerLog;

namespace DotaHeroPicker.Statistics
{
    class UnknowDotaPlayerStatistics : IDotaPlayerStatistics
    {
        #region Cocnstructors

        public UnknowDotaPlayerStatistics(IDotaPlayer player)
        {
            Player = player;
        }

        #endregion

        #region IDotaPlayerStatistics Members

        public IDotaPlayer Player { get; private set; }
        public double WinningPercentage { get; private set; }

        #endregion

    }
}
