using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDota.Types
{
    public interface IDotaPlayerMatch
    {
        ulong MatchID { get; set; }
        PlayerSlot Slot { get; set; }
        ulong? AccountID { get; set; }
        int Assists { get; set; }
        Item Backpack1 { get; set; }
        Item Backpack2 { get; set; }
        Item Backpack3 { get; set; }
        int Deaths { get; set; }
        int Gold { get; set; }
        int GoldPerMinute { get; set; }
        int GoldSpent { get; set; }
        int HeroDamage { get; set; }
        int HeroHealing { get; set; }
        Hero Hero { get; set; }
        Item Item1 { get; set; }
        Item Item2 { get; set; }
        Item Item3 { get; set; }
        Item Item4 { get; set; }
        Item Item5 { get; set; }
        Item Item6 { get; set; }
        int Kills { get; set; }
        int LastHits { get; set; }
        LeaverStatus LeaverStatus { get; set; }
        int Level { get; set; }
        int TowerDamage { get; set; }
        int XpPerMinute { get; set; }
        string PersonName { get; set; }
        Faction Faction { get; set; }
        int TotalGold { get; set; }
        int TotalXp { get; set; }
        IRankTier RankTier { get; set; }
    }
}
