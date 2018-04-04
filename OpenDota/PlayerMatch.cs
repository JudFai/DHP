using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDota
{
    public class PlayerMatch : IPlayerMatch
    {
        #region IPlayerMatch Members

        public ulong MatchID { get; set; }
        public PlayerSlot PlayerSlot { get; set; }
        public Faction Win { get; set; }
        public TimeSpan Duration { get; set; }
        public GameMode GameMode { get; set; }
        public LobbyType LobbyType { get; set; }
        public Hero Hero { get; set; }
        public DateTime StartTime { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int Assists { get; set; }
        public LeaverStatus LeaverStatus { get; set; }

        #endregion
    }
}
