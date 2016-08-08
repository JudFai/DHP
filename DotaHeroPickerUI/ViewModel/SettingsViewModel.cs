using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaHeroPickerUI.Helpers;
using DotaHeroPickerUI.Model;
using DotaHeroPickerUI.ViewModel.Core;
using HeroPickerResources.Resources;

namespace DotaHeroPickerUI.ViewModel
{
    public class SettingsViewModel : ItemViewModel
    {
        #region Fields

        private readonly HeroPickerSettings _model;
        private readonly SerializerHeroPickerSettings _serializerHeroPickerSettings;

        #endregion

        #region Properties

        public int CountDaysForRefreshData
        {
            get { return _model.CountDaysForRefreshData; }
            set
            {
                if (_model.CountDaysForRefreshData != value)
                {
                    var oldValue = _model.CountDaysForRefreshData;
                    _model.CountDaysForRefreshData = value;
                    if (!_serializerHeroPickerSettings.WriteXml(_model))
                        _model.CountDaysForRefreshData = oldValue;

                    Dispatcher.Invoke(() => RaisePropertyChanged("CountDaysForRefreshData"));
                }
            }
        }

        #endregion

        #region Constructors

        public SettingsViewModel(
            MainWindowViewModel parent, 
            string title,
            IconEnum icon, 
            HeroPickerSettings model, 
            SerializerHeroPickerSettings serializerHeroPickerSettings)
            : base(parent, title, icon)
        {
            _model = model;
            _serializerHeroPickerSettings = serializerHeroPickerSettings;
        }

        #endregion
    }
}
