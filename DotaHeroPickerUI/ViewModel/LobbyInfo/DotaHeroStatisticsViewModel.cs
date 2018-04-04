using DotaHeroPicker.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaHeroPickerUI.ViewModel.LobbyInfo
{
    public class DotaHeroStatisticsViewModel : Core.ViewModelBase
    {
        #region Properties

        public IDotaHeroStatistics Model { get; private set; }

        public DotaHeroViewModel Hero { get; private set; }

        public IDotaWinning Winning
        {
            get { return Model.Winning; }
        }

        #endregion

        #region Constructors

        public DotaHeroStatisticsViewModel(IDotaHeroStatistics model, DotaHeroViewModelCollection dotaHeroCollection)
        {
            Model = model;
            Hero = dotaHeroCollection.FirstOrDefault(p => p.Hero == model.Hero);
        }

        #endregion

        #region IDisposable Members

        public override void Dispose()
        {
        }

        #endregion
    }
}
