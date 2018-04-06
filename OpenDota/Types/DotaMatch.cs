using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDota.Types
{
    class DotaMatch : IDotaMatch
    {
        public ulong MatchID { get; set; }
        public BarracksStatus BarracksStatusDire { get; set; }
        public BarracksStatus BarracksStatusRadiant { get; set; }
        public int DireScore { get; set; }
        public TimeSpan Duration { get; set; }
        public TimeSpan FirstBloodTime { get; set; }
        public GameMode GameMode { get; set; }
        public int HumanPlayers { get; set; }
        public LobbyType LobbyType { get; set; }
        public ulong MatchSeqNumber { get; set; }
        public int RadiantScore { get; set; }
        public Faction Win { get; set; }
        public DateTime StartTime { get; set; }
        public TowerStatus TowerStatusDire { get; set; }
        public TowerStatus TowerStatusRadiant { get; set; }
        public IDotaPlayerMatch[] Players { get; set; }
        public ServerRegion Region { get; set; }
    }
}
