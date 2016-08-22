using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaHeroPickerUI.ViewModel.Core;
using HeroPickerResources.Resources;

namespace DotaHeroPickerUI.ViewModel
{
    public class HeroGuridsViewModel : ItemViewModel
    {
        #region Constructors

        public HeroGuridsViewModel(MainWindowViewModel parent, string title, IconEnum icon)
            : base(parent, title, icon)
        { }

        #endregion
    }
}
