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
        public int Duration { get; private set; }

        public TimeSpan DurationTimeSpan { get; private set; }

        public Faction Winner { get; private set; }

        public GameMode GameMode { get; private set; }

        public int FirstBloodTime { get; private set; }

        public LobbyType LobbyType { get; private set; }

        public int HumanPlayers { get; private set; }

        public List<Player> Players { get; private set; }

        #endregion

        #region Constructors

        public MatchDetail(
            ulong matchID, int duration, Faction winner,
            GameMode gameMode, int firstBloodTime, LobbyType lobbyType,
            int humanPlayers, List<Player> players)
        {
            MatchID = matchID;
            Duration = duration;
            Winner = winner;
            GameMode = gameMode;
            FirstBloodTime = firstBloodTime;
            LobbyType = lobbyType;
            HumanPlayers = humanPlayers;
            Players = players;
            DurationTimeSpan = TimeSpan.FromSeconds(duration);
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return string.Format("MatchID: {0}, {1}", MatchID, DurationTimeSpan);
        }

        #endregion
    }
}
