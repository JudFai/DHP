using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDota
{
    interface IDataExplorer
    {
        /// <summary>
        /// Возвращает соотношения героя к герою-врагу.
        /// </summary>
        /// <remarks>Разница между</remarks>
        /// <param name="beginDt" >Дата начала</param>
        /// <param name="endDt">Дата конца</param>
        /// <returns>Возвращает соотношения героя к герою-врагу</returns>
        List<IHeroRatio> GetHeroEnemyRatioCollection(DateTime beginDt, DateTime endDt);
        /// <summary>
        /// Возвращает статистику игроков по играм и победам
        /// </summary>
        /// <param name="beginDt">Дата начала</param>
        /// <param name="endDt">Дата конца</param>
        List<IHeroWinrate> GetHeroWinrateCollection(DateTime beginDt, DateTime endDt);
        /// <summary>
        /// Возвращает матчи игрока
        /// </summary>
        /// <param name="playerId">Идентификатор игрока</param>
        /// <returns>Матчи игрока</returns>
        List<IPlayerMatch> GetPlayerMatchCollection(ulong playerId);
    }
}
