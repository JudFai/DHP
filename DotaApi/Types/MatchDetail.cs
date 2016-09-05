using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaApi.Types
{
    public class MatchDetail
    {
        public ulong MatchID { get; private set; }

        /// <summary>
        /// Длительность матча, сек.
        /// </summary>
        public int Duration { get; private set; }

        public Faction Winner { get; private set; }

        public GameMode GameMode { get; private set; }

        public int FirstBloodTime { get; private set; }

        public LobbyType LobbyType { get; private set; }

        public List<Player> Players { get; private set; }
    }
}
