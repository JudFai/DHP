using DotaHeroPicker;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaHeroPickerUI.ViewModel
{
    public class LobbyDotaHeroCollectionViewModel : Core.ViewModelBase
    {
        #region Properties

        public DotaHeroObservableCollection DotaHeroColletion { get; private set; }

        public DotaHeroObservableCollection DotaHeroAgilityColletion { get; private set; }
        public DotaHeroObservableCollection DotaHeroStrengthColletion { get; private set; }
        public DotaHeroObservableCollection DotaHeroIntelligenceColletion { get; private set; }

        public DotaHeroObservableCollection BannedDotaHeroCollection { get; private set; }
        public DotaHeroObservableCollection AlliedDotaHeroCollection { get; private set; }
        public DotaHeroObservableCollection EnemyDotaHeroCollection { get; private set; }

        #endregion

        #region Events

        public event EventHandler HeroesCollectionChanged;

        #endregion

        #region Constructors

        public LobbyDotaHeroCollectionViewModel(DotaHeroViewModelCollection heroCollection)
        {
            // Создаём копию коллекции без клонирования самих элементов
            DotaHeroColletion = new DotaHeroObservableCollection(heroCollection.Select(p => p), HeroCharacteristic.None);
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
        }

        #endregion

        #region Private Methods

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnHeroesCollectionChanged();
        }

        private void OnHeroesCollectionChanged()
        {
            if (HeroesCollectionChanged != null)
                HeroesCollectionChanged(this, EventArgs.Empty);
        }

        #endregion

        #region IDisposable Members

        public override void Dispose()
        {
            HeroesCollectionChanged = null;
            BannedDotaHeroCollection.CollectionChanged -= OnCollectionChanged;
            AlliedDotaHeroCollection.CollectionChanged -= OnCollectionChanged;
            EnemyDotaHeroCollection.CollectionChanged -= OnCollectionChanged;
        }

        #endregion
    }
}
