﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaHeroPicker
{
    public enum Ability
    {
        AcidSpray = 1,
        ActivateFireRemnant = 2,
        AdaptiveStrike = 3,
        Aftershock = 4,
        Alacrity = 5,
        AmplifyDamage = 6,
        AnchorSmash = 7,
        AncientSeal = 8,
        AphoticShield = 9,
        ArcLightning = 10,
        ArcaneAura = 11,
        ArcaneBolt = 12,
        ArcaneCurse = 13,
        ArcaneOrb = 14,
        ArcticBurn = 15,
        Assassinate = 16,
        Assimilate = 17,
        AstralImprisonment = 18,
        AstralSpirit = 19,
        Avalanche = 20,
        BallLightning = 21,
        Bash = 22,
        BatteryAssault = 23,
        BattleCry = 24,
        BattleHunger = 25,
        BattleTrance = 26,
        BerserkerBlood = 27,
        BerserkerCall = 28,
        BerserkerRage = 29,
        BlackHole = 30,
        BladeDance = 31,
        BladeFury = 32,
        BlindingLight = 33,
        BlinkAntiMage = 34,
        BlinkQueenPain = 35,
        BlinkStrike = 36,
        BloodRite = 37,
        Bloodlust = 38,
        Bloodrage = 39,
        Blur = 40,
        BorrowedTime = 41,
        BoulderSmash = 42,
        BrainSap = 43,
        BreakTether = 44,
        BreatheFire = 45,
        Bristleback = 46,
        BurningSpear = 47,
        Burrow = 48,
        Burrowstrike = 49,
        CallDown = 50,
        CallWildBoar = 51,
        CallWildHawk = 52,
        CausticFinale = 53,
        ChainFrost = 54,
        ChakraMagic = 55,
        ChakramBlue = 56,
        ChakramRed = 57,
        ChaosBolt = 58,
        ChaosMeteor = 59,
        ChaosStrike = 60,
        ChaoticOffering = 61,
        ChargeDarkness = 62,
        ChemicalRage = 63,
        ChillingTouch = 64,
        Chronosphere = 65,
        CloakandDagger = 66,
        ColdEmbrace = 67,
        ColdFeet = 68,
        ColdSnap = 69,
        ConcussiveShot = 70,
        ConjureImage = 71,
        Consume = 72,
        Control = 73,
        CorrosiveSkin = 74,
        CounterHelix = 75,
        CoupdeGrace = 76,
        CraggyExterior = 77,
        CripplingFear = 78,
        CryptSwarm = 79,
        CrystalNova = 80,
        CullingBlade = 81,
        CurseAvernus = 82,
        DarkPact = 83,
        Darkness = 84,
        DeafeningBlast = 85,
        DeathPact = 86,
        DeathPulse = 87,
        DeathWard = 88,
        Decay = 89,
        Decrepify = 90,
        DegenAura = 91,
        DemonicConversion = 92,
        DemonicPurge = 93,
        Desolate = 94,
        Devour = 95,
        DiabolicEdict = 96,
        Dismember = 97,
        Dispersion = 98,
        Disruption = 99,
        DividedWeStand = 100,
        Doom = 101,
        Doppelganger = 102,
        DoubleEdge = 103,
        DragonBlood = 104,
        DragonSlave = 105,
        DragonTail = 106,
        DreamCoil = 107,
        DruidForm = 108,
        DrunkenBrawler = 109,
        DrunkenHaze = 110,
        DualBreath = 111,
        Duel = 112,
        EarthSpike = 113,
        EarthSplitter = 114,
        Earthbind = 115,
        Earthshock = 116,
        EchoSlam = 117,
        EchoStomp = 118,
        Eclipse = 119,
        Eject = 120,
        ElderDragonForm = 121,
        ElectricVortex = 122,
        EMP = 123,
        Empower = 124,
        EmpoweringHaste = 125,
        Enchant = 126,
        EnchantRemnant = 127,
        EnchantTotem = 128,
        Enfeeble = 129,
        Enrage = 130,
        Ensnare = 131,
        Epicenter = 132,
        EssenceAura = 133,
        EssenceShift = 134,
        EtherShock = 135,
        EtherealJaunt = 136,
        Exorcism = 137,
        Exort = 138,
        EyeStorm = 139,
        EyesInTheForest = 140,
        FadeBolt = 141,
        FalsePromise = 142,
        FatalBonds = 143,
        FateEdict = 144,
        Feast = 145,
        FeralImpulse = 146,
        Fervor = 147,
        FiendGrip = 148,
        FierySoul = 149,
        FingerDeath = 150,
        FireRemnant = 151,
        FireSpirits = 152,
        Fireblast = 153,
        Firefly = 154,
        Fissure = 155,
        FlakCannon = 156,
        FlameGuard = 157,
        Flamebreak = 158,
        FlamingLasso = 159,
        FleshGolem = 160,
        FleshHeap = 161,
        Flux = 162,
        FocusFire = 163,
        FocusedDetonate = 164,
        ForgeSpirit = 165,
        FortuneEnd = 166,
        FreezingField = 167,
        FrostArrows = 168,
        FrostBlast = 169,
        Frostbite = 170,
        FrozenSigil = 171,
        FurySwipes = 172,
        GeminateAttack = 173,
        GeomagneticGrip = 174,
        Geostrike = 175,
        GhostWalk = 176,
        Ghostship = 177,
        GlaivesWisdom = 178,
        Glimpse = 179,
        GlobalSilence = 180,
        GodStrength = 181,
        GraveChill = 182,
        GravekeeperCloak = 183,
        GreatCleave = 184,
        GreaterBash = 185,
        GreevilGreed = 186,
        Grow = 187,
        GuardianAngel = 188,
        Gush = 189,
        Gust = 190,
        HandGod = 191,
        Haunt = 192,
        Headshot = 193,
        HealingWard = 194,
        HeartstopperAura = 195,
        HeatSeekingMissile = 196,
        HexRasta = 197,
        HexLion = 198,
        HolyPersuasion = 199,
        HomingMissile = 200,
        HoofStomp = 201,
        Hookshot = 202,
        Howl = 203,
        HunterinNight = 204,
        Hybrid = 205,
        IcarusDive = 206,
        IceArmor = 207,
        IceBlast = 208,
        IcePath = 209,
        IceShards = 210,
        IceVortex = 211,
        IceWall = 212,
        Ignite = 213,
        Illuminate = 214,
        IlluminateForm = 215,
        IllusoryOrb = 216,
        Impale = 217,
        Impetus = 218,
        IncapacitatingBite = 219,
        InfernalBlade = 220,
        Infest = 221,
        InnerBeast = 222,
        InnerVitality = 223,
        InsatiableHunger = 224,
        Invoke = 225,
        InvokerAttributeBonus = 226,
        IonShell = 227,
        Jinada = 228,
        Juxtapose = 229,
        KineticField = 230,
        KrakenShell = 231,
        LagunaBlade = 232,
        LandMines = 233,
        Laser = 234,
        LastWord = 235,
        LaunchFireSpirit = 236,
        LaunchSnowball = 237,
        Leap = 238,
        LeechSeed = 239,
        LifeBreak = 240,
        LifeDrain = 241,
        LightStrikeArray = 242,
        LightningBolt = 243,
        LightningStorm = 244,
        LiquidFire = 245,
        LivingArmor = 246,
        LucentBeam = 247,
        LunarBlessing = 248,
        Macropyre = 249,
        MagicMissile = 250,
        MagneticField = 251,
        Magnetize = 252,
        Maledict = 253,
        Malefice = 254,
        ManaBreak = 255,
        ManaBurn = 256,
        ManaDrain = 257,
        ManaLeak = 258,
        ManaShield = 259,
        ManaVoid = 260,
        MarchMachines = 261,
        Marksmanship = 262,
        MassSerpentWard = 263,
        MeatHook = 264,
        Meld = 265,
        Metamorphosis = 266,
        MidnightPulse = 267,
        MinefieldSign = 268,
        MirrorImage = 269,
        MistCoil = 270,
        MomentCourage = 271,
        MoonGlaive = 272,
        MoonlightShadow = 273,
        MorphAgilityGain = 274,
        MorphStrengthGain = 275,
        MorphReplicate = 276,
        MortalStrike = 277,
        Multicast = 278,
        MysticFlare = 279,
        MysticSnake = 280,
        NaturalOrder = 281,
        NatureAttendants = 282,
        NatureCall = 283,
        NatureGuise = 284,
        Necromastery = 285,
        NetherBlast = 286,
        NetherStrike = 287,
        NetherSwap = 288,
        NetherWard = 289,
        Nethertoxin = 290,
        Nightmare = 291,
        NightmareEnd = 292,
        NullField = 293,
        Omnislash = 294,
        OpenWounds = 295,
        Overcharge = 296,
        Overgrowth = 297,
        Overload = 298,
        Overpower = 299,
        OverwhelmingOdds = 300,
        ParalyzingCask = 301,
        Penitence = 302,
        Phantasm = 303,
        PhantomRush = 304,
        PhantomStrike = 305,
        PhaseShift = 306,
        PlagueWard = 307,
        PlasmaField = 308,
        PoisonAttack = 309,
        PoisonNova = 310,
        PoisonSting = 311,
        PoisonTouch = 312,
        Poof = 313,
        Pounce = 314,
        PowerCogs = 315,
        Powershot = 316,
        PrecisionAura = 317,
        PresenceDarkLord = 318,
        PressTheAttack = 319,
        PrimalRoar = 320,
        PrimalSplit = 321,
        PsiBlades = 322,
        PsionicTrap = 323,
        PulseNova = 324,
        Purification = 325,
        PurifyingFlames = 326,
        Quas = 327,
        QuillSpray = 328,
        Rabid = 329,
        Rage = 330,
        Ravage = 331,
        ReactiveArmor = 332,
        Reality = 333,
        RealityRift = 334,
        ReaperScythe = 335,
        Rearm = 336,
        Recall = 337,
        Reflection = 338,
        Refraction = 339,
        Reincarnation = 340,
        Release = 341,
        ReleaseIlluminate = 342,
        ReleaseIlluminateForm = 343,
        Relocate = 344,
        RemoteMines = 345,
        Repel = 346,
        Replicate = 347,
        RequiemSouls = 348,
        Return = 349,
        ReturnXMarksSpot = 350,
        ReturnAstralSpirit = 351,
        ReturnChakramBlue = 352,
        ReturnChakramRed = 353,
        ReversePolarity = 354,
        RipTide = 355,
        RocketBarrage = 356,
        RocketFlare = 357,
        RollingBoulder = 358,
        Rot = 359,
        Rupture = 360,
        SacredArrow = 361,
        Sacrifice = 362,
        Sadist = 363,
        SandStorm = 364,
        SanityEclipse = 365,
        SavageRoar = 366,
        ScorchedEarth = 367,
        ScreamOfPain = 368,
        SearingArrows = 369,
        SearingChains = 370,
        Shackles = 371,
        Shackleshot = 372,
        ShadowDance = 373,
        ShadowPoison = 374,
        ShadowPoisonRelease = 375,
        ShadowStrike = 376,
        ShadowWalk = 377,
        ShadowWave = 378,
        ShadowWord = 379,
        ShadowrazeQ = 380,
        ShadowrazeW = 381,
        ShadowrazeE = 382,
        ShallowGrave = 383,
        Shapeshift = 384,
        Shockwave = 385,
        Shrapnel = 386,
        Shukuchi = 387,
        ShurikenToss = 388,
        Silence = 389,
        SkeletonWalk = 390,
        Skewer = 391,
        SleightFist = 392,
        SlithereenCrush = 393,
        SmokeScreen = 394,
        Snowball = 395,
        SongSiren = 396,
        SongSirenEnd = 397,
        SonicWave = 398,
        SoulAssumption = 399,
        SoulCatcher = 400,
        SoulRip = 401,
        SparkWraith = 402,
        SpawnSpiderlings = 403,
        SpectralDagger = 404,
        SpellShield = 405,
        SpellSteal = 406,
        SpikedCarapace = 407,
        SpinWeb = 408,
        SpiritForm = 409,
        SpiritLance = 410,
        SpiritSiphon = 411,
        Spirits = 412,
        SpiritsIn = 413,
        SpiritsOut = 414,
        SplinterBlast = 415,
        SplitEarth = 416,
        SplitShot = 417,
        Sprint = 418,
        Sprout = 419,
        Stampede = 420,
        Starstorm = 421,
        StasisTrap = 422,
        StaticField = 423,
        StaticLink = 424,
        StaticRemnant = 425,
        StaticStorm = 426,
        StickyNapalm = 427,
        StiflingDagger = 428,
        StoneGaze = 429,
        StoneRemnant = 430,
        StopIcarusDive = 431,
        StopSunRay = 432,
        StormHammer = 433,
        Strafe = 434,
        SuicideSquadAttack = 435,
        SummonFamiliars = 436,
        SummonSpiritBear = 437,
        SummonWolves = 438,
        SunRay = 439,
        SunStrike = 440,
        Sunder = 441,
        Supernova = 442,
        Surge = 443,
        TakeAim = 444,
        Telekinesis = 445,
        TelekinesisLand = 446,
        Teleportation = 447,
        TempestDouble = 448,
        TestFaithDamage = 449,
        TestFaithTeleport = 450,
        Tether = 451,
        TheSwarm = 452,
        Thirst = 453,
        ThunderClap = 454,
        ThunderStrike = 455,
        ThundergodWrath = 456,
        Tidebringer = 457,
        TimberChain = 458,
        TimeDilation = 459,
        TimeLapse = 460,
        TimeLock = 461,
        TimeWalk = 462,
        ToggleMovement = 463,
        Tombstone = 464,
        Tornado = 465,
        Torrent = 466,
        Toss = 467,
        Track = 468,
        Trap = 469,
        TricksTrade = 470,
        TrueForm = 471,
        Unburrow = 472,
        UnrefinedFireblast = 473,
        UnstableConcoction = 474,
        UnstableConcoctionThrow = 475,
        UnstableCurrent = 476,
        Untouchable = 477,
        Upheaval = 478,
        Vacuum = 479,
        VampiricAura = 480,
        Vendetta = 481,
        VengeanceAura = 482,
        VenomousGale = 483,
        ViperStrike = 484,
        ViscousNasalGoo = 485,
        Void = 486,
        VoodooRestoration = 487,
        WallReplica = 488,
        WalrusKick = 489,
        WalrusPUNCH = 490,
        WaningRift = 491,
        Warcry = 492,
        Warpath = 493,
        WaveTerror = 494,
        Waveform = 495,
        Weave = 496,
        Wex = 497,
        WhirlingAxesMelee = 498,
        WhirlingAxesRanged = 499,
        WhirlingDeath = 500,
        WildAxes = 501,
        Windrun = 502,
        WinterCurse = 503,
        WraithfireBlast = 504,
        WrathNature = 505,
        XMarksSpot = 506,
        AttributeBonus = 507,

        Firestorm = 508,
        PitMalice = 509,
        AtrophyAura = 510,
        DarkRift = 511
    }
}
