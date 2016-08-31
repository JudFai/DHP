using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaHeroPicker;
using DotaHeroPickerUI.Model;
using DotaHeroPickerUI.ViewModel.Core;
using HeroPickerResources.Resources;

namespace DotaHeroPickerUI.ViewModel
{
    public class HeroGuridsViewModel : ItemViewModel
    {
        #region Fields

        private DotaLaneModel _selectedLane;

        #endregion

        #region Properties

        public List<DotaLaneModel> LaneCollection { get; set; }

        public DotaLaneModel SelectedLane
        {
            get { return _selectedLane; }
            set
            {
                if (_selectedLane != value)
                {
                    _selectedLane = value;
                    RaisePropertyChanged("SelectedLane");
                }
            }
        }

        #endregion

        #region Constructors

        public HeroGuridsViewModel(MainWindowViewModel parent, string title, IconEnum icon)
            : base(parent, title, icon)
        {
            var dotaLaneCollection = DotaLaneCollection.GetInstance();
            LaneCollection = new List<DotaLaneModel>
            {
                new DotaLaneModel { Title = "(Все)" },
                new DotaLaneModel { Lane = dotaLaneCollection[Lane.Jungle], Title = "Лес" },
                new DotaLaneModel { Lane = dotaLaneCollection[Lane.MiddleLane], Title = "Центральная линия" },
                new DotaLaneModel { Lane = dotaLaneCollection[Lane.OffLane], Title = "Тяжёлая линия" },
                new DotaLaneModel { Lane = dotaLaneCollection[Lane.Roam], Title = "Перемещение" },
                new DotaLaneModel { Lane = dotaLaneCollection[Lane.SafeLane], Title = "Лёгкая линия" }
            }.OrderBy(p => Title).ToList();
            _selectedLane = LaneCollection.FirstOrDefault(p => p.Lane == null);
        }

        #endregion
    }
}
