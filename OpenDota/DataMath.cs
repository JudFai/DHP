using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDota
{
    public class DataMath : IDataMath
    {
        #region Fields

        private static readonly object _instanceLocker = new object();
        private static IDataMath _instance;
        private IDataExplorer _dataExplorer = new DataExplorer();

        #endregion

        #region Properties

        public static IDataMath Instance
        {
            get
            {
                lock (_instanceLocker)
                {
                    return _instance ??
                           (_instance = new DataMath());
                }
            }
        }

        #endregion

        #region Constructors

        private DataMath() { }

        #endregion

        #region IDataMath Members

        public List<IHeroAdvantage> GetHeroAdvantageEnemyCollection(DateTime begin, DateTime end)
        {
            var heroEnemyRationCollection = _dataExplorer.GetHeroEnemyRatioCollection(begin, end);
            var heroWinrateCollection = _dataExplorer.GetHeroWinrateCollection(begin, end);
            var heroAdvantageEnemyCollection = heroEnemyRationCollection.Select(p =>
            {
                // TODO: изменить математику
                // TODO: обработать исключение на предмет того, что есть герои с InterplayHeroID = 0
                var heroWinrate = heroWinrateCollection.FirstOrDefault(a => a.HeroID == p.HeroID);
                var enemyWinrate = heroWinrateCollection.FirstOrDefault(a => a.HeroID == p.InterplayHeroID);
                // Вычисляем процент побед для героя и героя-врага
                var p1 = heroWinrate.Wins / (double)heroWinrate.Matches;
                var p2 = enemyWinrate.Wins / (double)enemyWinrate.Matches;
                // Вычисляем процент побед для героя против врага(на основании процента побед героя и героя-врага)
                var mathWinrate = (p1 * (1 - p2)) / (p1 * (1 - p2) + p2 * (1 - p1));
                var statisWinrate = p.Wins / (double)p.Matches;
                // И получаем преимущество героя над героем-врагом
                var advantage = (statisWinrate - mathWinrate) * 100;
                return new HeroAdvantage(p.HeroID, p.InterplayHeroID, p.Matches, advantage);
            }).Cast<IHeroAdvantage>().ToList();
            return heroAdvantageEnemyCollection;
        }

        #endregion
    }
}
