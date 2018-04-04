using DotaHeroPicker.Statistics;
using DotaHeroPickerUI.ViewModel.LobbyInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaHeroPickerUI.ViewModel
{
    public class LobbyInfoViewModel : Core.ViewModelBase
    {
        #region Fields

        private readonly IDotaPlayerStatisticsWorker _dotaPlayerStatisticsWorker;

        private List<DotaPlayerStatisticsViewModel> _dotaPlayerStatisticsCollection;
        private List<DotaPlayerStatisticsViewModel> _radiantDotaPlayerStatisticsCollection;
        private List<DotaPlayerStatisticsViewModel> _direDotaPlayerStatisticsCollection;

        #endregion

        #region Properties

        public List<DotaPlayerStatisticsViewModel> DotaPlayerStatisticsCollection
        {
            get { return _dotaPlayerStatisticsCollection; }
            set
            {
                if (_dotaPlayerStatisticsCollection != value)
                {
                    _dotaPlayerStatisticsCollection = value;
                    Dispatcher.Invoke(() => RaisePropertyChanged(() => DotaPlayerStatisticsCollection));
                }
            }
        }

        public List<DotaPlayerStatisticsViewModel> RadiantDotaPlayerStatisticsCollection
        {
            get { return _radiantDotaPlayerStatisticsCollection; }
            set
            {
                if (_radiantDotaPlayerStatisticsCollection != value)
                {
                    _radiantDotaPlayerStatisticsCollection = value;
                    Dispatcher.Invoke(() => RaisePropertyChanged(() => RadiantDotaPlayerStatisticsCollection));
                }
            }
        }

        public List<DotaPlayerStatisticsViewModel> DireDotaPlayerStatisticsCollection
        {
            get { return _direDotaPlayerStatisticsCollection; }
            set
            {
                if (_direDotaPlayerStatisticsCollection != value)
                {
                    _direDotaPlayerStatisticsCollection = value;
                    Dispatcher.Invoke(() => RaisePropertyChanged(() => DireDotaPlayerStatisticsCollection));
                }
            }
        }

        #endregion

        #region Constructors

        public LobbyInfoViewModel(HostViewModel parent, IDotaPlayerStatisticsWorker statisticsWorker)
            : base(parent)
        {
            _dotaPlayerStatisticsWorker = statisticsWorker;
            statisticsWorker.DotaPlayersStatisticsReceived += OnDotaPlayersStatisticsReceived;
            FillDotaPlayerStatisticsCollections(_dotaPlayerStatisticsWorker.LastReceviedDotaPlayerStatisticsCollection);
        }

        #endregion

        #region Private Methods

        private void FillDotaPlayerStatisticsCollections(List<IDotaPlayerStatistics> dotaPlayerStatisticsCollection)
        {
            if (dotaPlayerStatisticsCollection != null)
            {
                DotaPlayerStatisticsCollection = dotaPlayerStatisticsCollection
                    .Select(p => new DotaPlayerStatisticsViewModel(p, Parent.AllDotaHero))
                    .ToList();
                RadiantDotaPlayerStatisticsCollection = DotaPlayerStatisticsCollection
                    .Where(p => (p.Player.Slot >= 0) && (p.Player.Slot < 5))
                    .ToList();
                DireDotaPlayerStatisticsCollection = DotaPlayerStatisticsCollection
                    .Where(p => (p.Player.Slot >= 5) && (p.Player.Slot < 10))
                    .ToList();
            }
        }

        private void OnDotaPlayersStatisticsReceived(object sender, List<IDotaPlayerStatistics> e)
        {
            FillDotaPlayerStatisticsCollections(e);
        }

        #endregion

        #region IDisposable Members

        public override void Dispose()
        {
            _dotaPlayerStatisticsWorker.DotaPlayersStatisticsReceived -= OnDotaPlayersStatisticsReceived;
        }

        #endregion
    }
}
