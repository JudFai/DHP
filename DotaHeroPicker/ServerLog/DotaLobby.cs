using System;
using System.Collections.Generic;

namespace DotaHeroPicker.ServerLog
{
    class DotaLobby : IDotaLobby
    {
        #region Constructors

        public DotaLobby(IDotaParty party, List<IDotaPlayer> players, DateTime loggingTime, ulong id)
        {
            Party = party;
            Players = players;
            LoggingTime = loggingTime;
            ID = id;
        }

        #endregion

        #region IDotaLobby Members

        public ulong ID { get; private set; }
        public DateTime LoggingTime { get; private set; }
        public List<IDotaPlayer> Players { get; private set; }
        public IDotaParty Party { get; private set; }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return string.Format("ID: {0}, LoggingTime: {1:dd.MM.yyyy HH:mm:ss}", ID, LoggingTime);
        }

        #endregion
    }
}
