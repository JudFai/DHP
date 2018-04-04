using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDota
{
    /// <summary>
    /// Статистика побед и матчей героя
    /// </summary>
    interface IHeroWinrate
    {
        /// <summary>
        /// ID-героя
        /// </summary>
        int HeroID { get; set; }
        /// <summary>
        /// Количество матчей
        /// </summary>
        int Matches { get; set; }
        /// <summary>
        /// Количество побед
        /// </summary>
        int Wins { get; set; }
    }
}
