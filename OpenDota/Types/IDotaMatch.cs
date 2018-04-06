using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDota.Types
{
    public interface IDotaMatch
    {
        ulong MatchID { get; set; }
        BarracksStatus BarracksStatusDire { get; set; }
        BarracksStatus BarracksStatusRadiant { get; set; }
        int DireScore { get; set; }
        TimeSpan Duration { get; set; }
        TimeSpan FirstBloodTime { get; set; }
        GameMode GameMode { get; set; }
        int HumanPlayers { get; set; }
        LobbyType LobbyType { get; set; }
        ulong MatchSeqNumber { get; set; }
        int RadiantScore { get; set; }
        Faction Win { get; set; }
        DateTime StartTime { get; set; }
        TowerStatus TowerStatusDire { get; set; }
        TowerStatus TowerStatusRadiant { get; set; }
        IDotaPlayerMatch[] Players { get; set; }
        ServerRegion Region { get; set; }
    }
}
