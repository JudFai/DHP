using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaHeroPicker;
using Microsoft.TeamFoundation.MVVM;

namespace DotaHeroPickerUI.ViewModel
{
    public class EnemyHeroAdvantageCollectionViewModel : ViewModelBase
    {
        #region Properties

        public EnemyHeroAdvantageCollection Model { get; private set; }

        public DotaHeroViewModel DotaHero { get; private set; }
        public ReadOnlyCollection<EnemyHeroAdvantageViewModel> EnemyHeroAdvantage { get; private set; }

        public double AdvantageValue { get { return Model.AdvantageValue; } }
        public DotaHero Hero { get { return Model.Hero; } }
        public string IconPath { get { return DotaHero.IconPath; } }

        #endregion

        #region Constructors

        public EnemyHeroAdvantageCollectionViewModel(
            EnemyHeroAdvantageCollection model, 
            IList<EnemyHeroAdvantageViewModel> enemyHeroAdvantage,
            DotaHeroViewModel dotaHero)
        {
            Model = model;
            EnemyHeroAdvantage = new ReadOnlyCollection<EnemyHeroAdvantageViewModel>(enemyHeroAdvantage);
            DotaHero = dotaHero;
        }

        #endregion
    }
}
