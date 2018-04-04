using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDota
{
    /// <summary>
    /// Преимущество героя перед вражеским героем(или вместе с союзным героем)
    /// </summary>
    public interface IHeroAdvantage
    {
        /// <summary>
        /// ID-героя
        /// </summary>
        int HeroID { get; }
        /// <summary>
        /// ID-героя с которым происходит взаимодействие
        /// </summary>
        int InterplayHeroID { get; }
        /// <summary>
        /// Количество совместных матчей
        /// </summary>
        int Matches { get; }
        /// <summary>
        /// Процент преимущества против врага(или вместе с союзником)
        /// </summary>
        double AdvantagePercentage { get; }
    }
}
