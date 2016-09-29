﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDota.Types
{
    public enum LobbyType
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
