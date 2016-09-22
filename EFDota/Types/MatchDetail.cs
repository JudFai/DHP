using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DotaApi.Types
{
    public class MatchDetail
    {
        #region Properties

        public ulong MatchID { get; private set; }

        /// <summary>
        /// Длительность матча, сек.
        /// </summary>
        public int Duration { get; set; }

        public TimeSpan DurationTimeSpan { get; set; }

        public Faction Winner { get; set; }

        public GameMode GameMode { get; set; }

        public int FirstBloodTime { get; set; }

        public LobbyType LobbyType { get; set; }

        public int HumanPlayers { get; set; }

        public List<Player> Players { get; set; }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return string.Format("MatchID: {0}, {1}", MatchID, DurationTimeSpan);
        }

        #endregion
    }
}
