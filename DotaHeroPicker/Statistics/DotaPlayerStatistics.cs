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

        public DotaPlayerStatistics(IDotaWinning winning, IDotaPlayer player)
        {
            Winning = winning;
            Player = player;
        }

        #endregion

        #region Public Methods

        public static IDotaPlayerStatistics CreateEmptyDotaPlayerStatistics(IDotaPlayer player)
        {
            return new UnknowDotaPlayerStatistics(player);
        }

        #endregion

        #region IDotaPlayerStatistics Members

        public IDotaPlayer Player { get; private set; }
        public IDotaWinning Winning { get; private set; }

        #endregion
    }
}
