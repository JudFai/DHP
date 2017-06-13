using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaHeroPicker.Types;

namespace DotaHeroPicker.Statistics
{
    class DotaHeroStatistics : IDotaHeroStatistics
    {
        #region Constructors

        public DotaHeroStatistics(IDotaWinning winning, DotaHero hero)
        {
            Winning = winning;
            Hero = hero;
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return string.Format("{0}: {1}", Hero.DotaName.FullName, Winning);
        }

        #endregion

        #region IDotaHeroStatistics Members

        public DotaHero Hero { get; private set; }
        public IDotaWinning Winning { get; private set; }

        #endregion

    }
}
