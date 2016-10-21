using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaHeroPicker.Types;

namespace DotaHeroPicker
{
    public class Advantage
    {
        #region Properties

        public DotaHero Hero { get; private set; }
        public double AdvantageValue { get; private set; }

        #endregion

        #region Constructors

        public Advantage(DotaHero hero, double advantageValue)
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
