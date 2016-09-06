using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaHeroPicker.Types;

namespace DotaApi.Types
{
    public class Player
    {
        #region Properties

        public ulong AccountID { get; private set; }
        public DotaHero DotaHero { get; private set; }
        public PlayerSlot PlayerSlot { get; private set; }
        public Faction Faction { get; private set; }

        public DotaItem Item0 { get; private set; }
        public DotaItem Item1 { get; private set; }
        public DotaItem Item2 { get; private set; }
        public DotaItem Item3 { get; private set; }
        public DotaItem Item4 { get; private set; }
        public DotaItem Item5 { get; private set; }

        public int Kills { get; private set; }
        public int Deaths { get; private set; }
        public int Assists { get; private set; }

        public LeaverStatus LeaverStatus { get; private set; }
        public int LastHits { get; private set; }
        public int Denies { get; private set; }
        public int GoldPerMinute { get; private set; }
        public int XpPerMinute { get; private set; }
        public int Level { get; private set; }
        public int HeroDamage { get; private set; }
        public int TowerDamage { get; private set; }
        public int HeroHealing { get; private set; }
        public int Gold { get; private set; }
        public int GoldSpent { get; private set; }

        #endregion

        #region Constructors

        public Player(
            ulong accountID, DotaHero dotaHero, PlayerSlot playerSlot,
            DotaItem dotaItem0, DotaItem dotaItem1, DotaItem dotaItem2,
            DotaItem dotaItem3, DotaItem dotaItem4, DotaItem dotaItem5,
            int kills, int deaths, int assists,
            LeaverStatus leaverStatus,
            int lastHits, int denies,
            int goldPerMinute, int xpPerMinute,
            int level,
            int heroDamage, int towerDamage, int heroHealing,
            int gold, int goldSpent)
        {
            AccountID = accountID;
            DotaHero = dotaHero;
            PlayerSlot = playerSlot;
            Faction = (int)playerSlot >= 123 ? Faction.Dire : Faction.Radiant;
            Item0 = dotaItem0;
            Item1 = dotaItem1;
            Item2 = dotaItem2;
            Item3 = dotaItem3;
            Item4 = dotaItem4;
            Item5 = dotaItem5;
            Kills = kills;
            Deaths = deaths;
            Assists = assists;
            LeaverStatus = leaverStatus;
            LastHits = lastHits;
            Denies = denies;
            GoldPerMinute = goldPerMinute;
            XpPerMinute = xpPerMinute;
            Level = level;
            HeroDamage = heroDamage;
            TowerDamage = towerDamage;
            HeroHealing = heroHealing;
            Gold = gold;
            GoldSpent = goldSpent;
        }

        #endregion
    }
}
