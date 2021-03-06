﻿namespace OpenDota.Types
{
    public enum LobbyType : sbyte
    {
        Invalid = -1,
        PublicMatchmaking = 0,
        Practice = 1,
        Tournament = 2,
        Tutorial = 3,
        CoopWithAI = 4,
        TeamMatch = 5,
        SoloQueue = 6,
        RankedMatchmaking = 7,
        OneVsOneSoloMid = 8
    }
}
