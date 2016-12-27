using DotaHeroPicker;
using DotaHeroPickerUI.ViewModel.Core;
using HeroPickerResources.Resources;
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

        private List<AlliedHeroAdvantageCollectionViewModel> _alliedHeroAdvantageCollection;
        private List<AlliedHeroAdvantageCollectionViewModel> _alliedHeroAdvantageFilteredCollection;
        private bool _onlyPositiveAdvantages;

        #endregion

        #region Properties

        public List<AlliedHeroAdvantageCollectionViewModel> AlliedHeroAdvantageCollection
        {
            get { return _alliedHeroAdvantageCollection; }
            set
            {
                _alliedHeroAdvantageCollection = value;
                Dispatcher.Invoke(() => RaisePropertyChanged("AlliedHeroAdvantageCollection"));
            }
        }

        public List<AlliedHeroAdvantageCollectionViewModel> AlliedHeroAdvantageFilteredCollection
        {
            get { return _alliedHeroAdvantageFilteredCollection; }
            set
            {
                _alliedHeroAdvantageFilteredCollection = value;
                Dispatcher.Invoke(() => RaisePropertyChanged("AlliedHeroAdvantageFilteredCollection"));
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

        public ResultAdvantageAlliesViewModel(HostViewModel parent, string title, IconEnum iconPath)
            : base(parent, title, iconPath)
        {
            //Parent.GetAllHeroAdvantageCompleted += OnGetAllHeroAdvantageCompleted;
            Parent.HeroesCollectionChanged += OnHeroesCollectionChanged; 
            Parent.DotaStatisticsManager.LoadedHeroAdvantages += OnGetAllHeroAdvantageCompleted;
        }

        #endregion

        #region Private Methods

        private void OnHeroesCollectionChanged(object sender, HeroesCollectionChangedEventArgs e)
        {
            HeroesCollection = e;
            RefreshAlliedHeroAdvantageCollection();
        }

        private void OnGetAllHeroAdvantageCompleted(object sender, List<HeroAdvantage> e)
        {
            RefreshAlliedHeroAdvantageCollection();
        }

        private void RefreshAlliedHeroAdvantageCollection()
        {
            if ((Parent.StatisticsManager != null) &&
                (HeroesCollection != null) &&
                (HeroesCollection.AlliedHeroes.Count(p => !p.IsEmpty) > 0))
            {
                AlliedHeroAdvantageCollection = Parent.StatisticsManager.GetAlliedTeamAdvantageCollection(
                    HeroesCollection.EnemyHeroes.Select(p => p.Hero).ToList(),
                    HeroesCollection.AlliedHeroes.Select(p => p.Hero).ToList(),
                    HeroesCollection.BannedHeroes.Select(p => p.Hero).ToList())
                    .Select(p =>
                        new AlliedHeroAdvantageCollectionViewModel(p,
                            p.AlliedHeroAdvantage.Select(a => new AlliedHeroAdvantageViewModel(a, Parent.AllDotaHero.FirstOrDefault(k => k.Hero == a.Hero))).ToList(),
                            Parent.AllDotaHero.FirstOrDefault(a => a.Hero == p.Hero)))
                    .ToList();
            }
            else
                AlliedHeroAdvantageCollection = null;

            RefreshFilteredCollection();
        }

        private void RefreshFilteredCollection()
        {
            if (AlliedHeroAdvantageCollection != null)
            {
                if (OnlyPositiveAdvantages)
                {
                    AlliedHeroAdvantageFilteredCollection =
                        AlliedHeroAdvantageCollection
                            .Where(p => p.AlliedHeroAdvantage.All(a => a.AdvantageValue >= 0))
                            .ToList();
                }
                else
                {
                    AlliedHeroAdvantageFilteredCollection = AlliedHeroAdvantageCollection;
                }
            }
            else
            {
                AlliedHeroAdvantageFilteredCollection = null;
            }
        }

        #endregion
    }
}
