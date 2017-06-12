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
        #region Constructors

        public UnknowDotaPlayerStatistics(IDotaPlayer player)
        {
            Player = player;
        }

        #endregion

        #region IDotaPlayerStatistics Members

        public IDotaPlayer Player { get; private set; }
        public IDotaWinning Winning { get; private set; }

        #endregion

    }
}
