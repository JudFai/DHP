using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaHeroPicker.ServerLog;

namespace DotaHeroPicker.Statistics
{
    class DotaPlayerStatistics : IDotaPlayerStatistics
    {
        #region Constructors

        public DotaPlayerStatistics(double winningPercentage, IDotaPlayer player)
        {
            WinningPercentage = winningPercentage;
            Player = player;
        }

        #endregion

        #region IDotaPlayerStatistics Members

        public IDotaPlayer Player { get; private set; }
        public double WinningPercentage { get; private set; }

        #endregion

        #region Public Methods

        public static IDotaPlayerStatistics CreateEmptyDotaPlayerStatistics(IDotaPlayer player)
        {
            return new UnknowDotaPlayerStatistics(player);
        }

        #endregion
    }
}
