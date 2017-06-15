using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroPickerResources.Resources;

namespace DotaHeroPickerUI.ViewModel.Core
{
    public interface IMenuItem
    {
        string Title { get; }
        Menu Menu { get; }
        IconEnum Icon { get; }
        ViewModelBase Value { get; set; }
        bool IsBottomPosition { get; }
        bool IsEnabled { get; set; }
    }
}
