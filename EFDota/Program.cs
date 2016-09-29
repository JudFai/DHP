using EFDota.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDota
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var dc = new DotaContext())
            {
                //using (var trans = dc.Database.BeginTransaction())
                //{
                    var match = new MatchDetail
                    {
                        Duration = 10,
                        FirstBloodTime = 169,
                        //GameMode = GameMode.AllPick,
                        HumanPlayers = 10,
                        //LobbyType = LobbyType.RankedMatchmaking,
                        ID = 133,
                        Players = new List<Player>
                        {
                            new Player
                            {
                                AccountID = 123,
                                Assists = 123123,
                                Deaths = 123,
                                Denies = 123,
                                DotaHero = Hero.Abaddon,
                                Faction = Faction.Dire,
                                Gold = 1000,
                                GoldPerMinute = 400,
                                GoldSpent = 4000,
                                HeroDamage = 30000,
                                HeroHealing = 40000,
                                ID = 123,
                                Item0 = Item.RecipeOrNone,
                                Item1 = Item.RecipeOrNone,
                                Item2 = Item.Satanic,
                                Item3 = Item.SentryWard,
                                Item4 = Item.SilverEdge,
                                Item5 = Item.Satanic,
                                Kills = 30,
                                LastHits = 400,
                                LeaverStatus = LeaverStatus.Abandoned,
                                Level = 13,
                                PlayerSlot = PlayerSlot.Aqua,
                                ScaledHeroDamage = 4000,
                                ScaledHeroHealing = 40000,
                                ScaledTowerDamage = 1234,
                                TowerDamage = 1233,
                                XpPerMinute = 400
                            },
                            new Player
                            {
                                AccountID = 123,
                                Assists = 123123,
                                Deaths = 123,
                                Denies = 123,
                                DotaHero = Hero.Abaddon,
                                Faction = Faction.Dire,
                                Gold = 1000,
                                GoldPerMinute = 400,
                                GoldSpent = 4000,
                                HeroDamage = 30000,
                                HeroHealing = 40000,
                                ID = 123,
                                Item0 = Item.RecipeOrNone,
                                Item1 = Item.RecipeOrNone,
                                Item2 = Item.Satanic,
                                Item3 = Item.SentryWard,
                                Item4 = Item.SilverEdge,
                                Item5 = Item.Satanic,
                                Kills = 30,
                                LastHits = 400,
                                LeaverStatus = LeaverStatus.Abandoned,
                                Level = 13,
                                PlayerSlot = PlayerSlot.Yellow,
                                ScaledHeroDamage = 4000,
                                ScaledHeroHealing = 40000,
                                ScaledTowerDamage = 1234,
                                TowerDamage = 1233,
                                XpPerMinute = 400
                            }
                        },
                        Winner = Faction.Dire
                    };
                    match.Players.ToList().ForEach(p => p.MatchDetail = match);
                    //dc.Set<MatchDetail>().Add(match);
                    //dc.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [DotaHeroPicker].[dbo].[MatchDetails] ON");

                    dc.MatchDetails.Add(match);
                    dc.SaveChanges();

                    //dc.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [DotaHeroPicker].[dbo].[MatchDetails] OFF");
                //    trans.Commit();
                //}
            }
        }
    }
}
