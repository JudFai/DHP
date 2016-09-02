using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaHeroPicker;
using Microsoft.TeamFoundation.MVVM;

namespace DotaHeroPickerUI.ViewModel
{
    public class HeroGuideViewModel : ViewModelBase
    {
        #region Properties

        public HeroGuide Model { get; private set; }

        #endregion

        #region Constructors

        public HeroGuideViewModel(HeroGuide model)
        {
            Model = model;
        }

        #endregion
    }
}
