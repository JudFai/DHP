using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenDota.Types;

namespace OpenDota
{
    public interface IPlayerMatch
    {
        ulong MatchID { get; set; }
        PlayerSlot PlayerSlot { get; set; }
        Faction Win { get; set; }
        TimeSpan Duration { get; set; }
        GameMode GameMode { get; set; }
        LobbyType LobbyType { get; set; }
        Hero Hero { get; set; }
        DateTime StartTime { get; set; }
        int Kills { get; set; }
        int Deaths { get; set; }
        int Assists { get; set; }
        LeaverStatus LeaverStatus { get; set; }
    }
}
