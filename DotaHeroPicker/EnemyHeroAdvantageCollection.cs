using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaHeroPicker.Types;

namespace DotaHeroPicker
{
    public class EnemyHeroAdvantageCollection
    {
        #region Properties

        public ReadOnlyCollection<EnemyHeroAdvantage> EnemyHeroAdvantage { get; private set; }

        public DotaHero Hero { get; private set; }

        public double AdvantageValue { get; private set; }

        //public bool ContainsNegativeAdvantage { get; private set; }

        #endregion

        #region Constructors

        public EnemyHeroAdvantageCollection(DotaHero hero, IList<EnemyHeroAdvantage> enemyTeamAdvantage)
        {
            if (enemyTeamAdvantage.Any(p => p.Hero == hero))
                throw new Exception("The hero can not be the enemy team");

            EnemyHeroAdvantage = new ReadOnlyCollection<EnemyHeroAdvantage>(enemyTeamAdvantage);
            Hero = hero;
            AdvantageValue = EnemyHeroAdvantage.Sum(p => p.AdvantageValue);
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
