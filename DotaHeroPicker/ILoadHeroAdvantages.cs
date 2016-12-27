using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaHeroPicker
{
    interface ILoadHeroAdvantages
    {
        event EventHandler<List<HeroAdvantage>> LoadedHeroAdvantages;
        void LoadHeroAdvantages();
    }
}
