using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DotaHeroPicker.ServerLog
{
    class ServerLogWorker : IServerLogWorker
    {
        #region Fields

        private bool _isRunning;
        private IDotaLobby _lastFoundLobby;
        private readonly string _pathToServerLog;

        private readonly IDotaServerLogParser _dotaServerLogParser = DotaServerLogParser.Instance;

        #endregion

        #region Consturctors

        public ServerLogWorker(string pathToServerLog)
        {
            _pathToServerLog = pathToServerLog;
        }

        #endregion

        #region IServerLogWorker Members

        public List<IDotaLobby> GetDotaLobbiesFromFile()
        {
            return GetDotaLobbiesFromFile(_pathToServerLog);
        }

        public List<IDotaLobby> GetDotaLobbiesFromFile(string pathToFile)
        {
            var dotaLobbyCollecton = new List<IDotaLobby>();
            using (var sr = new StreamReader(pathToFile))
            {
                while (!sr.EndOfStream)
                {
                    var str = sr.ReadLine();
                    var dotaLobby = _dotaServerLogParser.TryParse(str);
                    if (dotaLobby != null)
                        dotaLobbyCollecton.Add(dotaLobby);
                }
            }

            return dotaLobbyCollecton;
        }

        private void OnReceivedNewDotaLobby(IDotaLobby e)
        {
            if (ReceivedNewDotaLobby != null)
                ReceivedNewDotaLobby(this, e);
        }

        public event EventHandler<IDotaLobby> ReceivedNewDotaLobby;
        public void WaitForNewDotaLobby(TimeSpan maxWaitingTime)
        {
            if (_isRunning)
                throw new Exception("WaitForNewDotaLobby already is running");

            _isRunning = true;
            Task.Run(() =>
            {
                var dotaLobbyFound = false;
                while (!dotaLobbyFound)
                {
                    List<IDotaLobby> lobbies = null;
                    try
                    {
                        lobbies = GetDotaLobbiesFromFile();
                    }
                    catch (IOException)
                    {
                        // Игнорируем, т.к. возможно, что будет лишь монопольный доступ к файлу
                    }

                    if (lobbies != null)
                    {
                        var lastLobby = lobbies.OrderByDescending(p => p.LoggingTime).FirstOrDefault();
                        if (lastLobby != null)
                        {
                            var deltaTime = DateTime.Now - lastLobby.LoggingTime;
                            if ((maxWaitingTime >= deltaTime) && ((_lastFoundLobby == null) || (_lastFoundLobby.ID != lastLobby.ID)))
                            {
                                _lastFoundLobby = lastLobby;
                                OnReceivedNewDotaLobby(lastLobby);
                            }
                        }
                    }

                    Thread.Sleep(TimeSpan.FromSeconds(10));
                }
            });
        }

        public void StopWaitForNewDotaLobby()
        {
            if (!_isRunning)
                throw new Exception("WaitForNewDotaLobby was stopped");

            _isRunning = false;
        }

        #endregion
    }
}
