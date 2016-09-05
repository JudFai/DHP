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

        public int AccountID { get; private set; }
        public DotaHero Dotahero { get; private set; }
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

        public Player(PlayerSlot playerSlot)
        {
            PlayerSlot = playerSlot;
            Faction = (int)playerSlot >= 123 ? Faction.Dire : Faction.Radiant;
        }

        #endregion
    }
}
