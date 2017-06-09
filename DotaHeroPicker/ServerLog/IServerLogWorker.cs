using System.Collections.Generic;

namespace DotaHeroPicker.ServerLog
{
    public interface IServerLogWorker
    {
        List<IDotaLobby> GetDotaLobbiesFromFile(string pathToFile);
    }
}
