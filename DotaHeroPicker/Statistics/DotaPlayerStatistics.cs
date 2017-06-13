using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaHeroPicker.ServerLog;
using DotaHeroPicker.Types;

namespace DotaHeroPicker.Statistics
{
    class DotaPlayerStatistics : IDotaPlayerStatistics
    {
        #region Constructors

        public DotaPlayerStatistics(IDotaWinning winning, IDotaPlayer player, string nickname, List<IDotaHeroStatistics> favoriteHeroes)
        {
            Winning = winning;
            Player = player;
            Nickname = nickname;
            FavoriteHeroes = favoriteHeroes;
        }

        #endregion

        #region Public Methods

        public static IDotaPlayerStatistics CreateEmptyDotaPlayerStatistics(IDotaPlayer player)
        {
            return new UnknowDotaPlayerStatistics(player);
        }

        public override string ToString()
        {
            return string.Format("{0}: {1} {2}", 
                Nickname, Player.ID, Winning);
        }

        #endregion

        #region IDotaPlayerStatistics Members

        public IDotaPlayer Player { get; private set; }
        public IDotaWinning Winning { get; private set; }
        public List<IDotaHeroStatistics> FavoriteHeroes { get; private set; }
        //public List<DotaHero> FavoriteHeroes { get; private set; }
        public string Nickname { get; private set; }

        #endregion
    }
}
