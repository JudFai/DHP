using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaHeroPicker;
using DotaHeroPickerUI.ViewModel.Core;
using Microsoft.TeamFoundation.MVVM;
using HeroPickerResources.Resources;

namespace DotaHeroPickerUI.ViewModel
{
    public class ResultAdvantageViewModel : ItemViewModel
    {
        #region Fields

        private List<HeroAdvantageCollectionViewModel> _heroAdvantageCollection;
        private List<HeroAdvantageCollectionViewModel> _heroAdvantageFilteredCollection;
        private bool _onlyPositiveAdvantages;

        #endregion

        #region Properties

        public HeroesCollectionChangedEventArgs HeroesCollection { get; private set; }

        public List<HeroAdvantageCollectionViewModel> HeroAdvantageCollection
        {
            get { return _heroAdvantageCollection; }
            set
            {
                _heroAdvantageCollection = value;
                Dispatcher.Invoke(() => RaisePropertyChanged("HeroAdvantageCollection"));
            }
        }

        public List<HeroAdvantageCollectionViewModel> HeroAdvantageFilteredCollection
        {
            get { return _heroAdvantageFilteredCollection; }
            set
            {
                _heroAdvantageFilteredCollection = value;
                Dispatcher.Invoke(() => RaisePropertyChanged("HeroAdvantageFilteredCollection"));
            }
        }

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

        public ResultAdvantageViewModel(HostViewModel parent, string title, IconEnum icon)
            : base(parent, title, icon)
        {
            Parent.HeroesCollectionChanged += OnHeroesCollectionChanged;
            Parent.DotaStatisticsManager.LoadedHeroAdvantages += OnGetAllHeroAdvantageCompleted;
        }

        #endregion

        #region Private Methods

        private void OnHeroesCollectionChanged(object sender, HeroesCollectionChangedEventArgs e)
        {
            HeroesCollection = e;
            RefreshHeroAdvantageCollection();
        }

        private void OnGetAllHeroAdvantageCompleted(object sender, List<HeroAdvantage> e)
        {
            RefreshHeroAdvantageCollection();
        }

        private void RefreshHeroAdvantageCollection()
        {
            if ((Parent.StatisticsManager != null) &&
                (HeroesCollection != null) &&
                (HeroesCollection.EnemyHeroes.Count(p => !p.IsEmpty) > 0))
            {
                HeroAdvantageCollection = Parent.StatisticsManager.GetAdvantageCollection(
                    HeroesCollection.EnemyHeroes.Select(p => p.Hero).ToList(),
                    HeroesCollection.AlliedHeroes.Select(p => p.Hero).ToList(),
                    HeroesCollection.BannedHeroes.Select(p => p.Hero).ToList())
                    .Select(p =>
                        new HeroAdvantageCollectionViewModel(p,
                            p.EnemyHeroAdvantage.Select(a => new EnemyHeroAdvantageViewModel(a, Parent.AllDotaHero.FirstOrDefault(k => k.Hero == a.Hero))).ToList(),
                            p.AlliedHeroAdvantage.Select(a => new AlliedHeroAdvantageViewModel(a, Parent.AllDotaHero.FirstOrDefault(k => k.Hero == a.Hero))).ToList(),
                            Parent.AllDotaHero.FirstOrDefault(a => a.Hero == p.Hero)))
                    .ToList();
            }
            else
                HeroAdvantageCollection = null;

            RefreshFilteredCollection();
        }

        private void RefreshFilteredCollection()
        {
            if (HeroAdvantageCollection != null)
            {
                if (OnlyPositiveAdvantages)
                {
                    HeroAdvantageFilteredCollection =
                        HeroAdvantageCollection
                            .Where(p => p.AlleidHeroAdvantage.All(a => a.AdvantageValue >= 0) && p.EnemyHeroAdvantage.All(a => a.AdvantageValue >= 0))
                            .ToList();
                }
                else
                {
                    HeroAdvantageFilteredCollection = HeroAdvantageCollection;
                }
            }
            else
            {
                HeroAdvantageFilteredCollection = null;
            }
        }

        #endregion
    }
}
