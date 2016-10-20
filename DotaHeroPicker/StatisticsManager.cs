using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaHeroPicker.Types;
using DotaHeroPicker.Collections;

namespace DotaHeroPicker
{
    public class StatisticsManager
    {
        #region Fields

        private readonly DotaHeroCollection _heroCollection = DotaHeroCollection.GetInstance();
        private readonly List<HeroAdvantage> _heroAdvantageCollection;

        #endregion

        #region Constrcutors

        public StatisticsManager(List<HeroAdvantage> heroAdvantageCollection)
        {
            _heroAdvantageCollection = heroAdvantageCollection;
        }

        #endregion

        #region Public Methods

        public List<EnemyHeroAdvantageCollection> GetEnemyTeamAdvantageCollection(List<DotaHero> enemyHeroes, List<DotaHero> alliedHeroes, List<DotaHero> bannedHeroes)
        {
            var col = new List<EnemyHeroAdvantageCollection>();
            // TODO: пита временно
            var filteredHeroCollection = _heroCollection.Except(enemyHeroes).Except(alliedHeroes).Except(bannedHeroes).Except(_heroCollection.Where(p => p.DotaName.Entity == Hero.Underlord));
            foreach (var hero in filteredHeroCollection)
            {
                col.Add(new EnemyHeroAdvantageCollection(hero,
                    _heroAdvantageCollection
                    .FirstOrDefault(p => p.Hero == hero)
                    .EnemyHeroAdvantageCollection
                    .Where(a => enemyHeroes.Contains(a.Hero))
                    .ToList()));
            }

            return col.OrderByDescending(p => p.AdvantageValue).ToList();
        }

        #endregion
    }
}
