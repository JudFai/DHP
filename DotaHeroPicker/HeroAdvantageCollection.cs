using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaHeroPicker.Types;

namespace DotaHeroPicker
{
    public class HeroAdvantageCollection
    {
        #region Properties

        public ReadOnlyCollection<AlliedHeroAdvantage> AlliedHeroAdvantage { get; private set; }
        public ReadOnlyCollection<EnemyHeroAdvantage> EnemyHeroAdvantage { get; private set; }

        public DotaHero Hero { get; private set; }

        public double AdvantageValue { get; private set; }

        #endregion

        #region Constructors

        public HeroAdvantageCollection(DotaHero hero, IList<EnemyHeroAdvantage> enemyTeamAdvantage, IList<AlliedHeroAdvantage> alliedTeamAdvantage)
        {
            if (enemyTeamAdvantage.Any(p => p.Hero == hero) || alliedTeamAdvantage.Any(p => p.Hero == hero))
                throw new Exception("The hero can not be the enemy team");

            AlliedHeroAdvantage = new ReadOnlyCollection<AlliedHeroAdvantage>(alliedTeamAdvantage);
            EnemyHeroAdvantage = new ReadOnlyCollection<EnemyHeroAdvantage>(enemyTeamAdvantage);
            Hero = hero;
            AdvantageValue = EnemyHeroAdvantage.Sum(p => p.AdvantageValue) + AlliedHeroAdvantage.Sum(p => p.AdvantageValue);
            //ContainsNegativeAdvantage = EnemyTeamAdvantage.Any(p => p.AdvantageValue < 0);
        }

        #endregion
    }
}
