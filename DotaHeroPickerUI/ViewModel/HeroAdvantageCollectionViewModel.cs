using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaHeroPicker;
using DotaHeroPicker.Types;
using Microsoft.TeamFoundation.MVVM;

namespace DotaHeroPickerUI.ViewModel
{
    public class HeroAdvantageCollectionViewModel : ViewModelBase
    {
        #region Properties

        public HeroAdvantageCollection Model { get; private set; }

        public DotaHeroViewModel DotaHero { get; private set; }
        public ReadOnlyCollection<EnemyHeroAdvantageViewModel> EnemyHeroAdvantage { get; private set; }
        public ReadOnlyCollection<AlliedHeroAdvantageViewModel> AlleidHeroAdvantage { get; private set; }

        public double AdvantageValue { get { return Model.AdvantageValue; } }
        public DotaHero Hero { get { return Model.Hero; } }
        public string IconPath { get { return DotaHero.IconPath; } }

        #endregion

        #region Constructors

        public HeroAdvantageCollectionViewModel(
            HeroAdvantageCollection model, 
            IList<EnemyHeroAdvantageViewModel> enemyHeroAdvantage,
            IList<AlliedHeroAdvantageViewModel> alliedHeroAdvantage,
            DotaHeroViewModel dotaHero)
        {
            Model = model;
            EnemyHeroAdvantage = new ReadOnlyCollection<EnemyHeroAdvantageViewModel>(enemyHeroAdvantage);
            AlleidHeroAdvantage = new ReadOnlyCollection<AlliedHeroAdvantageViewModel>(alliedHeroAdvantage);
            DotaHero = dotaHero;
        }

        #endregion
    }
}
