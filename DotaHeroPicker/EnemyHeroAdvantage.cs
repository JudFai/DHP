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
    /// Преимущество над вражеским героем
    /// </summary>
    public class EnemyHeroAdvantage : Advantage
    {
        public EnemyHeroAdvantage(DotaHero hero, double advantageValue)
            : base(hero, advantageValue)
        {
        }
    }
}
