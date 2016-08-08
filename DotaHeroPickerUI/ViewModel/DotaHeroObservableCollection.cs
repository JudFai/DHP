using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaHeroPicker;

namespace DotaHeroPickerUI.ViewModel
{
    public class DotaHeroObservableCollection : ObservableCollection<DotaHeroViewModel>
    {
        #region Properties

        public HeroCharacteristic HeroCollectionCharacteristic { get; private set; }

        /// <summary>
        /// Свойство отвечает за блокировку вызовов OnPropertyChanged и OnCollectionChanged, после изменения коллекции
        /// </summary>
        public bool BlockedRaiseCollectionEvents { get; set; }

        #endregion

        #region Constructors

        public DotaHeroObservableCollection(IEnumerable<DotaHeroViewModel> dotaHeroCollection,
            HeroCharacteristic heroCollectionCharacteristic)
            : base(dotaHeroCollection)
        {
            HeroCollectionCharacteristic = heroCollectionCharacteristic;
        }

        public DotaHeroObservableCollection(List<DotaHeroViewModel> dotaHeroCollection,
            HeroCharacteristic heroCollectionCharacteristic)
            : base(dotaHeroCollection)
        {
            HeroCollectionCharacteristic = heroCollectionCharacteristic;
        }

        #endregion

        #region Public Methods

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (!BlockedRaiseCollectionEvents)
                base.OnPropertyChanged(e);
        }

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (!BlockedRaiseCollectionEvents)
                base.OnCollectionChanged(e);
        }

        #endregion
    }
}
