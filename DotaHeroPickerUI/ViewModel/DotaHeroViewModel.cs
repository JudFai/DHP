using DotaHeroPicker;
using Microsoft.TeamFoundation.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaHeroPickerUI.ViewModel
{
    public class DotaHeroViewModel : ViewModelBase
    {
        #region Fields

        private bool _isEnabledHero;

        #endregion

        #region Properties

        public DotaHero Hero { get; private set; }

        public string ImagePath { get; private set; }

        public string IconPath { get; private set; }

        public bool IsEnabledHero
        {
            get { return _isEnabledHero; }
            set
            {
                if (_isEnabledHero != value)
                {
                    _isEnabledHero = value;
                    Dispatcher.Invoke(() => RaisePropertyChanged("IsEnabledHero"));
                }
            }
        }

        public bool IsEmpty { get; private set; }

        #endregion

        #region Constructors

        private DotaHeroViewModel()
        {
            IsEmpty = true;
            _isEnabledHero = true;
        }

        public DotaHeroViewModel(DotaHero hero, string imagePath, bool enable)
        {
            Hero = hero;
            ImagePath = imagePath;
            _isEnabledHero = enable;
            IsEmpty = false;
        }

        public DotaHeroViewModel(DotaHero hero, string imagePath, bool enable, string iconPath)
        {
            Hero = hero;
            ImagePath = imagePath;
            _isEnabledHero = enable;
            IsEmpty = false;
            IconPath = iconPath;
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return IsEmpty ? "EMPTY" : Hero.ToString();
        }

        public static DotaHeroViewModel CreateEmptyDotaHeroViewModel()
        {
            return new DotaHeroViewModel();
        }

        #endregion
    }
}
