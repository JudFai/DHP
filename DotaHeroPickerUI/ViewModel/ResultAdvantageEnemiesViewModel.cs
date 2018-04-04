using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaHeroPicker;
using DotaHeroPickerUI.ViewModel.Core;

namespace DotaHeroPickerUI.ViewModel
{
    public class ResultAdvantageEnemiesViewModel : Core.ViewModelBase //ItemViewModel
    {
        #region Fields

        private List<EnemyHeroAdvantageCollectionViewModel> _enemyHeroAdvantageCollection;
        private List<EnemyHeroAdvantageCollectionViewModel> _enemyHeroAdvantageFilteredCollection;

        private bool _onlyPositiveAdvantages;

        #endregion

        #region Properties

        //public List<HeroAdvantage> HeroAdvantageCollection { get; private set; }

        public List<EnemyHeroAdvantageCollectionViewModel> EnemyHeroAdvantageCollection
        {
            get { return _enemyHeroAdvantageCollection; }
            set
            {
                _enemyHeroAdvantageCollection = value;
                Dispatcher.Invoke(() => RaisePropertyChanged(() => EnemyHeroAdvantageCollection));
            }
        }

        public List<EnemyHeroAdvantageCollectionViewModel> EnemyHeroAdvantageFilteredCollection
        {
            get { return _enemyHeroAdvantageFilteredCollection; }
            set
            {
                _enemyHeroAdvantageFilteredCollection = value;
                Dispatcher.Invoke(() => RaisePropertyChanged(() => EnemyHeroAdvantageFilteredCollection));
            }
        }

        public LobbyDotaHeroCollectionViewModel LobbyDotaHeroCollection { get; private set; }

        public bool OnlyPositiveAdvantages
        {
            get { return _onlyPositiveAdvantages; }
            set
            {
                if (_onlyPositiveAdvantages != value)
                {
                    _onlyPositiveAdvantages = value;
                    RaisePropertyChanged(() => OnlyPositiveAdvantages);
                    RefreshFilteredCollection();
                }
            }
        }

        #endregion

        #region Constructors

        public ResultAdvantageEnemiesViewModel(HostViewModel parent, LobbyDotaHeroCollectionViewModel lobbyDotaHeroCollection)
            : base(parent)
        {
            LobbyDotaHeroCollection = lobbyDotaHeroCollection;
            Parent.GetAllHeroAdvantageCompleted += OnGetAllHeroAdvantageCompleted;
            LobbyDotaHeroCollection.HeroesCollectionChanged += OnHeroesCollectionChanged;
            RefreshEnemyHeroAdvantageCollection();
        }

        #endregion

        #region Private Methods

        private void OnHeroesCollectionChanged(object sender, EventArgs e)
        {
            RefreshEnemyHeroAdvantageCollection();
        }

        private void OnGetAllHeroAdvantageCompleted(object sender, List<HeroAdvantage> e)
        {
            //HeroAdvantageCollection = e;
            RefreshEnemyHeroAdvantageCollection();
        }

        private void RefreshEnemyHeroAdvantageCollection()
        {
            if ((Parent.StatisticsManager != null) &&
                (LobbyDotaHeroCollection != null) &&
                (LobbyDotaHeroCollection.EnemyDotaHeroCollection.Count(p => !p.IsEmpty) > 0))
            {
                EnemyHeroAdvantageCollection = Parent.StatisticsManager.GetEnemyTeamAdvantageCollection(
                    LobbyDotaHeroCollection.EnemyDotaHeroCollection.Select(p => p.Hero).ToList(),
                    LobbyDotaHeroCollection.AlliedDotaHeroCollection.Select(p => p.Hero).ToList(),
                    LobbyDotaHeroCollection.BannedDotaHeroCollection.Select(p => p.Hero).ToList())
                    .Select(p =>
                        new EnemyHeroAdvantageCollectionViewModel(p,
                            p.EnemyHeroAdvantage.Select(a => new EnemyHeroAdvantageViewModel(a, Parent.AllDotaHero.FirstOrDefault(k => k.Hero == a.Hero))).ToList(),
                            Parent.AllDotaHero.FirstOrDefault(a => a.Hero == p.Hero)))
                    .ToList();
            }
            else
                EnemyHeroAdvantageCollection = null;

            RefreshFilteredCollection();
        }

        private void RefreshFilteredCollection()
        {
            if (EnemyHeroAdvantageCollection != null)
            {
                if (OnlyPositiveAdvantages)
                {
                    EnemyHeroAdvantageFilteredCollection =
                        EnemyHeroAdvantageCollection
                            .Where(p => p.EnemyHeroAdvantage.All(a => a.AdvantageValue >= 0))
                            .ToList();
                }
                else
                {
                    EnemyHeroAdvantageFilteredCollection = EnemyHeroAdvantageCollection;
                }
            }
            else
            {
                EnemyHeroAdvantageFilteredCollection = null;
            }
        }

        #endregion

        #region IDisposable Members

        public override void Dispose()
        {
            Parent.GetAllHeroAdvantageCompleted -= OnGetAllHeroAdvantageCompleted;
            //Parent.HeroesCollectionChanged -= OnHeroesCollectionChanged;
        }

        #endregion
    }
}
