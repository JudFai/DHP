using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDota
{
    public interface IDotaStatisticsManager
    {
        /// <summary>
        /// Возвращает коллекцию совместных матчей игроков, если такие имеются
        /// </summary>
        /// <param name="player1">ID первого игрока</param>
        /// <param name="player2">ID второго игрока</param>
        List<IPlayerMatch> GetJoinMatchesOfPlayers(ulong player1, ulong player2);
        /// <summary>
        /// Возвращает коллекцию преимуществ героев перед героями-врагами
        /// </summary>
        /// <param name="begin">Дата начала</param>
        /// <param name="end">Дата конца</param>
        List<IHeroAdvantage> GetHeroAdvantageEnemyCollection(DateTime begin, DateTime end);
    }
}
