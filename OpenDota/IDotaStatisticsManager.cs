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
        /// Получает совместные матчи игроков, если такие имеются
        /// </summary>
        /// <param name="player1">ID первого игрока</param>
        /// <param name="player2">ID второго игрока</param>
        /// <returns>Матчи</returns>
        List<IPlayerMatch> GetJoinMatchesOfPlayers(uint player1, uint player2);
    }
}
