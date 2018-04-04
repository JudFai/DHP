using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Navigation;
using DotaHeroPicker;
using DotaHeroPickerUI.ViewModel.Core;
using HeroPickerResources.Resources;
using Microsoft.TeamFoundation.MVVM;

namespace DotaHeroPickerUI.ViewModel
{
    public class HeroesPickViewModel : Core.ViewModelBase
    {
        #region Fields

        private object _lockerCollection = new object();

        private string _heroName;

        private AsyncRelayCommand _resetHeroesCommand;
        private RelayCommand _removeDotaHeroByMainCharCommand;

        #endregion

        #region Properties

        public LobbyDotaHeroCollectionViewModel LobbyDotaHeroCollection { get; private set; }

        public string HeroName
        {
            get { return _heroName; }
            set
            {
                if (_heroName != value)
                {
                    _heroName = value;
                    Dispatcher.Invoke(() => RaisePropertyChanged("HeroName"));
                    RefreshFoundHeroes();
                }
            }
        }

        #endregion

        #region Commands

        public AsyncRelayCommand ResetHeroesCommand
        {
            get
            {
                return _resetHeroesCommand ??
                       (_resetHeroesCommand = new AsyncRelayCommand(p => Task.Factory.StartNew(ResetHeroes)));
            }
        }

        public RelayCommand RemoveDotaHeroByMainCharCommand
        {
            get
            {
                return _removeDotaHeroByMainCharCommand ??
                       (_removeDotaHeroByMainCharCommand = new RelayCommand(RemoveDotaHeroByMainChar));
            }
        }

        #endregion

        #region Constructors

        public HeroesPickViewModel(HostViewModel parent, LobbyDotaHeroCollectionViewModel lobbyDotaHeroCollection)
            : base(parent)
        {
            LobbyDotaHeroCollection = lobbyDotaHeroCollection;
            lobbyDotaHeroCollection.HeroesCollectionChanged += OnCollectionChanged;
        }

        #endregion

        #region Command Methods

        private void RemoveDotaHeroByMainChar(object param)
        {
            var hero = param as DotaHeroViewModel;
            if (hero != null)
            {
                if (hero.IsEmpty)
                    return;

                DotaHeroObservableCollection heroFromCollection = null;
                switch (hero.Hero.MainCharacteristic)
                {
                    case HeroCharacteristic.Agility:
                        heroFromCollection = LobbyDotaHeroCollection.DotaHeroAgilityColletion;
                        break;
                    case HeroCharacteristic.Intelligence:
                        heroFromCollection = LobbyDotaHeroCollection.DotaHeroIntelligenceColletion;
                        break;
                    case HeroCharacteristic.Strength:
                        heroFromCollection = LobbyDotaHeroCollection.DotaHeroStrengthColletion;
                        break;
                    default:
                        return;
                }

                if (!heroFromCollection.Contains(hero))
                {
                    var empty = heroFromCollection.FirstOrDefault(p => p.IsEmpty);
                    var indexOfEmpty = heroFromCollection.IndexOf(empty);
                    var dotaHeroCollection = new List<DotaHeroObservableCollection>
                    {
                        LobbyDotaHeroCollection.BannedDotaHeroCollection,
                        LobbyDotaHeroCollection.AlliedDotaHeroCollection,
                        LobbyDotaHeroCollection.EnemyDotaHeroCollection
                    }.FirstOrDefault(p => p.Contains(hero));
                    var indexOfHero = dotaHeroCollection.IndexOf(hero);
                    heroFromCollection[indexOfEmpty] = hero;
                    dotaHeroCollection[indexOfHero] = empty;
                }
            }
        }

        private void ResetHeroes()
        {
            Parent.ApplicationBusy = true;
            var collectionHeroColllection = new List<DotaHeroObservableCollection>
            {
                LobbyDotaHeroCollection.BannedDotaHeroCollection, 
                LobbyDotaHeroCollection.AlliedDotaHeroCollection, 
                LobbyDotaHeroCollection.EnemyDotaHeroCollection
            };
            foreach (var collection in collectionHeroColllection)
            {
                collection.BlockedRaiseCollectionEvents = true;
                for (var i = 0; i < collection.Count; i++)
                {
                    if (!collection[i].IsEmpty)
                        SwapHeroesByMainChar(collection[i], collection);
                }

                collection.BlockedRaiseCollectionEvents = false;
            }

            Dispatcher.Invoke(() =>
            {
                RaisePropertyChanged(() => LobbyDotaHeroCollection);
            });
            //OnHeroesCollectionChanged(new HeroesCollectionChangedEventArgs(
            //    LobbyDotaHeroCollection.BannedDotaHeroCollection.ToList(),
            //    LobbyDotaHeroCollection.AlliedDotaHeroCollection.ToList(),
            //    LobbyDotaHeroCollection.EnemyDotaHeroCollection.ToList()));

            // Кажется, что не совсем разумно оставлять эту задержку, но это позволяет нивелировать исчезновение экрана
            Thread.Sleep(100);
            Parent.ApplicationBusy = false;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Замена героев между коллекциями основных характеристик и по типу стороны героя(враг, союзник или забаненный)
        /// </summary>
        private void SwapHeroesByMainChar(DotaHeroViewModel hero, DotaHeroObservableCollection collection)
        {
            DotaHeroObservableCollection mainCharHeroCollection = null;
            switch (hero.Hero.MainCharacteristic)
            {
                case HeroCharacteristic.Agility:
                    mainCharHeroCollection = LobbyDotaHeroCollection.DotaHeroAgilityColletion;
                    break;
                case HeroCharacteristic.Intelligence:
                    mainCharHeroCollection = LobbyDotaHeroCollection.DotaHeroIntelligenceColletion;
                    break;
                    case HeroCharacteristic.Strength:
                    mainCharHeroCollection = LobbyDotaHeroCollection.DotaHeroStrengthColletion;
                    break;
                default:
                    return;
            }

            mainCharHeroCollection.BlockedRaiseCollectionEvents = true;
            int heroIndex = collection.IndexOf(hero);
            var emptyHeroIndex = mainCharHeroCollection.IndexOf(mainCharHeroCollection.FirstOrDefault(p => p.IsEmpty));
            collection[heroIndex] = mainCharHeroCollection[emptyHeroIndex];
            mainCharHeroCollection[emptyHeroIndex] = hero;
            mainCharHeroCollection.BlockedRaiseCollectionEvents = false;
        }

        private void OnCollectionChanged(object sender, EventArgs e)
        {
            HeroName = string.Empty;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Обновляет доступность героев
        /// </summary>
        private void RefreshFoundHeroes()
        {
            var allHero = LobbyDotaHeroCollection.DotaHeroAgilityColletion
                .Concat(LobbyDotaHeroCollection.DotaHeroIntelligenceColletion)
                .Concat(LobbyDotaHeroCollection.DotaHeroStrengthColletion);
            IEnumerable<DotaHeroViewModel> filteredCollection = allHero;
            if (!string.IsNullOrEmpty(HeroName))
                filteredCollection = filteredCollection.Where(p => !p.IsEmpty && p.Hero.DotaName.FullName.ToUpper().Contains(HeroName.ToUpper()));

            foreach (var hero in allHero)
                hero.IsEnabledHero = false;

            foreach (var hero in filteredCollection)
                hero.IsEnabledHero = true;
        }

        #endregion

        #region IDisposable Members

        public override void Dispose()
        {
            //BannedDotaHeroCollection.CollectionChanged -= OnCollectionChanged;
            //AlliedDotaHeroCollection.CollectionChanged -= OnCollectionChanged;
            //EnemyDotaHeroCollection.CollectionChanged -= OnCollectionChanged;
            //HeroesCollectionChanged = null;
        }

        #endregion
    }
}
