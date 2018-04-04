using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDota
{
    /// <summary>
    /// Соотношение героя к герою
    /// </summary>
    interface IHeroRatio
    {
        /// <summary>
        /// ID-героя
        /// </summary>
        int HeroID { get; set; }
        /// <summary>
        /// ID-героя с которым происходит взаимодействие
        /// </summary>
        int InterplayHeroID { get; set; }
        /// <summary>
        /// Количество совместных матчей
        /// </summary>
        int Matches { get; set; }
        /// <summary>
        /// Количество побед(вместе или против взаимодействующего героя)
        /// </summary>
        int Wins { get; set; }
    }
}
