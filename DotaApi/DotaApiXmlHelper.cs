using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DotaHeroPicker.Collections;
using EFDota.Types;
//using Hero = DotaHeroPicker.Hero;
//using Item = DotaHeroPicker.Item;

namespace DotaApi
{
    public static class DotaApiXmlHelper
    {
        //#region Fields

        //private static readonly DotaHeroCollection _dotaHeroCollection = DotaHeroCollection.GetInstance();
        //private static readonly DotaItemCollection _dotaItemCollection = DotaItemCollection.GetInstance();

        //#endregion

        #region Public Methods

        public static MatchDetail ParseMatchDetail(XmlElement matchDetail)
        {
            var barracksStatusDire =
                (BarracksStatus)XmlConvert.ToInt32(matchDetail.SelectSingleNode("barracks_status_dire").InnerXml);
            var barracksStatusRadiant =
                (BarracksStatus)XmlConvert.ToInt32(matchDetail.SelectSingleNode("barracks_status_radiant").InnerXml);
            var direScore = XmlConvert.ToInt32(matchDetail.SelectSingleNode("dire_score").InnerXml);
            var duration = XmlConvert.ToInt32(matchDetail.SelectSingleNode("duration").InnerXml);
            var firstBloodTime = XmlConvert.ToInt32(matchDetail.SelectSingleNode("first_blood_time").InnerXml);
            var gameMode = (GameMode)XmlConvert.ToInt32(matchDetail.SelectSingleNode("game_mode").InnerXml);
            var humanPlayers = XmlConvert.ToInt32(matchDetail.SelectSingleNode("human_players").InnerXml);
            var id = XmlConvert.ToInt64(matchDetail.SelectSingleNode("match_id").InnerXml);
            var leagueID = XmlConvert.ToInt64(matchDetail.SelectSingleNode("leagueid").InnerXml);
            var lobbyType = (LobbyType)XmlConvert.ToInt32(matchDetail.SelectSingleNode("lobby_type").InnerXml);
            var matchSeqNum = XmlConvert.ToInt64(matchDetail.SelectSingleNode("match_seq_num").InnerXml);
            var preGameDuration = XmlConvert.ToInt32(matchDetail.SelectSingleNode("pre_game_duration").InnerXml);
            var radiantScore = XmlConvert.ToInt32(matchDetail.SelectSingleNode("radiant_score").InnerXml);
            var startTime = XmlConvert.ToInt64(matchDetail.SelectSingleNode("start_time").InnerXml);
            var towerStatusDire =
                (TowerStatus)XmlConvert.ToInt32(matchDetail.SelectSingleNode("tower_status_dire").InnerXml);
            var towerStatusRadiant =
                (TowerStatus)XmlConvert.ToInt32(matchDetail.SelectSingleNode("tower_status_radiant").InnerXml);
            var winner = bool.Parse(matchDetail.SelectSingleNode("radiant_win").InnerXml)
                ? Faction.Radiant
                : Faction.Dire;

            var direLogoXml = matchDetail.SelectSingleNode("dire_logo");
            long? direLogo = null;
            if (direLogoXml != null)
                direLogo = XmlConvert.ToInt64(direLogoXml.InnerXml);

            var direNameXml = matchDetail.SelectSingleNode("dire_name");
            string direName = null;
            if (direNameXml != null)
                direName = XmlConvert.VerifyXmlChars(direNameXml.InnerXml);

            var direTeamCompleteXml = matchDetail.SelectSingleNode("dire_team_complete");
            bool? direTeamComplete = null;
            if (direTeamCompleteXml != null)
                direTeamComplete = XmlConvert.ToBoolean(direTeamCompleteXml.InnerXml);

            var direTeamIDXml = matchDetail.SelectSingleNode("dire_team_id");
            int? direTeamID = null;
            if (direTeamIDXml != null)
                direTeamID = XmlConvert.ToInt32(direTeamIDXml.InnerXml);

            var radiantLogoXml = matchDetail.SelectSingleNode("radiant_logo");
            long? radiantLogo = null;
            if (radiantLogoXml != null)
                radiantLogo = XmlConvert.ToInt64(radiantLogoXml.InnerXml);

            var radiantNameXml = matchDetail.SelectSingleNode("radiant_name");
            string radiantName = null;
            if (radiantNameXml != null)
                radiantName = XmlConvert.VerifyXmlChars(radiantNameXml.InnerXml);

            var radiantTeamCompleteXml = matchDetail.SelectSingleNode("radiant_team_complete");
            bool? radiantTeamComplete = null;
            if (radiantTeamCompleteXml != null)
                radiantTeamComplete = XmlConvert.ToBoolean(radiantTeamCompleteXml.InnerXml);

            var radiantTeamIDXml = matchDetail.SelectSingleNode("radiant_team_id");
            int? radiantTeamID = null;
            if (radiantTeamIDXml != null)
                radiantTeamID = XmlConvert.ToInt32(radiantTeamIDXml.InnerXml);

            var playerCollection = new List<PlayerDetail>();
            foreach (XmlElement player in matchDetail.SelectNodes("players/player"))
                playerCollection.Add(ParsePlayer(player));

            var pickOrBanCollection = new List<PickOrBan>();
            foreach (XmlElement pickBan in matchDetail.SelectNodes("picks_bans/pick_ban"))
                pickOrBanCollection.Add(ParsePickOrBan(pickBan));

            var match = new MatchDetail
            {
                BarracksStatusDire = barracksStatusDire,
                BarracksStatusRadiant = barracksStatusRadiant,
                DireScore = direScore,
                Duration = duration,
                FirstBloodTime = firstBloodTime,
                GameMode = gameMode,
                HumanPlayers = humanPlayers,
                ID = id,
                LeagueID = leagueID,
                LobbyType = lobbyType,
                MatchSeqNum = matchSeqNum,
                PreGameDuration = preGameDuration,
                RadiantScore = radiantScore,
                StartTime = startTime,
                TowerStatusDire = towerStatusDire,
                TowerStatusRadiant = towerStatusRadiant,
                Winner = winner,
                PlayerDetails = playerCollection,
                PickOrBans = pickOrBanCollection,
                DireLogo = direLogo,
                DireName = direName,
                DireTeamComplete = direTeamComplete,
                DireTeamID = direTeamID,
                RadiantLogo = radiantLogo,
                RadiantName = radiantName,
                RadiantTeamComplete = radiantTeamComplete,
                RadiantTeamID = radiantTeamID
            };
            playerCollection.ForEach(p => p.MatchDetail = match);
            pickOrBanCollection.ForEach(p => p.MatchDetail = match);

            return match;
        }

        public static PlayerDetail ParsePlayer(XmlElement player)
        {
            // Не всегда пользователь предоставляет о себе информацию или это бот
            var accountIDXml = player.SelectSingleNode("account_id");
            long? accountID = null;
            if (accountIDXml != null)
                accountID = XmlConvert.ToInt64(accountIDXml.InnerXml);

            var assists = XmlConvert.ToInt32(player.SelectSingleNode("assists").InnerXml);
            var deaths = XmlConvert.ToInt32(player.SelectSingleNode("deaths").InnerXml);
            var denies = XmlConvert.ToInt32(player.SelectSingleNode("denies").InnerXml);
            var playerSlot = (PlayerSlot)XmlConvert.ToInt32(player.SelectSingleNode("player_slot").InnerXml);
            var faction = (int)playerSlot > 4 ? Faction.Dire : Faction.Radiant;
            var gold = XmlConvert.ToInt32(player.SelectSingleNode("gold").InnerXml);
            var goldPerMin = XmlConvert.ToInt32(player.SelectSingleNode("gold_per_min").InnerXml);
            var goldSpent = XmlConvert.ToInt32(player.SelectSingleNode("gold_spent").InnerXml);
            var hero = (Hero)XmlConvert.ToInt32(player.SelectSingleNode("hero_id").InnerXml);
            var heroDamage = XmlConvert.ToInt32(player.SelectSingleNode("hero_damage").InnerXml);
            var heroHealing = XmlConvert.ToInt32(player.SelectSingleNode("hero_healing").InnerXml);
            var item0 = GetItemOrRecipe(XmlConvert.ToInt32(player.SelectSingleNode("item_0").InnerXml));
            var item1 = GetItemOrRecipe(XmlConvert.ToInt32(player.SelectSingleNode("item_1").InnerXml));
            var item2 = GetItemOrRecipe(XmlConvert.ToInt32(player.SelectSingleNode("item_2").InnerXml));
            var item3 = GetItemOrRecipe(XmlConvert.ToInt32(player.SelectSingleNode("item_3").InnerXml));
            var item4 = GetItemOrRecipe(XmlConvert.ToInt32(player.SelectSingleNode("item_4").InnerXml));
            var item5 = GetItemOrRecipe(XmlConvert.ToInt32(player.SelectSingleNode("item_5").InnerXml));
            var kills = XmlConvert.ToInt32(player.SelectSingleNode("kills").InnerXml);
            var lastHits = XmlConvert.ToInt32(player.SelectSingleNode("last_hits").InnerXml);
            var leaverStatusXml = player.SelectSingleNode("leaver_status");
            var leaverStatus = LeaverStatus.None;
            if (leaverStatusXml != null)
                leaverStatus = (LeaverStatus)XmlConvert.ToInt32(leaverStatusXml.InnerXml);

            var level = XmlConvert.ToInt32(player.SelectSingleNode("level").InnerXml);
            var scaledHeroDamage = XmlConvert.ToInt32(player.SelectSingleNode("scaled_hero_damage").InnerXml);
            var scaledHeroHealing = XmlConvert.ToInt32(player.SelectSingleNode("scaled_hero_healing").InnerXml);
            var scaledTowerDamage = XmlConvert.ToInt32(player.SelectSingleNode("scaled_tower_damage").InnerXml);
            var towerDamage = XmlConvert.ToInt32(player.SelectSingleNode("tower_damage").InnerXml);
            var xpPerMin = XmlConvert.ToInt32(player.SelectSingleNode("xp_per_min").InnerXml);

            var heroID = XmlConvert.ToInt32(player.SelectSingleNode("hero_id").InnerXml);

            return new PlayerDetail
            {
                AccountID = accountID,
                Assists = assists,
                Deaths = deaths,
                Denies = denies,
                Faction = faction,
                Gold = gold,
                GoldPerMinute = goldPerMin,
                GoldSpent = goldSpent,
                Hero = hero,
                HeroDamage = heroDamage,
                HeroHealing = heroHealing,
                Item0 = item0,
                Item1 = item1,
                Item2 = item2,
                Item3 = item3,
                Item4 = item4,
                Item5 = item5,
                Kills = kills,
                LastHits = lastHits,
                LeaverStatus = leaverStatus,
                Level = level,
                PlayerSlot = playerSlot,
                ScaledHeroDamage = scaledHeroDamage,
                ScaledHeroHealing = scaledHeroHealing,
                ScaledTowerDamage = scaledTowerDamage,
                TowerDamage = towerDamage,
                XpPerMinute = xpPerMin
            };
        }

        public static Item GetItemOrRecipe(int itemID)
        {
            return Enum.IsDefined(typeof (Item), itemID) 
                ? (Item) itemID
                : Item.RecipeOrNone;
        }

        public static PickOrBan ParsePickOrBan(XmlElement pickBan)
        {
            var hero = (Hero)XmlConvert.ToInt32(pickBan.SelectSingleNode("hero_id").InnerXml);
            var isPick = XmlConvert.ToBoolean(pickBan.SelectSingleNode("is_pick").InnerXml);
            var order = XmlConvert.ToInt32(pickBan.SelectSingleNode("order").InnerXml);
            var team = (Faction)XmlConvert.ToInt32(pickBan.SelectSingleNode("team").InnerXml);
            return new PickOrBan
            {
                Hero = hero,
                IsPick = isPick,
                Order = order,
                Team = team
            };
        }

        #endregion
    }
}
