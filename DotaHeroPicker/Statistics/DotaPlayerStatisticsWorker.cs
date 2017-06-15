using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaHeroPicker.ServerLog;

namespace DotaHeroPicker.Statistics
{
    public class DotaPlayerStatisticsWorker : IDotaPlayerStatisticsWorker
    {
        #region Fields

        private static readonly object _instanceLocker = new object();
        private static IDotaPlayerStatisticsWorker _instance;

        private readonly IDotaServerLogPathWorker _serverLogPathWorker;
        private readonly IServerLogWorker _serverLogWorker;
        private readonly DotaStatisticsManager _statisticsManager;

        #endregion

        #region Properties

        public static IDotaPlayerStatisticsWorker Instance
        {
            get
            {
                lock (_instanceLocker)
                {
                    return _instance ??
                           (_instance = new DotaPlayerStatisticsWorker());
                }
            }
        }

        #endregion

        #region Constructors

        private DotaPlayerStatisticsWorker()
        {
            _serverLogPathWorker = new DotaServerLogPathWorker();
            var pathToServerLog = _serverLogPathWorker.GetPathToServerLog();
            if (pathToServerLog == null)
                throw new Exception("Path to server_log.txt not found");

            _statisticsManager = DotaStatisticsManager.GetInstance();
            _serverLogWorker = new ServerLogWorker(pathToServerLog);
            _serverLogWorker.ReceivedNewDotaLobby += OnReceivedNewDotaLobby;
        }

        #endregion

        #region Private Methods

        private void OnReceivedNewDotaLobby(object sender, IDotaLobby dotaLobby)
        {
            var playersStatistics = _statisticsManager.GetPlayersStatisticsCollection(dotaLobby.Players);
            OnDotaPlayersStatisticsReceived(playersStatistics);
        }

        #endregion

        #region IDotaPlayerStatisticsWorker Members

        private void OnDotaPlayersStatisticsReceived(List<IDotaPlayerStatistics> e)
        {
            if (DotaPlayersStatisticsReceived != null)
                DotaPlayersStatisticsReceived(this, e);
        }

        public event EventHandler<List<IDotaPlayerStatistics>> DotaPlayersStatisticsReceived;

        public void StartGettingDotaPlayersStatistics()
        {
            _serverLogWorker.WaitForNewDotaLobby(TimeSpan.FromMinutes(5));
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            _serverLogWorker.ReceivedNewDotaLobby -= OnReceivedNewDotaLobby;
        }

        #endregion
    }
}
