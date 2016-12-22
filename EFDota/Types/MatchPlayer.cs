using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDota.Types
{
    public class MatchPlayer
    {
        #region Properties

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        public long? AccountID { get; set; }
        public Hero Hero { get; set; }
        public PlayerSlot PlayerSlot { get; set; }
        public Faction Faction { get; set; }

        public Item Item0 { get; set; }
        public Item Item1 { get; set; }
        public Item Item2 { get; set; }
        public Item Item3 { get; set; }
        public Item Item4 { get; set; }
        public Item Item5 { get; set; }

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

        //public List<AbilityUpgrade> AbilityUpgrades { get; set; }

        public MatchDetail MatchDetail { get; set; }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return Hero.ToString();
        }

        #endregion
    }
}
