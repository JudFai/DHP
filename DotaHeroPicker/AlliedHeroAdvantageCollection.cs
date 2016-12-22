using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaHeroPicker.Types;

namespace DotaHeroPicker
{
    public class AlliedHeroAdvantageCollection
    {
        #region Properties

        public ReadOnlyCollection<AlliedHeroAdvantage> AlliedHeroAdvantage { get; private set; }

        public DotaHero Hero { get; private set; }

        public double AdvantageValue { get; private set; }

        //public bool ContainsNegativeAdvantage { get; private set; }

        #endregion

        #region Constructors

        public AlliedHeroAdvantageCollection(DotaHero hero, IList<AlliedHeroAdvantage> alliedTeamAdvantage)
        {
            if (alliedTeamAdvantage.Any(p => p.Hero == hero))
                throw new Exception("The hero can not be the enemy team");

            AlliedHeroAdvantage = new ReadOnlyCollection<AlliedHeroAdvantage>(alliedTeamAdvantage);
            Hero = hero;
            AdvantageValue = AlliedHeroAdvantage.Sum(p => p.AdvantageValue);
            //ContainsNegativeAdvantage = EnemyTeamAdvantage.Any(p => p.AdvantageValue < 0);
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return string.Format("{0}: {1:F2}%", Hero, AdvantageValue);
        }

        #endregion
    }
}
