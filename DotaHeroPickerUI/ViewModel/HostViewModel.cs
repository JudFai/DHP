using DotaHeroPicker;
//using Microsoft.TeamFoundation.MVVM;
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
using DotaHeroPicker.Types;
using DotaHeroPicker.Statistics;

namespace DotaHeroPickerUI.ViewModel
{
    public class HostViewModel : ViewModelBase
    {
        #region Fields

        private object _selectedItemLocker = new object();
        private object _workProgressFunction = new object();
        private ItemViewModel _selectedItem;     

        private readonly HeroPickerSettings _settings;
        private readonly IDotaPlayerStatisticsWorker _dotaPlayerStatisticsWorker;

        private readonly SerializerHeroAdvantageCollection _serializerHeroAdvantageCollection;
        private readonly SerializerHeroGuideCollection _serializerHeroGuideCollection;
        private readonly SerializerHeroPickerSettings _serializerHeroPickerSettings;

        private double _progress;
        private string _progressDescription;
        private bool _applicationRefreshingData;
        private bool _applicationBusy;
        private IMenuItem _selectedMenuItem;

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
                    Dispatcher.Invoke(() => RaisePropertyChanged(() => Progress));
                }
            }
        }

        public string ProgressDescription
        {
            get { return _progressDescription; }
            private set
            {
                if (_progressDescription != value)
                {
                    _progressDescription = value;
                    Dispatcher.Invoke(() => RaisePropertyChanged(() => ProgressDescription));
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
                    Dispatcher.Invoke(() => RaisePropertyChanged(() => ApplicationRefreshingData));
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

        //public List<ItemViewModel> ItemCollection { get; private set; }
        //public List<ItemViewModel> ItemBottomCollection { get; private set; }

        public List<IMenuItem> MenuItemCollection { get; private set; }

        public IMenuItem SelectedMenuItem
        {
            get { return _selectedMenuItem; }
            set { SetSelectedMenuItem(value); }
            //{
            //    _selectedMenuItem = value;
            //    RaisePropertyChanged(() => SelectedMenuItem);
            //}
        }

        //public ItemViewModel SelectedItem
        //{
        //    get { return _selectedItem; }
        //    set { SetSelectedItem(value); }
        //}

        public DotaHeroViewModelCollection AllDotaHero { get; private set; }
        public LobbyDotaHeroCollectionViewModel LobbyDotaHeroCollection { get; private set; }
        public List<HeroAdvantage> HeroAdvantageCollection { get; private set; }

        #endregion

        #region Events

        /// <summary>
        /// Происходит, когда коллекция преимуществ сериализованна или получена
        /// </summary>
        public event EventHandler<List<HeroAdvantage>> GetAllHeroAdvantageCompleted;

        /// <summary>
        /// Происходит, когда коллекция руководств сериализованна или получена
        /// </summary>
        //public event EventHandler<List<HeroGuide>> GetAllHeroGuideCompleted;

        #endregion

        #region Constrctuors

        public HostViewModel()
        {
            DotaStatisticsManager = DotaStatisticsManager.GetInstance();
            AllDotaHero = DotaHeroViewModelCollection.GetInstance();
            LobbyDotaHeroCollection = new LobbyDotaHeroCollectionViewModel(AllDotaHero);
            _dotaPlayerStatisticsWorker = DotaPlayerStatisticsWorker.Instance;
            _dotaPlayerStatisticsWorker.StartGettingDotaPlayersStatistics();
            _dotaPlayerStatisticsWorker.ReceivingDotaPlayersStatistics += OnReceivingDotaPlayersStatistics;

            MenuItemCollection = new List<IMenuItem>
            {
                new MenuItem("Выбор героев", Menu.HeroesPick, IconEnum.Pick),
                new MenuItem("Выгода над врагами", Menu.ResultAdvantageEnemies, IconEnum.EnemyAdvantage),
                new MenuItem("Информация лобби", Menu.LobbyInfo, IconEnum.EnemyAdvantage),
                new MenuItem("Настройки", Menu.Settings, IconEnum.Settings, true)
            };
            //Loading settings=========================================================================================================
            _serializerHeroAdvantageCollection = SerializerHeroAdvantageCollection.GetInstance();
            _serializerHeroGuideCollection = SerializerHeroGuideCollection.GetInstance();
            _serializerHeroPickerSettings = SerializerHeroPickerSettings.GetInstance();

            _settings = _serializerHeroPickerSettings.ReadXml() ?? new HeroPickerSettings();

            DotaStatisticsManager.ChangedOperationProgress += OnProgress;
            DotaStatisticsManager.GetAllHeroAdvantageCompleted += OnGetAllHeroAdvantageCompleted;
            //DotaStatisticsManager.LoadedHeroAdvantages += OnLoadedHeroAdvantages;
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

            SelectedMenuItem = MenuItemCollection.FirstOrDefault();
        }

        #endregion

        #region Private Methods

        private void SetSelectedMenuItem(IMenuItem value)
        {
            if (_selectedMenuItem != value)
            {
                if ((_selectedMenuItem != null) && (_selectedMenuItem.Value != null))
                {
                    _selectedMenuItem.Value.Dispose();
                    _selectedMenuItem.Value = null;
                }

                _selectedMenuItem = value;
                _selectedMenuItem.Value = CreateViewModel(value.Menu);
                RaisePropertyChanged(() => SelectedMenuItem);
            }
        }

        private ViewModelBase CreateViewModel(Menu menu)
        {
            switch (menu)
            {
                case Menu.HeroesPick:
                    return new HeroesPickViewModel(this, LobbyDotaHeroCollection);
                case Menu.ResultAdvantageEnemies:
                    return new ResultAdvantageEnemiesViewModel(this, LobbyDotaHeroCollection);
                case Menu.Settings:
                    return new SettingsViewModel(this, _settings);
                case Menu.LobbyInfo:
                    return new LobbyInfoViewModel(this, _dotaPlayerStatisticsWorker);
                default:
                    throw new NotImplementedException();
            }
        }

        private async void WorkProgressFunction(Operation operation)
        {
            // TODO: не понятно, каким образом можно представить heroGuideCollection, если это generic тип
            // TODO: с другой стороны этот метод не очень нужен, т.к. он все равно пропускает стадию lock из-за асинхронности,
            // TODO: можно в коре убрать асинхронность, тогда это условие пропадёт
            await Task.Run(() =>
            {
                lock (_workProgressFunction)
                {
                    DateTime dataRefresh;
                    Action actOperation;
                    switch (operation)
                    {
                        case Operation.GetAllHeroAdvantage:
                            dataRefresh = _settings.LastDateRefreshHeroGuideCollection;
                            actOperation = DotaStatisticsManager.GetAllHeroGuide;
                            break;
                        default:
                            return;
                    }
                    //DotaStatisticsManager.GetAllHeroGuideCompleted += OnGetAllHeroGuideCompleted;
                    if (_settings.CountDaysForRefreshData <= (DateTime.Now - dataRefresh).Days)
                    {
                        ApplicationRefreshingData = true;
                        actOperation();
                    }
                    else
                    {
                        var heroGuideCollection = _serializerHeroGuideCollection.ReadXml();
                        if (heroGuideCollection == null)
                        {
                            ApplicationRefreshingData = true;
                            actOperation();
                        }
                        else
                        {
                            //StatisticsManager = new StatisticsManager(heroGuideCollection);
                            //OnGetAllHeroGuideCompleted(heroGuideCollection);
                        }
                    }
                }
            });
        }

        private void OnProgress(object sender, ProgressEventArgs e)
        {
            Progress = e.Progress;
            if (Progress == 100)
            {
                ProgressDescription = null;
            }
            else
            {
                switch (e.Operation)
                {
                    case Operation.GetAllHeroAdvantage:
                        ProgressDescription = "Загрузка преимуществ перед вражеской командой...";
                        break;
                    case Operation.GetAllHeroGuide:
                        ProgressDescription = "Загрузка руководств для героев...";
                        break;
                    case Operation.GetPlayerStatistics:
                        ProgressDescription = "Загрузка статистики на игроков...";
                        break;
                }
            }
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
            HeroAdvantageCollection = e;
            OnGetAllHeroAdvantageCompleted(e);
        }

        private void OnLoadedHeroAdvantages(object sender, List<HeroAdvantage> e)
        {
            StatisticsManager = new StatisticsManager(e);
        }

        private void OnReceivingDotaPlayersStatistics(object sender, bool e)
        {
            ApplicationRefreshingData = e;
        }

        //private void OnGetAllHeroGuideCompleted(List<HeroGuide> e)
        //{
        //    if (GetAllHeroGuideCompleted != null)
        //        GetAllHeroGuideCompleted(this, e);
        //}

        //private void OnGetAllHeroGuideCompleted(object sender, List<HeroGuide> e)
        //{
        //    _settings.LastDateRefreshHeroGuideCollection = DateTime.Now.Date;
        //    _serializerHeroGuideCollection.WriteXml(e);
        //    _serializerHeroPickerSettings.WriteXml(_settings);
        //    ApplicationRefreshingData = false;
        //    OnGetAllHeroGuideCompleted(e);
        //}

        //private void OnHeroesCollectionChanged(HeroesCollectionChangedEventArgs e)
        //{
        //    if (HeroesCollectionChanged != null)
        //        HeroesCollectionChanged(this, e);
        //}

        //private void OnHeroesCollectionChanged(object sender, HeroesCollectionChangedEventArgs e)
        //{
        //    OnHeroesCollectionChanged(e);
        //}

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

        #region IDisposable Members

        public override void Dispose()
        {
        }

        #endregion
    }
}
