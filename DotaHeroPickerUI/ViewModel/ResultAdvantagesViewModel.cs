using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaHeroPicker;
using DotaHeroPickerUI.ViewModel.Core;

namespace DotaHeroPickerUI.ViewModel
{
    public class ResultAdvantagesViewModel : ItemViewModel
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
                Dispatcher.Invoke(() => RaisePropertyChanged("EnemyHeroAdvantageCollection"));
            }
        }

        public List<EnemyHeroAdvantageCollectionViewModel> EnemyHeroAdvantageFilteredCollection
        {
            get { return _enemyHeroAdvantageFilteredCollection; }
            set
            {
                _enemyHeroAdvantageFilteredCollection = value;
                Dispatcher.Invoke(() => RaisePropertyChanged("EnemyHeroAdvantageFilteredCollection"));
            }
        }

        public HeroesCollectionChangedEventArgs HeroesCollection { get; private set; }

        public bool OnlyPositiveAdvantages
        {
            get { return _onlyPositiveAdvantages; }
            set
            {
                if (_onlyPositiveAdvantages != value)
                {
                    _onlyPositiveAdvantages = value;
                    RaisePropertyChanged("OnlyPositiveAdvantages");
                    RefreshFilteredCollection();
                }
            }
        }

        #endregion

        #region Constructors

        public ResultAdvantagesViewModel(MainWindowViewModel parent, string title, string iconPath)
            : base(parent, title, iconPath)
        {
            Parent.GetAllHeroAdvantageCompleted += OnGetAllHeroAdvantageCompleted;
            Parent.HeroesCollectionChanged += OnHeroesCollectionChanged;
        }

        #endregion

        #region Private Methods

        private void OnHeroesCollectionChanged(object sender, HeroesCollectionChangedEventArgs e)
        {
            HeroesCollection = e;
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
                (HeroesCollection != null) && 
                (HeroesCollection.EnemyHeroes.Count(p => !p.IsEmpty) > 0))
            {
                EnemyHeroAdvantageCollection = Parent.StatisticsManager.GetEnemyTeamAdvantageCollection(
                    HeroesCollection.EnemyHeroes.Select(p => p.Hero).ToList(),
                    HeroesCollection.AlliedHeroes.Select(p => p.Hero).ToList(),
                    HeroesCollection.BannedHeroes.Select(p => p.Hero).ToList())
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
    }
}
