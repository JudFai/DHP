using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DotaHeroPicker.Types;

namespace DotaHeroPicker
{
    /// <summary>
    /// Преимущество против вражеского героя
    /// </summary>
    public class EnemyHeroAdvantage
    {
        #region Properties

        public DotaHero Hero { get; private set; }
        public double AdvantageValue { get; private set; }

        #endregion

        #region Constructors

        public EnemyHeroAdvantage(DotaHero hero, double advantageValue)
        {
            Hero = hero;
            AdvantageValue = advantageValue;
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return string.Format("{0}: {1:F2}%", Hero, AdvantageValue);
        }

        #endregion
    }
}
