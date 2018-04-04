using DotaHeroPicker.ServerLog;
using DotaHeroPicker.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaHeroPickerUI.ViewModel.LobbyInfo
{
    public class DotaPlayerStatisticsViewModel : Core.ViewModelBase
    {
        #region Properties

        public IDotaPlayerStatistics Model { get; private set; }

        public List<DotaHeroStatisticsViewModel> FavoriteHeroes { get; private set; }

        public List<DotaHeroStatisticsViewModel> TopFavoriteHeroes { get; private set; }

        public IDotaWinning Winning
        {
            get { return Model.Winning; }
        }

        public IDotaPlayer Player
        {
            get { return Model.Player; }
        }

        public string Nickname
        {
            get { return Model.Nickname; }
        }

        #endregion

        #region Constructors

        public DotaPlayerStatisticsViewModel(IDotaPlayerStatistics model, DotaHeroViewModelCollection heroCollection)
        {
            Model = model;
            if (model.FavoriteHeroes != null)
            {
                FavoriteHeroes = model.FavoriteHeroes.Select(p => new DotaHeroStatisticsViewModel(p, heroCollection)).ToList();
                TopFavoriteHeroes = FavoriteHeroes.Take(5).ToList();
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
