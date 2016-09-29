using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDota.Types
{
    public enum GameMode
    {
        None = 0,
        AllPick = 1,
        CaptainMode = 2,
        RandomDraft = 3,
        SingleDraft = 4,
        AllRandom = 5,
        Intro = 6,
        Diretide = 7,
        ReverseCaptainMode = 8,
        TheGreeviling = 9,
        Tutorial = 10,
        MidOnly = 11,
        LeastPlayed = 12,
        NewPlayerPool = 13,
        CompendiumMatchmaking = 14,
        CaptainsDraft = 16
    }
}
