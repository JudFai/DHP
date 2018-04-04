using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDota
{
    public interface IDataMath
    {
        /// <summary>
        /// Получить коллекцию преимуществ героев перед героями-врагами
        /// </summary>
        /// <param name="begin">Дата начала</param>
        /// <param name="end">Дата конца</param>
        List<IHeroAdvantage> GetHeroAdvantageEnemyCollection(DateTime begin, DateTime end);
    }
}
