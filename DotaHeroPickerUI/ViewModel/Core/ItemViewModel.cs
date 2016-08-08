using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroPickerResources.Resources;
using Microsoft.TeamFoundation.MVVM;

namespace DotaHeroPickerUI.ViewModel.Core
{
    public abstract class ItemViewModel : ViewModelBase
    {
        #region Fields

        private RelayCommand _selectItemCommand;

        #endregion

        #region Properties

        public MainWindowViewModel Parent { get; private set; }

        public string IconPath { get; private set; }
        public string Title { get; private set; }
        public IconEnum Icon { get; private set; }

        #endregion

        public RelayCommand SelectItemCommand
        {
            get
            {
                return _selectItemCommand ??
                       (_selectItemCommand = new RelayCommand(p =>
                       {
                           Parent.SelectedItem = this;
                       }));
            }
        }

        #region Constructors

        protected ItemViewModel(MainWindowViewModel parent, string title, string iconPath)
        {
            Parent = parent;
            Title = title;
            IconPath = iconPath;
        }

        protected ItemViewModel(MainWindowViewModel parent, string title, IconEnum icon)
        {
            Parent = parent;
            Title = title;
            Icon = icon;
        }

        #endregion
    }
}
