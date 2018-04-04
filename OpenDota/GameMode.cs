using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDota
{
    public enum GameMode : byte
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
        CoopVsAI = 15,
        CaptainsDraft = 16,
        AbilityDraft = 18,
        AllRandomDeathmatch = 20,
        OneVsOneMidOnly = 21,
        RankedMatchmaking = 22
    }
}
