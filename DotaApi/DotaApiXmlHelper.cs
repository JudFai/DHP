using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DotaApi.Types;
using DotaHeroPicker.Collections;
using DotaHeroPicker;

namespace DotaApi
{
    public static class DotaApiXmlHelper
    {
        #region Fields

        private static readonly DotaHeroCollection _dotaHeroCollection = DotaHeroCollection.GetInstance();
        private static readonly DotaItemCollection _dotaItemCollection = DotaItemCollection.GetInstance();

        #endregion

        #region Public Methods

        public static MatchDetail ParseMatchDetail(XmlElement matchDetail)
        {
            var matchID = ulong.Parse(matchDetail.SelectSingleNode("match_id").InnerXml);
            var startTimeInSeconds = ulong.Parse(matchDetail.SelectSingleNode("start_time").InnerXml);
            var duration = int.Parse(matchDetail.SelectSingleNode("duration").InnerXml);
            var winner = bool.Parse(matchDetail.SelectSingleNode("radiant_win").InnerXml)
                ? Faction.Radiant
                : Faction.Dire;
            var firstBloodTime = int.Parse(matchDetail.SelectSingleNode("first_blood_time").InnerXml);
            var lobbyType = (LobbyType)int.Parse(matchDetail.SelectSingleNode("lobby_type").InnerXml);
            var humanPlayers = int.Parse(matchDetail.SelectSingleNode("human_players").InnerXml);
            var gameMode = (GameMode)int.Parse(matchDetail.SelectSingleNode("game_mode").InnerXml);

            var playerCollection = new List<Player>();
            foreach (XmlElement player in matchDetail.SelectNodes("players/player"))
                playerCollection.Add(ParsePlayer(player));

            return new MatchDetail(
                matchID, duration, winner, gameMode, 
                firstBloodTime, lobbyType, humanPlayers, playerCollection);
        }

        public static Player ParsePlayer(XmlElement player)
        {
            // Не всегда пользователь предоставляет о себе информацию
            var accountIDXml = player.SelectSingleNode("account_id");
            ulong accountID = 0;
            if (accountIDXml != null)
                accountID = ulong.Parse(accountIDXml.InnerXml);

            var playerSlot = (PlayerSlot)int.Parse(player.SelectSingleNode("player_slot").InnerXml);
            var heroID = int.Parse(player.SelectSingleNode("hero_id").InnerXml);
            var item0 = int.Parse(player.SelectSingleNode("item_0").InnerXml);
            var item1 = int.Parse(player.SelectSingleNode("item_1").InnerXml);
            var item2 = int.Parse(player.SelectSingleNode("item_2").InnerXml);
            var item3 = int.Parse(player.SelectSingleNode("item_3").InnerXml);
            var item4 = int.Parse(player.SelectSingleNode("item_4").InnerXml);
            var item5 = int.Parse(player.SelectSingleNode("item_5").InnerXml);
            var kills = int.Parse(player.SelectSingleNode("kills").InnerXml);
            var deaths = int.Parse(player.SelectSingleNode("deaths").InnerXml);
            var assists = int.Parse(player.SelectSingleNode("assists").InnerXml);

            var leaverStatusXml = player.SelectSingleNode("leaver_status");
            var leaverStatus = LeaverStatus.None;
            if (leaverStatusXml != null)
                leaverStatus = (LeaverStatus)int.Parse(leaverStatusXml.InnerXml);

            var lastHits = int.Parse(player.SelectSingleNode("last_hits").InnerXml);
            var denies = int.Parse(player.SelectSingleNode("denies").InnerXml);
            var goldPerMin = int.Parse(player.SelectSingleNode("gold_per_min").InnerXml);
            var xpPerMin = int.Parse(player.SelectSingleNode("xp_per_min").InnerXml);
            var level = int.Parse(player.SelectSingleNode("level").InnerXml);
            var heroDamage = int.Parse(player.SelectSingleNode("hero_damage").InnerXml);
            var towerDamage = int.Parse(player.SelectSingleNode("tower_damage").InnerXml);
            var heroHealing = int.Parse(player.SelectSingleNode("hero_healing").InnerXml);
            var gold = int.Parse(player.SelectSingleNode("gold").InnerXml);
            var goldSpent = int.Parse(player.SelectSingleNode("gold_spent").InnerXml);

            var scaledHeroDamage = int.Parse(player.SelectSingleNode("scaled_hero_damage").InnerXml);
            var scaledTowerDamage = int.Parse(player.SelectSingleNode("scaled_tower_damage").InnerXml);
            var scaledHeroHealing = int.Parse(player.SelectSingleNode("scaled_hero_healing").InnerXml);

            return new Player(
                accountID, _dotaHeroCollection[(Hero)heroID], playerSlot,
                _dotaItemCollection[(Item)item0], _dotaItemCollection[(Item)item1], _dotaItemCollection[(Item)item2],
                _dotaItemCollection[(Item)item3], _dotaItemCollection[(Item)item4], _dotaItemCollection[(Item)item5],
                kills, deaths, assists, leaverStatus, lastHits, denies, goldPerMin, xpPerMin, level, heroDamage,
                towerDamage, heroHealing, gold, goldSpent, scaledHeroDamage, scaledTowerDamage, scaledHeroHealing);
        }

        #endregion
    }
}
