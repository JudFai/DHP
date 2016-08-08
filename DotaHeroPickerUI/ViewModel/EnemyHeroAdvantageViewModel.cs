using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaHeroPicker;
using Microsoft.TeamFoundation.MVVM;

namespace DotaHeroPickerUI.ViewModel
{
    public class EnemyHeroAdvantageViewModel : ViewModelBase
    {
        #region Public Methods

        public EnemyHeroAdvantage Model { get; private set; }

        public DotaHeroViewModel DotaHero { get; private set; }

        public double AdvantageValue { get { return Model.AdvantageValue; } }
        public DotaHero Hero { get { return Model.Hero; } }
        public string IconPath { get { return DotaHero.IconPath; } }

        #endregion

        #region Constructors

        public EnemyHeroAdvantageViewModel(EnemyHeroAdvantage model, DotaHeroViewModel dotaHeroViewModel)
        {
            Model = model;
            DotaHero = dotaHeroViewModel;
        }

        #endregion
    }
}
