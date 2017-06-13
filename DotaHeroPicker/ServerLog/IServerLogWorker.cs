using System;
using System.Collections.Generic;

namespace DotaHeroPicker.ServerLog
{
    public interface IServerLogWorker
    {
        List<IDotaLobby> GetDotaLobbiesFromFile(string pathToFile);
        event EventHandler<IDotaLobby> ReceivedNewDotaLobby;
        /// <summary>
        /// Ждёт новое лобби в файле с максимальной разбежкой времени
        /// </summary>
        /// <param name="maxWaitingTime">Разбежка времени</param>
        void WaitForNewDotaLobby(TimeSpan maxWaitingTime);

        void StopWaitForNewDotaLobby();
    }
}
