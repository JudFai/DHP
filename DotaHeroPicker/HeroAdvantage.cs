using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaHeroPicker.Types;

namespace DotaHeroPicker
{
    public class HeroAdvantage
    {
        #region Properties

        public DotaHero Hero { get; private set; }
        public ReadOnlyCollection<EnemyHeroAdvantage> EnemyHeroAdvantageCollection { get; private set; }
        public ReadOnlyCollection<AlliedHeroAdvantage> AlliedHeroAdvantageCollection { get; private set; }

        #endregion

        #region Constrcutors

        public HeroAdvantage(DotaHero hero, IList<EnemyHeroAdvantage> enemyHeroAdvantageCollection)
        {
            if (enemyHeroAdvantageCollection.Any(p => p.Hero == hero))
                throw new Exception("The hero can not be the enemy hero");

            Hero = hero;
            EnemyHeroAdvantageCollection = new ReadOnlyCollection<EnemyHeroAdvantage>(enemyHeroAdvantageCollection);
        }

        public HeroAdvantage(DotaHero hero, IList<EnemyHeroAdvantage> enemyHeroAdvantageCollection, IList<AlliedHeroAdvantage> alliedHeroAdvantageCollection)
        {
            if (enemyHeroAdvantageCollection.Any(p => p.Hero == hero))
                throw new Exception("The hero can not be the enemy hero");

            Hero = hero;
            EnemyHeroAdvantageCollection = new ReadOnlyCollection<EnemyHeroAdvantage>(enemyHeroAdvantageCollection);
            AlliedHeroAdvantageCollection = new ReadOnlyCollection<AlliedHeroAdvantage>(alliedHeroAdvantageCollection);
        }

        public HeroAdvantage(DotaHero hero, IList<AlliedHeroAdvantage> alliedHeroAdvantageCollection)
        {
            Hero = hero;
            AlliedHeroAdvantageCollection = new ReadOnlyCollection<AlliedHeroAdvantage>(alliedHeroAdvantageCollection);
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return string.Format("Hero: {0}", Hero.DotaName.FullName);
        }

        #endregion
    }
}
