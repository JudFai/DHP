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
    public class HeroesCollectionChangedEventArgs : EventArgs
    {
        public List<DotaHeroViewModel> BannedHeroes { get; private set; }
        public List<DotaHeroViewModel> AlliedHeroes { get; private set; }
        public List<DotaHeroViewModel> EnemyHeroes { get; private set; }

        public HeroesCollectionChangedEventArgs(List<DotaHeroViewModel> bannedHeroes, List<DotaHeroViewModel> alliedHeroes, List<DotaHeroViewModel> enemyHeroes)
        {
            BannedHeroes = bannedHeroes;
            AlliedHeroes = alliedHeroes;
            EnemyHeroes = enemyHeroes;
        }
    }

    public class HeroesPickViewModel : Core.ViewModelBase //ItemViewModel
    {
        #region Fields

        private object _lockerCollection = new object();

        private string _heroName;

        private AsyncRelayCommand _resetHeroesCommand;
        private RelayCommand _removeDotaHeroByMainCharCommand;

        #endregion

        #region Properties

        public DotaHeroObservableCollection DotaHeroColletion { get; private set; }

        public DotaHeroObservableCollection DotaHeroAgilityColletion { get; private set; }
        public DotaHeroObservableCollection DotaHeroStrengthColletion { get; private set; }
        public DotaHeroObservableCollection DotaHeroIntelligenceColletion { get; private set; }

        public DotaHeroObservableCollection BannedDotaHeroCollection { get; private set; }
        public DotaHeroObservableCollection AlliedDotaHeroCollection { get; private set; }
        public DotaHeroObservableCollection EnemyDotaHeroCollection { get; private set; }

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

        #region Events

        public event EventHandler<HeroesCollectionChangedEventArgs> HeroesCollectionChanged;

        #endregion

        #region Constructors

        public HeroesPickViewModel(HostViewModel parent/*, string title, IconEnum icon*/)
            : base(parent)
            //: base(parent, title, icon)
        {
            // Создаём копию коллекции без клонирования самих элементов
            DotaHeroColletion = new DotaHeroObservableCollection(Parent.AllDotaHero.Select(p => p), HeroCharacteristic.None);
            DotaHeroAgilityColletion = new DotaHeroObservableCollection(
                DotaHeroColletion.Where(p => p.Hero.MainCharacteristic == HeroCharacteristic.Agility),
                HeroCharacteristic.Agility);
            DotaHeroStrengthColletion = new DotaHeroObservableCollection(
                DotaHeroColletion.Where(p => p.Hero.MainCharacteristic == HeroCharacteristic.Strength),
                HeroCharacteristic.Strength);
            DotaHeroIntelligenceColletion = new DotaHeroObservableCollection(
                DotaHeroColletion.Where(p => p.Hero.MainCharacteristic == HeroCharacteristic.Intelligence),
                HeroCharacteristic.Intelligence);
            BannedDotaHeroCollection = new DotaHeroObservableCollection(new List<DotaHeroViewModel>
            {
                DotaHeroViewModel.CreateEmptyDotaHeroViewModel(),
                DotaHeroViewModel.CreateEmptyDotaHeroViewModel(),
                DotaHeroViewModel.CreateEmptyDotaHeroViewModel(),
                DotaHeroViewModel.CreateEmptyDotaHeroViewModel(),
                DotaHeroViewModel.CreateEmptyDotaHeroViewModel()
            }, HeroCharacteristic.None);

            AlliedDotaHeroCollection = new DotaHeroObservableCollection(new List<DotaHeroViewModel>
            {
                DotaHeroViewModel.CreateEmptyDotaHeroViewModel(),
                DotaHeroViewModel.CreateEmptyDotaHeroViewModel(),
                DotaHeroViewModel.CreateEmptyDotaHeroViewModel(),
                DotaHeroViewModel.CreateEmptyDotaHeroViewModel(),
                DotaHeroViewModel.CreateEmptyDotaHeroViewModel()
            }, HeroCharacteristic.None);

            EnemyDotaHeroCollection = new DotaHeroObservableCollection(new List<DotaHeroViewModel>
            {
                DotaHeroViewModel.CreateEmptyDotaHeroViewModel(),
                DotaHeroViewModel.CreateEmptyDotaHeroViewModel(),
                DotaHeroViewModel.CreateEmptyDotaHeroViewModel(),
                DotaHeroViewModel.CreateEmptyDotaHeroViewModel(),
                DotaHeroViewModel.CreateEmptyDotaHeroViewModel()
            }, HeroCharacteristic.None);

            BannedDotaHeroCollection.CollectionChanged += OnCollectionChanged;
            AlliedDotaHeroCollection.CollectionChanged += OnCollectionChanged;
            EnemyDotaHeroCollection.CollectionChanged += OnCollectionChanged;

            //BindingOperations.EnableCollectionSynchronization(DotaHeroAgilityColletion, _lockerCollection);
            //BindingOperations.EnableCollectionSynchronization(DotaHeroIntelligenceColletion, _lockerCollection);
            //BindingOperations.EnableCollectionSynchronization(DotaHeroStrengthColletion, _lockerCollection);
            //BindingOperations.EnableCollectionSynchronization(BannedDotaHeroCollection, _lockerCollection);
            //BindingOperations.EnableCollectionSynchronization(AlliedDotaHeroCollection, _lockerCollection);
            //BindingOperations.EnableCollectionSynchronization(EnemyDotaHeroCollection, _lockerCollection);
        }

        #endregion

        #region Command Methods

        private void RemoveDotaHeroByMainChar(object param)
        {
            var hero = param as DotaHeroViewModel;
            if (hero != null)
            {
                DotaHeroObservableCollection heroFromCollection = null;
                switch (hero.Hero.MainCharacteristic)
                {
                    case HeroCharacteristic.Agility:
                        heroFromCollection = DotaHeroAgilityColletion;
                        break;
                    case HeroCharacteristic.Intelligence:
                        heroFromCollection = DotaHeroIntelligenceColletion;
                        break;
                    case HeroCharacteristic.Strength:
                        heroFromCollection = DotaHeroStrengthColletion;
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
                        BannedDotaHeroCollection,
                        AlliedDotaHeroCollection,
                        EnemyDotaHeroCollection
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
                BannedDotaHeroCollection, AlliedDotaHeroCollection, EnemyDotaHeroCollection
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
                RaisePropertyChanged("DotaHeroAgilityColletion");
                RaisePropertyChanged("DotaHeroStrengthColletion");
                RaisePropertyChanged("DotaHeroIntelligenceColletion");
                RaisePropertyChanged("BannedDotaHeroCollection");
                RaisePropertyChanged("AlliedDotaHeroCollection");
                RaisePropertyChanged("EnemyDotaHeroCollection");
            });
            OnHeroesCollectionChanged(new HeroesCollectionChangedEventArgs(
                BannedDotaHeroCollection.ToList(),
                AlliedDotaHeroCollection.ToList(), 
                EnemyDotaHeroCollection.ToList()));

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
                    mainCharHeroCollection = DotaHeroAgilityColletion;
                    break;
                case HeroCharacteristic.Intelligence:
                    mainCharHeroCollection = DotaHeroIntelligenceColletion;
                    break;
                    case HeroCharacteristic.Strength:
                    mainCharHeroCollection = DotaHeroStrengthColletion;
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

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            HeroName = string.Empty;
            var eventArgs = new HeroesCollectionChangedEventArgs(
                BannedDotaHeroCollection.ToList(), 
                AlliedDotaHeroCollection.ToList(), 
                EnemyDotaHeroCollection.ToList());
            OnHeroesCollectionChanged(eventArgs);
        }

        private void OnHeroesCollectionChanged(HeroesCollectionChangedEventArgs e)
        {
            if (HeroesCollectionChanged != null)
                HeroesCollectionChanged(this, e);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Обновляет доступность героев
        /// </summary>
        private void RefreshFoundHeroes()
        {
            var allHero = DotaHeroAgilityColletion
                .Concat(DotaHeroIntelligenceColletion)
                .Concat(DotaHeroStrengthColletion);
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
            BannedDotaHeroCollection.CollectionChanged -= OnCollectionChanged;
            AlliedDotaHeroCollection.CollectionChanged -= OnCollectionChanged;
            EnemyDotaHeroCollection.CollectionChanged -= OnCollectionChanged;
            HeroesCollectionChanged = null;
        }

        #endregion
    }
}
