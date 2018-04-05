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

        #endregion
    }
}
