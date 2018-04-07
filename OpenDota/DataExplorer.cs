using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using OpenDota.Extensions;
using OpenDota.Logger;
using OpenDota.Types;

namespace OpenDota
{
    class DataExplorer : IDataExplorer
    {
        #region Fields

        /// <summary>
        /// Максимальный промежуток времени за который можно получать данные
        /// </summary>
        private readonly TimeSpan MaxDeltaTimeSpan = TimeSpan.FromHours(6);

        private readonly IDataExplorerUrlBuilder _urlBuilder = new DataExplorerUrlBuilder();
        private readonly ILogger _logger = InternalLogger.GetInstance();
        private readonly static object _webReqLocker = new object();

        #endregion

        #region Private Methods

        private string GetContentByUrl(string url)
        {
            lock (_webReqLocker)
            {
                var webRequest = WebRequest.Create(url);

                string strContent = string.Empty;
                using (var response = webRequest.GetResponse())
                using (var content = response.GetResponseStream())
                using (var reader = new StreamReader(content))
                {
                    strContent = reader.ReadToEnd();
                }

                return strContent;
            }
        }

        private List<IHeroRatio> GetHeroEnemyRationCollection(int beginUnixTimestamp, int endUnixTimestamp)
        {
            var sw = Stopwatch.StartNew();
            long totalElapsedMilliseconds = 0;

            string content;
            List<IHeroRatio> heroRatioCollection;
            try
            {
                var url = _urlBuilder.GetHeroEnemyRationCollectionQuery(beginUnixTimestamp, endUnixTimestamp);

                sw.Stop();
                totalElapsedMilliseconds += sw.ElapsedMilliseconds;
                _logger.WriteLog("URL BUILD: {0} ms", sw.ElapsedMilliseconds);
                sw = Stopwatch.StartNew();

                content = GetContentByUrl(url);

                sw.Stop();
                totalElapsedMilliseconds += sw.ElapsedMilliseconds;
                _logger.WriteLog("GET CONTENT: {0} ms", sw.ElapsedMilliseconds);
                sw = Stopwatch.StartNew();

                var jObject = JObject.Parse(content);

                sw.Stop();
                totalElapsedMilliseconds += sw.ElapsedMilliseconds;
                _logger.WriteLog("PARSE: {0} ms", sw.ElapsedMilliseconds);
                sw = Stopwatch.StartNew();

                heroRatioCollection = jObject["rows"]
                    .Select(p => new HeroRatio
                    {
                        HeroID = Convert.ToInt32(p["id"].ToString()),
                        InterplayHeroID = Convert.ToInt32(p["hero_id"].ToString()),
                        Matches = Convert.ToInt32(p["matches"].ToString()),
                        Wins = Convert.ToInt32(p["wins"].ToString())
                    })
                    .Cast<IHeroRatio>().ToList();

                sw.Stop();
                totalElapsedMilliseconds += sw.ElapsedMilliseconds;
                _logger.WriteLog("CONVERT: {0} ms", sw.ElapsedMilliseconds);
                _logger.WriteLog("========================================");
                _logger.WriteLog("TOTAL: {0} ms", totalElapsedMilliseconds);
                _logger.WriteLog();
            }
            catch (Exception ex)
            {
                _logger.WriteLog(ex.Message);
                throw;
            }

            return heroRatioCollection;
        }

        private List<IHeroWinrate> GetHeroWinrateCollection(int beginUnixTimestamp, int endUnixTimestamp)
        {
            var sw = Stopwatch.StartNew();
            long totalElapsedMilliseconds = 0;

            string content;
            List<IHeroWinrate> heroWinrateCollection;
            try
            {
                var url = _urlBuilder.GetHeroWinrateCollectionQuery(beginUnixTimestamp, endUnixTimestamp);

                sw.Stop();
                totalElapsedMilliseconds += sw.ElapsedMilliseconds;
                _logger.WriteLog("URL BUILD: {0} ms", sw.ElapsedMilliseconds);
                sw = Stopwatch.StartNew();

                content = GetContentByUrl(url);

                sw.Stop();
                totalElapsedMilliseconds += sw.ElapsedMilliseconds;
                _logger.WriteLog("GET CONTENT: {0} ms", sw.ElapsedMilliseconds);
                sw = Stopwatch.StartNew();

                var jObject = JObject.Parse(content);

                sw.Stop();
                totalElapsedMilliseconds += sw.ElapsedMilliseconds;
                _logger.WriteLog("PARSE: {0} ms", sw.ElapsedMilliseconds);
                sw = Stopwatch.StartNew();

                heroWinrateCollection = jObject["rows"]
                    .Select(p => new HeroWinrate
                    {
                        HeroID = Convert.ToInt32(p["id"].ToString()),
                        Matches = Convert.ToInt32(p["matches"].ToString()),
                        Wins = Convert.ToInt32(p["wins"].ToString())
                    })
                    .Cast<IHeroWinrate>().ToList();

                sw.Stop();
                totalElapsedMilliseconds += sw.ElapsedMilliseconds;

                _logger.WriteLog("CONVERT: {0} ms", sw.ElapsedMilliseconds);
                _logger.WriteLog("========================================");
                _logger.WriteLog("TOTAL: {0} ms", totalElapsedMilliseconds);
                _logger.WriteLog();

            }
            catch (Exception ex)
            {
                _logger.WriteLog(ex.Message);
                throw;
            }

            return heroWinrateCollection;
        }

        #endregion

        #region IDataExplorer Members

        public List<IHeroRatio> GetHeroEnemyRatioCollection(DateTime beginDt, DateTime endDt)
        {
            if (endDt < beginDt)
                throw new ArgumentException("beginDt greater than endDt");

            var delta = endDt - beginDt;
            int beginUnix = 0;
            int endUnix = 0;
            var heroEnemyRatioCollection = new List<IHeroRatio>();
            for (double i = 0; i < delta.TotalSeconds; i += MaxDeltaTimeSpan.TotalSeconds)
            {
                DateTime localBegint = beginDt.AddSeconds(i);
                DateTime localEndDt = i + MaxDeltaTimeSpan.TotalSeconds < delta.TotalSeconds
                    ? beginDt.AddSeconds(i + MaxDeltaTimeSpan.TotalSeconds)
                    : endDt;

                var pertiodHeroEnemyRatioCollection = GetHeroEnemyRationCollection(localBegint.GetUnixTimestamp(), localEndDt.GetUnixTimestamp());
                heroEnemyRatioCollection.AddRange(pertiodHeroEnemyRatioCollection);
            }

            heroEnemyRatioCollection = heroEnemyRatioCollection
                .GroupBy(p => new { p.HeroID, p.InterplayHeroID })
                .Select(p => new HeroRatio 
                {
                    HeroID = p.Key.HeroID,
                    InterplayHeroID = p.Key.InterplayHeroID,
                    Matches = p.Sum(a => a.Matches),
                    Wins = p.Sum(a => a.Wins)
                })
                .OrderByDescending(p => p.Matches)
                .Cast<IHeroRatio>().ToList();

            return heroEnemyRatioCollection;
        }

        public List<IHeroWinrate> GetHeroWinrateCollection(DateTime beginDt, DateTime endDt)
        {
            if (endDt < beginDt)
                throw new ArgumentException("beginDt greater than endDt");

            var delta = endDt - beginDt;
            int beginUnix = 0;
            int endUnix = 0;
            var heroWinrateCollection = new List<IHeroWinrate>();
            for (double i = 0; i < delta.TotalSeconds; i += MaxDeltaTimeSpan.TotalSeconds)
            {
                var localBegint = beginDt.AddSeconds(i);
                var localEndDt = i + MaxDeltaTimeSpan.TotalSeconds < delta.TotalSeconds
                    ? beginDt.AddSeconds(i + MaxDeltaTimeSpan.TotalSeconds)
                    : endDt;

                var pertiodHeroWinrateCollection = GetHeroWinrateCollection(localBegint.GetUnixTimestamp(), localEndDt.GetUnixTimestamp());
                heroWinrateCollection.AddRange(pertiodHeroWinrateCollection);
            }

            heroWinrateCollection = heroWinrateCollection
                .GroupBy(p => p.HeroID)
                .Select(p => new HeroWinrate
                {
                    HeroID = p.Key,
                    Matches = p.Sum(a => a.Matches),
                    Wins = p.Sum(a => a.Wins)
                })
                .OrderByDescending(p => p.Matches)
                .Cast<IHeroWinrate>().ToList();

            return heroWinrateCollection;
        }

        public List<IPlayerMatch> GetPlayerMatchCollection(ulong playerId)
        {
            var sw = Stopwatch.StartNew();
            long totalElapsedMilliseconds = 0;

            string content;
            List<IPlayerMatch> playerMatchCollection;
            try
            {
                var url = _urlBuilder.GetPlayerMatchCollectionQuery(playerId);

                sw.Stop();
                totalElapsedMilliseconds += sw.ElapsedMilliseconds;
                _logger.WriteLog("URL BUILD: {0} ms", sw.ElapsedMilliseconds);
                sw = Stopwatch.StartNew();

                content = GetContentByUrl(url);

                sw.Stop();
                totalElapsedMilliseconds += sw.ElapsedMilliseconds;
                _logger.WriteLog("GET CONTENT: {0} ms", sw.ElapsedMilliseconds);
                sw = Stopwatch.StartNew();

                var jArr = JArray.Parse(content);

                sw.Stop();
                totalElapsedMilliseconds += sw.ElapsedMilliseconds;
                _logger.WriteLog("PARSE: {0} ms", sw.ElapsedMilliseconds);
                sw = Stopwatch.StartNew();

                var utcOffset = TimeZoneInfo.Local.GetUtcOffset(DateTime.UtcNow);
                playerMatchCollection = jArr
                    .Select(p => new PlayerMatch
                    {
                        Assists = Convert.ToInt32(p["assists"].ToString()),
                        Deaths = Convert.ToInt32(p["deaths"].ToString()),
                        Duration = TimeSpan.FromSeconds(Convert.ToInt32(p["duration"].ToString())),
                        GameMode = (GameMode)Convert.ToByte(p["game_mode"].ToString()),
                        Hero = (Hero)Convert.ToInt32(p["hero_id"].ToString()),
                        Kills = Convert.ToInt32(p["kills"].ToString()),
                        LeaverStatus = (LeaverStatus)Convert.ToByte(p["leaver_status"].ToString()),
                        LobbyType = (LobbyType)Convert.ToSByte(p["lobby_type"].ToString()),
                        MatchID = Convert.ToUInt64(p["match_id"].ToString()),
                        PlayerSlot = (PlayerSlot)Convert.ToByte(p["player_slot"].ToString()),
                        StartTime = new DateTime(1970, 1, 1).AddSeconds(Convert.ToUInt64(p["start_time"].ToString())).AddHours(utcOffset.TotalHours),
                        Win = Convert.ToBoolean(p["radiant_win"].ToString()) ? Faction.Radiant : Faction.Dire
                    })
                    .Cast<IPlayerMatch>().ToList();

                sw.Stop();
                totalElapsedMilliseconds += sw.ElapsedMilliseconds;
                _logger.WriteLog("CONVERT: {0} ms", sw.ElapsedMilliseconds);
                _logger.WriteLog("========================================");
                _logger.WriteLog("TOTAL: {0} ms", totalElapsedMilliseconds);
                _logger.WriteLog();
            }
            catch (Exception ex)
            {
                _logger.WriteLog(ex.Message);
                throw;
            }

            return playerMatchCollection;
        }

        public IDotaMatch GetDotaMatch(ulong matchId)
        {
            var sw = Stopwatch.StartNew();
            long totalElapsedMilliseconds = 0;

            string content;
            IDotaMatch dotaMatch;
            try
            {
                var url = _urlBuilder.GetDotaMatchQuery(matchId);

                sw.Stop();
                totalElapsedMilliseconds += sw.ElapsedMilliseconds;
                _logger.WriteLog("URL BUILD: {0} ms", sw.ElapsedMilliseconds);
                sw = Stopwatch.StartNew();

                content = GetContentByUrl(url);

                sw.Stop();
                totalElapsedMilliseconds += sw.ElapsedMilliseconds;
                _logger.WriteLog("GET CONTENT: {0} ms", sw.ElapsedMilliseconds);
                sw = Stopwatch.StartNew();

                var jObject = JObject.Parse(content);
                var utcOffset = TimeZoneInfo.Local.GetUtcOffset(DateTime.UtcNow);
                var players = jObject["players"]
                    .Select(p =>
                    {
                        var rankTierJson = p["rank_tier"];
                        IRankTier rankTier = null;
                        var rankTierNumber = 0;
                        if (int.TryParse(rankTierJson.ToString(), out rankTierNumber))
                        {
                            rankTierNumber = Convert.ToInt32(rankTierJson.ToString());
                            var rankMedal = (RankMedal)Convert.ToInt32(Math.Floor(rankTierNumber / 10d));
                            var rankStars = rankTierNumber % 10;
                            rankTier = new RankTier(rankStars, rankMedal);
                        }
                        ulong accountId = 0;
                        return new DotaPlayerMatch
                        {
                            AccountID = ulong.TryParse(p["account_id"].ToString(), out accountId) ? (ulong?)accountId : null,
                            Assists = Convert.ToInt32(p["assists"].ToString()),
                            Backpack1 = (Item) Convert.ToInt32(p["backpack_0"].ToString()),
                            Backpack2 = (Item) Convert.ToInt32(p["backpack_1"].ToString()),
                            Backpack3 = (Item) Convert.ToInt32(p["backpack_2"].ToString()),
                            Deaths = Convert.ToInt32(p["deaths"].ToString()),
                            Faction =
                                Convert.ToBoolean(p["isRadiant"].ToString()) ? Faction.Radiant : Faction.Dire,
                            Gold = Convert.ToInt32(p["gold"].ToString()),
                            GoldPerMinute = Convert.ToInt32(p["gold_per_min"].ToString()),
                            GoldSpent = Convert.ToInt32(p["gold_spent"].ToString()),
                            Hero = (Hero) Convert.ToInt32(p["hero_id"].ToString()),
                            HeroDamage = Convert.ToInt32(p["hero_damage"].ToString()),
                            HeroHealing = Convert.ToInt32(p["hero_healing"].ToString()),
                            Item1 = (Item)Convert.ToInt32(p["item_0"].ToString()),
                            Item2 = (Item)Convert.ToInt32(p["item_1"].ToString()),
                            Item3 = (Item)Convert.ToInt32(p["item_2"].ToString()),
                            Item4 = (Item)Convert.ToInt32(p["item_3"].ToString()),
                            Item5 = (Item)Convert.ToInt32(p["item_4"].ToString()),
                            Item6 = (Item)Convert.ToInt32(p["item_5"].ToString()),
                            Kills = Convert.ToInt32(p["kills"].ToString()),
                            LastHits = Convert.ToInt32(p["last_hits"].ToString()),
                            LeaverStatus = (LeaverStatus) Convert.ToInt32(p["leaver_status"].ToString()),
                            Level = Convert.ToInt32(p["level"].ToString()),
                            MatchID = Convert.ToUInt64(p["match_id"].ToString()),
                            PersonName = p["personaname"] != null ? p["personaname"].ToString() : null,
                            RankTier = rankTier,
                            Slot = (PlayerSlot)Convert.ToInt32(p["player_slot"].ToString()),
                            TotalGold = Convert.ToInt32(p["total_gold"].ToString()),
                            TotalXp = Convert.ToInt32(p["total_xp"].ToString()),
                            TowerDamage = Convert.ToInt32(p["tower_damage"].ToString()),
                            XpPerMinute = Convert.ToInt32(p["xp_per_min"].ToString())
                        };
                    }).Cast<IDotaPlayerMatch>().ToArray();

                dotaMatch = new DotaMatch
                {
                    BarracksStatusDire = (BarracksStatus)Convert.ToInt32(jObject["barracks_status_dire"].ToString()),
                    BarracksStatusRadiant = (BarracksStatus)Convert.ToInt32(jObject["barracks_status_radiant"].ToString()),
                    DireScore = Convert.ToInt32(jObject["dire_score"].ToString()),
                    Duration = TimeSpan.FromSeconds(Convert.ToInt32(jObject["duration"].ToString())),
                    FirstBloodTime = TimeSpan.FromSeconds(Convert.ToInt32(jObject["first_blood_time"].ToString())),
                    GameMode = (GameMode)Convert.ToInt32(jObject["game_mode"].ToString()),
                    HumanPlayers = Convert.ToInt32(jObject["human_players"].ToString()),
                    LobbyType = (LobbyType)Convert.ToInt32(jObject["lobby_type"].ToString()),
                    MatchID = Convert.ToUInt64(jObject["match_id"].ToString()),
                    MatchSeqNumber = Convert.ToUInt64(jObject["match_seq_num"].ToString()),
                    Players = players,
                    RadiantScore = Convert.ToInt32(jObject["radiant_score"].ToString()),
                    Region = (ServerRegion)Convert.ToInt32(jObject["region"].ToString()),
                    StartTime = new DateTime(1970, 1, 1).AddSeconds(Convert.ToUInt64(jObject["start_time"].ToString())).AddHours(utcOffset.TotalHours),
                    TowerStatusDire = (TowerStatus)Convert.ToInt32(jObject["tower_status_dire"].ToString()),
                    TowerStatusRadiant = (TowerStatus)Convert.ToInt32(jObject["tower_status_radiant"].ToString()),
                    Win = Convert.ToBoolean(jObject["radiant_win"].ToString()) ? Faction.Radiant : Faction.Dire
                };

                sw.Stop();
                totalElapsedMilliseconds += sw.ElapsedMilliseconds;
                _logger.WriteLog("PARSE: {0} ms", sw.ElapsedMilliseconds);
                sw = Stopwatch.StartNew();

                sw.Stop();
                totalElapsedMilliseconds += sw.ElapsedMilliseconds;
                _logger.WriteLog("CONVERT: {0} ms", sw.ElapsedMilliseconds);
                _logger.WriteLog("========================================");
                _logger.WriteLog("TOTAL: {0} ms", totalElapsedMilliseconds);
                _logger.WriteLog();
            }
            catch (Exception ex)
            {
                _logger.WriteLog(ex.Message);
                throw;
            }

            return dotaMatch;
        }

        #endregion
    }
}
