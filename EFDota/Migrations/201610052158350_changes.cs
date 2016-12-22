namespace EFDota.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MatchDetails",
                c => new
                    {
                        ID = c.Long(nullable: false),
                        MatchSeqNum = c.Long(nullable: false),
                        Duration = c.Int(nullable: false),
                        PreGameDuration = c.Int(nullable: false),
                        StartTime = c.Long(nullable: false),
                        Winner = c.Int(nullable: false),
                        GameMode = c.Int(nullable: false),
                        FirstBloodTime = c.Int(nullable: false),
                        LobbyType = c.Int(nullable: false),
                        HumanPlayers = c.Int(nullable: false),
                        LeagueID = c.Long(nullable: false),
                        RadiantScore = c.Int(nullable: false),
                        DireScore = c.Int(nullable: false),
                        TowerStatusRadiant = c.Int(nullable: false),
                        TowerStatusDire = c.Int(nullable: false),
                        BarracksStatusRadiant = c.Int(nullable: false),
                        BarracksStatusDire = c.Int(nullable: false),
                        RadiantTeamID = c.Int(),
                        RadiantName = c.String(),
                        RadiantLogo = c.Long(),
                        RadiantTeamComplete = c.Boolean(),
                        DireTeamID = c.Int(),
                        DireName = c.String(),
                        DireLogo = c.Long(),
                        DireTeamComplete = c.Boolean(),
                    })
                .PrimaryKey(t => new { t.ID, t.MatchSeqNum });
            
            CreateTable(
                "dbo.MatchPlayers",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        AccountID = c.Long(),
                        Hero = c.Int(nullable: false),
                        PlayerSlot = c.Byte(nullable: false),
                        Faction = c.Int(nullable: false),
                        Item0 = c.Int(nullable: false),
                        Item1 = c.Int(nullable: false),
                        Item2 = c.Int(nullable: false),
                        Item3 = c.Int(nullable: false),
                        Item4 = c.Int(nullable: false),
                        Item5 = c.Int(nullable: false),
                        Kills = c.Int(nullable: false),
                        Deaths = c.Int(nullable: false),
                        Assists = c.Int(nullable: false),
                        LeaverStatus = c.Int(nullable: false),
                        LastHits = c.Int(nullable: false),
                        Denies = c.Int(nullable: false),
                        GoldPerMinute = c.Int(nullable: false),
                        XpPerMinute = c.Int(nullable: false),
                        Level = c.Int(nullable: false),
                        HeroDamage = c.Int(nullable: false),
                        TowerDamage = c.Int(nullable: false),
                        HeroHealing = c.Int(nullable: false),
                        Gold = c.Int(nullable: false),
                        GoldSpent = c.Int(nullable: false),
                        ScaledHeroDamage = c.Int(nullable: false),
                        ScaledTowerDamage = c.Int(nullable: false),
                        ScaledHeroHealing = c.Int(nullable: false),
                        MatchDetail_ID = c.Long(nullable: false),
                        MatchDetail_MatchSeqNum = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MatchDetails", t => new { t.MatchDetail_ID, t.MatchDetail_MatchSeqNum }, cascadeDelete: true)
                .Index(t => new { t.MatchDetail_ID, t.MatchDetail_MatchSeqNum });
            
            CreateTable(
                "dbo.AbilityUpgrades",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Ability = c.Int(nullable: false),
                        Level = c.Int(nullable: false),
                        Time = c.Int(nullable: false),
                        MatchPlayer_ID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MatchPlayers", t => t.MatchPlayer_ID)
                .Index(t => t.MatchPlayer_ID);
            
            CreateTable(
                "dbo.PickOrBans",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        IsPick = c.Boolean(nullable: false),
                        Hero = c.Int(nullable: false),
                        Team = c.Int(nullable: false),
                        Order = c.Int(nullable: false),
                        MatchDetail_ID = c.Long(),
                        MatchDetail_MatchSeqNum = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MatchDetails", t => new { t.MatchDetail_ID, t.MatchDetail_MatchSeqNum })
                .Index(t => new { t.MatchDetail_ID, t.MatchDetail_MatchSeqNum });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PickOrBans", new[] { "MatchDetail_ID", "MatchDetail_MatchSeqNum" }, "dbo.MatchDetails");
            DropForeignKey("dbo.MatchPlayers", new[] { "MatchDetail_ID", "MatchDetail_MatchSeqNum" }, "dbo.MatchDetails");
            DropForeignKey("dbo.AbilityUpgrades", "MatchPlayer_ID", "dbo.MatchPlayers");
            DropIndex("dbo.PickOrBans", new[] { "MatchDetail_ID", "MatchDetail_MatchSeqNum" });
            DropIndex("dbo.AbilityUpgrades", new[] { "MatchPlayer_ID" });
            DropIndex("dbo.MatchPlayers", new[] { "MatchDetail_ID", "MatchDetail_MatchSeqNum" });
            DropTable("dbo.PickOrBans");
            DropTable("dbo.AbilityUpgrades");
            DropTable("dbo.MatchPlayers");
            DropTable("dbo.MatchDetails");
        }
    }
}
