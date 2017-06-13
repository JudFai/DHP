using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaHeroPicker.ServerLog;
using DotaHeroPicker.Types;

namespace DotaHeroPicker.Statistics
{
    class UnknowDotaPlayerStatistics : IDotaPlayerStatistics
    {
        #region Constructors

        public UnknowDotaPlayerStatistics(IDotaPlayer player)
        {
            Player = player;
            Nickname = "UNKNOW";
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return string.Format("{0}: {1}", Nickname, Player.ID);
        }

        #endregion

        #region IDotaPlayerStatistics Members

        public IDotaPlayer Player { get; private set; }
        public IDotaWinning Winning { get; private set; }
        public List<IDotaHeroStatistics> FavoriteHeroes { get; private set; }
        public string Nickname { get; private set; }

        #endregion

    }
}
