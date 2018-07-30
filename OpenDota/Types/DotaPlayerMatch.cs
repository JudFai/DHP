using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDota.Types
{
    public class DotaPlayerMatch : IDotaPlayerMatch
    {
        public ulong MatchID { get; set; }
        public PlayerSlot Slot { get; set; }
        public ulong? AccountID { get; set; }
        public int Assists { get; set; }
        public Item Backpack1 { get; set; }
        public Item Backpack2 { get; set; }
        public Item Backpack3 { get; set; }
        public int Deaths { get; set; }
        public int Gold { get; set; }
        public int GoldPerMinute { get; set; }
        public int GoldSpent { get; set; }
        public int HeroDamage { get; set; }
        public int HeroHealing { get; set; }
        public Hero Hero { get; set; }
        public Item Item1 { get; set; }
        public Item Item2 { get; set; }
        public Item Item3 { get; set; }
        public Item Item4 { get; set; }
        public Item Item5 { get; set; }
        public Item Item6 { get; set; }
        public int Kills { get; set; }
        public int LastHits { get; set; }
        public LeaverStatus LeaverStatus { get; set; }
        public int Level { get; set; }
        public int TowerDamage { get; set; }
        public int XpPerMinute { get; set; }
        public string PersonName { get; set; }
        public Faction Faction { get; set; }
        public int TotalGold { get; set; }
        public int TotalXp { get; set; }
        public IRankTier RankTier { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: {1}", PersonName, Hero);
        }
    }
}
