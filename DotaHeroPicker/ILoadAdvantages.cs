using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaHeroPicker
{
    // TODO: Наверное придётся интерфейс переделать на возврат только одного объекта типа HeroAdvantage
    interface ILoadAdvantages
    {
        event EventHandler<ReadOnlyCollection<AlliedHeroAdvantage>> LoadedAdvantageAllied;
        event EventHandler<ReadOnlyCollection<EnemyHeroAdvantage>> LoadedAdvantageOverEnemy;
        void LoadAdvantageAllied();
        void LoadAdvantageOverEnemy();
    }
}
