using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaHeroPicker.Types;

namespace DotaHeroPicker
{
    /// <summary>
    /// Преимущество с союзным героем
    /// </summary>
    public class AlliedHeroAdvantage : Advantage
    {
        public AlliedHeroAdvantage(DotaHero hero, double advantageValue)
            : base(hero, advantageValue)
        {
        }
    }
}
