using DotaHeroPicker;
using DotaHeroPickerUI.ViewModel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaHeroPickerUI.ViewModel
{
    public class ResultAdvantageAlliesViewModel : ItemViewModel
    {
        #region Fields

        //private 

        #endregion

        #region Constructors

        public ResultAdvantageAlliesViewModel(HostViewModel parent, string title, string iconPath)
            : base(parent, title, iconPath)
        {
            Parent.GetAllHeroAdvantageAlliesCompleted += OnGetAllHeroAdvantageCompleted;
            Parent.HeroesCollectionChanged += OnHeroesCollectionChanged;
        }

        #endregion

        #region Private Methods

        private void OnGetAllHeroAdvantageCompleted(object sender, List<HeroAdvantage> e)
        {
        }

        #endregion
    }
}
