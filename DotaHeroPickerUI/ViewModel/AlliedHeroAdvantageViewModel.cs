using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaHeroPicker;
using DotaHeroPicker.Types;
using Microsoft.TeamFoundation.MVVM;

namespace DotaHeroPickerUI.ViewModel
{
    public class AlliedHeroAdvantageViewModel : ViewModelBase
    {
        #region Public Methods

        public AlliedHeroAdvantage Model { get; private set; }

        public DotaHeroViewModel DotaHero { get; private set; }

        public double AdvantageValue { get { return Model.AdvantageValue; } }
        public DotaHero Hero { get { return Model.Hero; } }
        public string IconPath { get { return DotaHero.IconPath; } }

        #endregion

        #region Constructors

        public AlliedHeroAdvantageViewModel(AlliedHeroAdvantage model, DotaHeroViewModel dotaHeroViewModel)
        {
            Model = model;
            DotaHero = dotaHeroViewModel;
        }

        #endregion
    }
}
