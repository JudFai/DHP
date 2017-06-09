using System.Collections.Generic;

namespace DotaHeroPicker.ServerLog
{
    class DotaParty : IDotaParty
    {
        #region Constructors

        public DotaParty(List<IDotaPlayer> players, ulong id)
        {
            Players = players;
            ID = id;
        }

        #endregion

        #region IDotaParty Members

        public ulong ID { get; private set; }
        public List<IDotaPlayer> Players { get; private set; }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return string.Format("ID: {0}", ID);
        }

        #endregion

    }
}
