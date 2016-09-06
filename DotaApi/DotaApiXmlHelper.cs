using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DotaApi.Types;
using DotaHeroPicker.Collections;

namespace DotaApi
{
    public static class DotaApiXmlHelper
    {
        #region Fields

        private static readonly DotaHeroCollection _dotaHeroCollection = DotaHeroCollection.GetInstance();

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
        }

        public static Player ParsePlayer(XmlElement player)
        {
            var accountID = ulong.Parse(player.SelectSingleNode("account_id").InnerXml);
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
            var leaverStatus = (LeaverStatus)int.Parse(player.SelectSingleNode("leaver_status").InnerXml);
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
            return new Player(accountID, );
        }

        #endregion
    }
}
