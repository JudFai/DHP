using System.Collections.Generic;
using System.IO;

namespace DotaHeroPicker.ServerLog
{
    class ServerLogWorker : IServerLogWorker
    {
        #region Fields

        private readonly IDotaServerLogParser _dotaServerLogParser = DotaServerLogParser.Instance;

        #endregion

        #region IServerLogWorker Members

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

        #endregion

    }
}
