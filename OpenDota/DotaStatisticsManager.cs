using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDota
{
    public class DotaStatisticsManager : IDotaStatisticsManager
    {
        #region Fields

        private readonly static object _instanceLocker = new object();
        private static IDotaStatisticsManager _instance;

        #endregion

        #region Properties

        internal IDataExplorer DataExplorer { get; set; }

        public static IDotaStatisticsManager Instance
        {
            get
            {
                lock (_instanceLocker)
                {
                    return _instance ??
                           (_instance = new DotaStatisticsManager());
                }
            }
        }

        #endregion

        #region Consturctors

        private DotaStatisticsManager()
        {
            DataExplorer = new DataExplorer();
        }

        #endregion

        #region IDotaStatisticsManager Members

        public List<IPlayerMatch> GetJoinMatchesOfPlayers(ulong player1, ulong player2)
        {
            var matchesPlayer1 = DataExplorer.GetPlayerMatchCollection(player1);
            var matchesPlayer2 = DataExplorer.GetPlayerMatchCollection(player2);
            var jointMatches = matchesPlayer1
                .Join(matchesPlayer2, 
                    p1 => p1.MatchID, 
                    p2 => p2.MatchID, 
                    (p1, p2) => new
                    {
                        Player1 = p1, 
                        Player2 = p2
                    });

        }

        public List<IHeroAdvantage> GetHeroAdvantageEnemyCollection(DateTime begin, DateTime end)
        {
            var heroEnemyRationCollection = DataExplorer.GetHeroEnemyRatioCollection(begin, end);
            var heroWinrateCollection = DataExplorer.GetHeroWinrateCollection(begin, end);
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
