using DotaHeroPicker.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaApi.Types
{
    public class Player
    {
        #region Properties

        public ulong ID { get; set; }

        public ulong AccountID { get; set; }
        public DotaHero DotaHero { get; set; }
        public PlayerSlot PlayerSlot { get; set; }
        public Faction Faction { get; set; }

        public DotaItem Item0 { get; set; }
        public DotaItem Item1 { get; set; }
        public DotaItem Item2 { get; set; }
        public DotaItem Item3 { get; set; }
        public DotaItem Item4 { get; set; }
        public DotaItem Item5 { get; set; }

        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int Assists { get; set; }

        public LeaverStatus LeaverStatus { get; set; }
        public int LastHits { get; set; }
        public int Denies { get; set; }
        public int GoldPerMinute { get; set; }
        public int XpPerMinute { get; set; }
        public int Level { get; set; }

        public int HeroDamage { get; set; }
        public int TowerDamage { get; set; }
        public int HeroHealing { get; set; }

        public int Gold { get; set; }
        public int GoldSpent { get; set; }

        public int ScaledHeroDamage { get; set; }
        public int ScaledTowerDamage { get; set; }
        public int ScaledHeroHealing { get; set; }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return DotaHero.ToString();
        }

        #endregion
    }
}
