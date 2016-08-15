using DotaHeroPicker;
using Microsoft.TeamFoundation.MVVM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Data;
using DotaHeroPickerUI.Helpers;
using DotaHeroPickerUI.Model;
using DotaHeroPickerUI.ViewModel.Core;
using HeroPickerResources.Resources;
using DotaHeroPicker.Collections;

namespace DotaHeroPickerUI.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Fields

        private object _selectedItemLocker = new object();
        private ItemViewModel _selectedItem;

        private readonly string _pathToHeroImage = "/HeroPickerResources;component/Images/Heroes/";
        private readonly string _pathToHeroIcons = "/HeroPickerResources;component/Images/Heroes/Icons/";       

        private readonly HeroPickerSettings _settings;

        private readonly SerializerHeroAdvantageCollection _serializerHeroAdvantageCollection;
        private readonly SerializerHeroPickerSettings _serializerHeroPickerSettings;

        private double _progress;
        private bool _applicationRefreshingData;
        private bool _applicationBusy;

        #endregion

        #region Properties

        public DotaStatisticsManager DotaStatisticsManager { get; private set; }
        public StatisticsManager StatisticsManager { get; private set; }

        public double Progress
        {
            get { return _progress; }
            set
            {
                if (_progress != value)
                {
                    _progress = value;
                    Dispatcher.Invoke(() => RaisePropertyChanged("Progress"));
                }
            }
        }

        public bool ApplicationRefreshingData
        {
            get { return _applicationRefreshingData; }
            set
            {
                if (_applicationRefreshingData != value)
                {
                    _applicationRefreshingData = value;
                    Dispatcher.Invoke(() => RaisePropertyChanged("ApplicationRefreshingData"));
                }
            }
        }

        public bool ApplicationBusy
        {
            get { return _applicationBusy; }
            set
            {
                if (_applicationBusy != value)
                {
#if DEBUG
                    Console.WriteLine("SelectedItem: {0}", value);
#endif
                    _applicationBusy = value;
                    Dispatcher.Invoke(() => RaisePropertyChanged("ApplicationBusy"));
                }
            }
        }

        public List<ItemViewModel> ItemCollection { get; private set; }
        public List<ItemViewModel> ItemBottomCollection { get; private set; }

        public ItemViewModel SelectedItem
        {
            get { return _selectedItem; }
            set { SetSelectedItem(value); }
        }

        public ReadOnlyCollection<DotaHeroViewModel> AllDotaHero { get; private set; }

        #endregion

        #region Events

        /// <summary>
        /// Происходит, когда коллекция преимуществ сериализованна или получена
        /// </summary>
        public event EventHandler<List<HeroAdvantage>> GetAllHeroAdvantageCompleted;

        /// <summary>
        /// Происходит, когда изменяется одна из коллекций вражских, союзных или забанненых героев
        /// </summary>
        public event EventHandler<HeroesCollectionChangedEventArgs> HeroesCollectionChanged;

        #endregion

        #region Constrctuors

        public MainWindowViewModel()
        {
            var collection = DotaHeroCollection.GetInstance();
            AllDotaHero = new ReadOnlyCollection<DotaHeroViewModel>(
                collection.Select(p => new DotaHeroViewModel(
                    p,
                    string.Format("{0}{1}.jpg", _pathToHeroImage, p.DotaName.Entity),
                    true,
                    string.Format("{0}{1}.png", _pathToHeroIcons, p.DotaName.Entity))).ToList());

            var heroesPick = new HeroesPickViewModel(this, "Выбор героев", IconEnum.Pick);
            heroesPick.HeroesCollectionChanged += OnHeroesCollectionChanged;
            ItemCollection = new List<ItemViewModel>
            {
                heroesPick,
                new ResultAdvantagesViewModel(this, "Результат преимуществ", @"pack://application:,,,/HeroPickerResources;component/Images/Icons/Percent.png")
            };
            SelectedItem = ItemCollection.FirstOrDefault();
            //Loading settings=========================================================================================================
            DotaStatisticsManager = DotaStatisticsManager.GetInstance();
            _serializerHeroAdvantageCollection = SerializerHeroAdvantageCollection.GetInstance();
            _serializerHeroPickerSettings = SerializerHeroPickerSettings.GetInstance();

            _settings = _serializerHeroPickerSettings.ReadXml() ?? new HeroPickerSettings();

            DotaStatisticsManager.GetAllHeroAdvantageCompleted += OnGetAllHeroAdvantageCompleted;
            DotaStatisticsManager.ChangedOperationProgress += OnProgress;
            if (_settings.CountDaysForRefreshData <= (DateTime.Now - _settings.LastDateRefreshHeroAdvantageCollection).Days)
            {
                ApplicationRefreshingData = true;
                DotaStatisticsManager.GetAllHeroAdvantage();
            }
            else
            {
                var heroAdvantageCollection = _serializerHeroAdvantageCollection.ReadXml();
                if (heroAdvantageCollection == null)
                {
                    ApplicationRefreshingData = true;
                    DotaStatisticsManager.GetAllHeroAdvantage();
                }
                else
                {
                    StatisticsManager = new StatisticsManager(heroAdvantageCollection);
                    OnGetAllHeroAdvantageCompleted(heroAdvantageCollection);
                }
            }
            //=========================================================================================================================

            ItemBottomCollection = new List<ItemViewModel>
            {
                new SettingsViewModel(this, "Настройки", IconEnum.Settings, _settings, _serializerHeroPickerSettings)
            };
        }

        #endregion

        #region Private Methods

        private void OnProgress(object sender, double e)
        {
            Progress = e;
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            //if (!ApplicationBusy)
            //    RefreshEnemyHeroAdvantageCollection();
        }

        private void OnGetAllHeroAdvantageCompleted(List<HeroAdvantage> e)
        {
            if (GetAllHeroAdvantageCompleted != null)
                GetAllHeroAdvantageCompleted(this, e);
        }

        private void OnGetAllHeroAdvantageCompleted(object sender, List<HeroAdvantage> e)
        {
            StatisticsManager = new StatisticsManager(e);
            _settings.LastDateRefreshHeroAdvantageCollection = DateTime.Now.Date;
            _serializerHeroAdvantageCollection.WriteXml(e);
            _serializerHeroPickerSettings.WriteXml(_settings);
            ApplicationRefreshingData = false;
            OnGetAllHeroAdvantageCompleted(e);
        }

        private void OnHeroesCollectionChanged(HeroesCollectionChangedEventArgs e)
        {
            if (HeroesCollectionChanged != null)
                HeroesCollectionChanged(this, e);
        }

        private void OnHeroesCollectionChanged(object sender, HeroesCollectionChangedEventArgs e)
        {
            OnHeroesCollectionChanged(e);
        }

        private void SetSelectedItem(ItemViewModel val)
        {
            if (_selectedItem != val)
            {
                ApplicationBusy = true;
                _selectedItem = null;
                RaisePropertyChanged("SelectedItem");
                _selectedItem = val;
                RaisePropertyChanged("SelectedItem");
                Task.Run(() =>
                {
                    // Кажется, что не совсем разумно оставлять эту задержку, но это позволяет нивелировать исчезновение экрана
                    Thread.Sleep(100);
                    ApplicationBusy = false;
                });
            }
        }

        #endregion
    }
}
