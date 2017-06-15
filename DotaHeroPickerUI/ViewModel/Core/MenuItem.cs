using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroPickerResources.Resources;

namespace DotaHeroPickerUI.ViewModel.Core
{
    public class MenuItem : IMenuItem
    {
        #region Consturctors

        public MenuItem(string title, Menu menu, IconEnum icon, bool isBottomPosition = false)
        {
            Title = title;
            Menu = menu;
            Icon = icon;
            IsBottomPosition = isBottomPosition;
        }

        #endregion

        #region IMenuItem Members

        public string Title { get; private set; }
        public Menu Menu { get; private set; }
        public IconEnum Icon { get; private set; }
        public ViewModelBase Value { get; set; }
        public bool IsBottomPosition { get; private set; }
        public bool IsEnabled { get; set; }

        #endregion

    }
}
