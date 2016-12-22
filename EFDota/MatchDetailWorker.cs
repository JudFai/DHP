using EFDota.Types;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDota.Secondary;
using System.Collections.Concurrent;
using System.Text.RegularExpressions;
using System.IO;

namespace EFDota
{
    public class MatchDetailWorker
    {
        #region Constants

        private const string ProcedureForAddingXmlToDB = @"
            BEGIN TRAN
            DECLARE @xml XML 
            SET @xml = 
            (
	            SELECT CONVERT(XML, x, 2)
	            FROM OPENROWSET(BULK '{1}', SINGLE_BLOB) AS T(x)
            )
            DECLARE @hnd INT
            EXEC sp_xml_preparedocument @hnd OUTPUT, @xml
            INSERT INTO {0}.dbo.MatchDetails
            SELECT 
	            ID,
	            MatchSeqNum,
	            Duration,
	            PreGameDuration,
	            StartTime,
	            CASE WHEN RadiantWin = 'true' THEN
		            0
	            ELSE
		            1
	            END AS Winner,
	            GameMode,
	            FirstBloodTime,
	            LobbyType,
	            HumanPlayers,
	            LeagueID,
	            RadiantScore,
	            DireScore,
	            TowerStatusRadiant,
	            TowerStatusDire,
	            BarracksStatusRadiant,
	            BarracksStatusDire,
	            NULLIF(RadiantTeamID, 0) AS RadiantTeamID,
	            NULLIF(RadiantName, '') AS RadiantName,
	            NULLIF(RadiantLogo, 0) AS RadiantLogo,
	            NULLIF(RadiantTeamComplete, '') AS RadiantTeamComplete,
	            NULLIF(DireTeamID, 0) AS DireTeamID,
	            NULLIF(DireName, '') AS DireName,
	            NULLIF(DireLogo, 0) AS DireLogo,
	            NULLIF(DireTeamComplete, '') AS DireTeamComplete
            FROM OPENXML(@hnd, 'result/matches/match[position()>1]', 2) 
            WITH 
            (
	            ID BIGINT 'match_id',
	            MatchSeqNum BIGINT 'match_seq_num',
	            Duration INT 'duration',
	            PreGameDuration INT 'pre_game_duration',
	            StartTime BIGINT 'start_time',
	            RadiantWin NVARCHAR(10) 'radiant_win',
	            GameMode INT 'game_mode',
	            FirstBloodTime INT 'first_blood_time',
	            LobbyType INT 'lobby_type',
	            HumanPlayers INT 'human_players',
	            LeagueID BIGINT 'leagueid',
	            RadiantScore INT 'radiant_score',
	            DireScore INT 'dire_score',
	            TowerStatusRadiant INT 'tower_status_radiant',
	            TowerStatusDire INT 'tower_status_dire',
	            BarracksStatusRadiant INT 'barracks_status_radiant',
	            BarracksStatusDire INT 'barracks_status_dire',
	            RadiantTeamID INT 'radiant_team_id',
	            RadiantName NVARCHAR(max) 'radiant_name',
	            RadiantLogo BIGINT 'radiant_logo',
	            RadiantTeamComplete BIT 'radiant_team_complete',
	            DireTeamID INT 'dire_team_id',
	            DireName NVARCHAR(max) 'dire_name',
	            DireLogo BIGINT 'dire_logo',
	            DireTeamComplete BIT 'dire_team_complete'
            )
            EXEC sp_xml_removedocument @hnd
            INSERT INTO {0}.dbo.MatchPlayers
            SELECT 
	            Players.player.value('(account_id/text())[1]', 'BIGINT') AS AccountID,
	            Players.player.value('(hero_id/text())[1]', 'INT') AS Hero,
	            Players.player.value('(player_slot/text())[1]', 'TINYINT') AS PlayerSlot,
	            CASE WHEN Players.player.value('(player_slot/text())[1]', 'TINYINT') > 4 THEN 
		            1
	            ELSE 
		            0
	            END AS Faction,
	            Players.player.value('(item_0/text())[1]', 'INT') AS Item0,
	            Players.player.value('(item_1/text())[1]', 'INT') AS Item1,
	            Players.player.value('(item_2/text())[1]', 'INT') AS Item2,
	            Players.player.value('(item_3/text())[1]', 'INT') AS Item3,
	            Players.player.value('(item_4/text())[1]', 'INT') AS Item4,
	            Players.player.value('(item_5/text())[1]', 'INT') AS Item5,
	            Players.player.value('(kills/text())[1]', 'INT') AS Kills,
	            Players.player.value('(deaths/text())[1]', 'INT') AS Deaths,
	            Players.player.value('(assists/text())[1]', 'INT') AS Assists,
	            ISNULL(Players.player.value('(leaver_status/text())[1]', 'INT'), 0) AS LeaverStatus,
	            Players.player.value('(last_hits/text())[1]', 'INT') AS LastHits,
	            Players.player.value('(denies/text())[1]', 'INT') AS Denies,
	            Players.player.value('(gold_per_min/text())[1]', 'INT') AS GoldPerMinute,
	            Players.player.value('(xp_per_min/text())[1]', 'INT') AS XpPerMinute,
	            Players.player.value('(level/text())[1]', 'INT') AS [Level],
	            Players.player.value('(hero_damage/text())[1]', 'INT') AS HeroDamage,
	            Players.player.value('(tower_damage/text())[1]', 'INT') AS TowerDamage,
	            Players.player.value('(hero_healing/text())[1]', 'INT') AS HeroHealing,
	            Players.player.value('(gold/text())[1]', 'INT') AS Gold,
	            Players.player.value('(gold_spent/text())[1]', 'INT') AS GoldSpent,
	            Players.player.value('(scaled_hero_damage/text())[1]', 'INT') AS ScaledHeroDamage,
	            Players.player.value('(scaled_tower_damage/text())[1]', 'INT') AS ScaledTowerDamage,
	            Players.player.value('(scaled_hero_healing/text())[1]', 'INT') AS ScaledHeroHealing,
	            Matches.match.value('(match_id/text())[1]', 'BIGINT') AS MatchDetail_ID,
	            Matches.match.value('(match_seq_num/text())[1]', 'BIGINT') AS MatchDetail_MatchDetailSeqNum
            FROM @xml.nodes('result/matches/match[position()>1]') AS Matches(match)
            CROSS APPLY Matches.match.nodes('players/player') AS Players(player)
            COMMIT TRANSACTION";
        public const int MaxMatchDetails = 15000;

        #endregion

        #region Fields

        private static object _contextLocker = new object();
        private static object _collectionLocker = new object();
        private List<MatchDetail> _matchDetailCollection;
        private Task _generalTaskForCollection;
        private bool _handledAnyMatchDetails;
        //private string _currentConnectionName;

        private DatabaseHelper _dbHelper;
        private Logger _logger;

        #endregion

        #region Properties

        //public bool StartedSavingMatches { get; private set; }

        #endregion

        #region Events

        public event EventHandler GotTooManyMatchDetails;
        public event EventHandler HandeledMatches;
        public event EventHandler OverflowedDatabase;

        #endregion

        #region Constructors

        public MatchDetailWorker()
        {
            _matchDetailCollection = new List<MatchDetail>();
            _dbHelper = DatabaseHelper.GetInstance("DotaHeroPicker");
            _logger = Logger.GetInstance("Logs");// new Logger("");
            //_currentConnectionName = "DotaHeroPicker";
        }

        #endregion

        #region Private Methods

        private void OnOverflowedDatabase()
        {
            if (OverflowedDatabase != null)
                OverflowedDatabase(this, EventArgs.Empty);
        }

        private void OnGotTooManyMatchDetails()
        {
            if (GotTooManyMatchDetails != null)
                GotTooManyMatchDetails(this, EventArgs.Empty);
        }

        private void OnHandeledMatches()
        {
            if (HandeledMatches != null)
                HandeledMatches(this, EventArgs.Empty);
        }

        private List<string> GetDatabasesByName(string name)
        {
            using (var dc = new DotaContext(_dbHelper.CurrentDatabaseName))
            {
                var query = @"SELECT name FROM sys.databases WHERE name like @Name";
                return dc.Database.SqlQuery<string>(query, new SqlParameter("Name", string.Format("%{0}%", name))).ToList();
            }
        }

        private bool SetCurrentDbBySize(DotaContext dc, decimal maxSizeForSet)
        {
            var queryForSizeOfDatabase = @"
                SELECT 
	                total_size_mb = CAST(size * 8. / 1024 AS DECIMAL(8, 2))
                FROM sys.master_files 
                WHERE name = @DataBaseName";
            var sizeOfDatabase = dc.Database
                .SqlQuery<decimal>(queryForSizeOfDatabase, new SqlParameter("DataBaseName", _dbHelper.CurrentDatabaseName))
                .FirstOrDefault();
            //Console.WriteLine("Size of DB {0}: {1} Mb", _dbHelper.CurrentDatabaseName, sizeOfDatabase);
            if (sizeOfDatabase > maxSizeForSet)
            {
                _logger.WriteLine(string.Format("{0} size: {1} MB more than max size {2} MB", 
                    _dbHelper.CurrentDatabaseName, sizeOfDatabase, maxSizeForSet));
                _dbHelper.NextDatabaseName();
                OnOverflowedDatabase();
                return true;
            }

            return false;
        }

        #endregion

        #region Public Methods

        public async void StartSavingMatches()
        {
            await Task.Run(() =>
            {
                //if (StartedSavingMatches)
                //    throw new Exception("Started saving matches");

                //lock (_contextLocker)
                //{
                //StartedSavingMatches = true;
                while (true)
                {
                    List<MatchDetail> matchDetailCollection;
                    lock (_collectionLocker)
                    {
                        matchDetailCollection = _matchDetailCollection.Take(100).ToList();
                        if (matchDetailCollection.Count == 0)
                            continue;
                        //if (matchDetailCollection.Count > 0)
                        //{
                        //    _logger.WriteLine(string.Format("{0} Matches Took ({1})",
                        //        matchDetailCollection.Count, string.Join(", ", matchDetailCollection.Select(p => p.MatchSeqNum.ToString()))));
                        //}
                        matchDetailCollection.ForEach(p => _matchDetailCollection.Remove(p));
                    }

                    _handledAnyMatchDetails = matchDetailCollection.Count > 0;
                    //foreach (var md in matchDetailCollection)
                    //{
                    if (_handledAnyMatchDetails)
                    {
                        var sw = new Stopwatch();
                        sw.Start();
                        while (true)
                        {
                            if (matchDetailCollection.Count == 0)
                            {
                                _logger.WriteLine("MatchDetailCollection count is 0");
                                _handledAnyMatchDetails = false;
                                break;
                            }

                            var dc = new DotaContext(_dbHelper.CurrentDatabaseName);
                            try
                            {
                                //dc.BulkInsert(matchDetailCollection);
                                //dc.MatchDetails.Add(md);
                                //dc.BulkInsert(matchDetailCollection);
                                //dc.MatchDetails.AddRange(matchDetailCollection);'
                                //foreach (var match in matchDetailCollection)
                                //{
                                //    dc.Set<MatchDetail>().Add(match);
                                //}
                                //dc.SaveChanges();
                                //dc.BulkSaveChanges();
                                //_logger.WriteLine(string.Format("{0} Matches added successufuly from ({1})",
                                //    matchDetailCollection.Count,
                                _logger.WriteLine(string.Format("{0} Matches added successufuly from", matchDetailCollection.Count));
                                //    string.Join(",", matchDetailCollection.Select(p => p.MatchSeqNum.ToString()))));
                                break;
                                //lock (_collectionLocker)
                                //{
                                //    //_matchDetailCollection.Remove(md);
                                //    matchDetailCollection.ForEach(p => _matchDetailCollection.Remove(p));
                                //}
                            }
                            catch (DbUpdateException ex)
                            {
                                if (!SetCurrentDbBySize(dc, 10000))
                                {
                                    //if (ex == 2627)
                                    //{
                                    //    var regex = Regex.Match(ex.Message, @"\((?<id>\d+)\,\s(?<seq>\d+)\)");
                                    //    var seqMatch = long.Parse(regex.Groups["seq"].Value);
                                    //    matchDetailCollection.Remove(matchDetailCollection.FirstOrDefault(p => p.MatchSeqNum == seqMatch));
                                    //    _logger.WriteLine(string.Format("Duplicate MatchSeqNum: {0}", seqMatch));
                                    //}
                                }

                                //lock (_collectionLocker)
                                //{
                                //    _matchDetailCollection.AddRange(matchDetailCollection);
                                //}
                            }
                            catch (SqlException ex)
                            {
                                if (!SetCurrentDbBySize(dc, 10000))
                                {
                                    if (ex.Number == 2627)
                                    {
                                        var regex = Regex.Match(ex.Message, @"\((?<id>\d+)\,\s(?<seq>\d+)\)");
                                        var seqMatch = long.Parse(regex.Groups["seq"].Value);
                                        matchDetailCollection.Remove(matchDetailCollection.FirstOrDefault(p => p.MatchSeqNum == seqMatch));
                                        _logger.WriteLine(string.Format("Duplicate MatchSeqNum: {0}", seqMatch));
                                        continue;
                                    }
                                }
                                else
                                {
                                    //lock (_collectionLocker)
                                    //{
                                    //    _matchDetailCollection.AddRange(matchDetailCollection);
                                    //}
                                }
                            }
                            catch
                            {
                            }
                            finally
                            {
                                dc.Dispose();
                                GC.Collect();
                            }
                        }

                        sw.Stop();
                        //Console.WriteLine("STOPWATCH: {0}", sw.Elapsed.TotalMilliseconds);
                        _logger.WriteLine(string.Format("Stopwatch: {0} MS", sw.Elapsed.TotalMilliseconds));
                        _logger.WriteLine(string.Empty, false);
                        //break;
                    }

                    //lock (_collectionLocker)
                    //{
                    //    if ((_matchDetailCollection.Count == 0) && _handledAnyMatchDetails)
                    //        OnHandeledMatches();
                    //}
                }
                //}
            });
        }

        /// <summary>
        /// Получаем последний MatchSeqNum из всех доступных баз
        /// </summary>
        public long GetLastMatchSeqNum()
        {
            lock (_contextLocker)
            {
                var databases = GetDatabasesByName(_dbHelper.DatabaseName);
                long matchSeqNum = 0;
                foreach (var dbName in databases)
                {
                    using (var dc = new DotaContext(dbName))
                    {
                        var firstMatch = dc.MatchDetails.OrderByDescending(p => p.MatchSeqNum).FirstOrDefault();
                        if ((firstMatch != null) && (firstMatch.MatchSeqNum > matchSeqNum))
                            matchSeqNum = firstMatch.MatchSeqNum;
                    }
                }

                return matchSeqNum;
            }
        }

        public async void AddMatchDetailRange(IEnumerable<MatchDetail> matchDetailRange)
        {
            await Task.Run(() => 
            {
                lock (_collectionLocker)
                {
                    if (_matchDetailCollection.Count > MaxMatchDetails)
                        OnGotTooManyMatchDetails();
                    else
                    {
                        _matchDetailCollection.AddRange(matchDetailRange);
                        //_logger.WriteLine(string.Format("Total matches for handling: {0}", _matchDetailCollection.Count));
                        //_logger.WriteLine(string.Format("{0} Matches added ({1})", 
                        //    matchDetailRange.Count(), string.Join(", ", matchDetailRange.Select(p => p.MatchSeqNum.ToString()))));
                        //_logger.WriteLine(string.Empty, false);
                    }
                }
            });
        }

        /// <summary>
        /// Сохраняет детали матчей(кроме первого) из xml в базу данных
        /// </summary>
        public void SaveMatchDetailsByXmlPath(string xmlPath)
        {
            lock (_contextLocker)
            {
                using (var dc = new DotaContext(_dbHelper.CurrentDatabaseName))
                {
                    try
                    {
                        var sw = new Stopwatch();
                        sw.Start();
                        var fullXmlPath = Path.Combine(Directory.GetCurrentDirectory(), xmlPath);
                        dc.Database.ExecuteSqlCommand(string.Format(ProcedureForAddingXmlToDB,
                            _dbHelper.CurrentDatabaseName, fullXmlPath));
                        File.Delete(fullXmlPath);
                        sw.Stop();
                        _logger.WriteLine(string.Format("Added in sql by path '{0}' in {1}", 
                            fullXmlPath, 
                            TimeSpan.FromMilliseconds(sw.ElapsedMilliseconds).ToString(@"hh\:mm\:ss\.fff")));
                    }
                    catch (DbUpdateException ex)
                    {
                    }
                    catch (SqlException ex)
                    {
                        if (!SetCurrentDbBySize(dc, 10000))
                        {
                            if (ex.Number == 2627)
                            {
                                var regex = Regex.Match(ex.Message, @"\((?<id>\d+)\,\s(?<seq>\d+)\)");
                                var seqMatch = long.Parse(regex.Groups["seq"].Value);
                                _logger.WriteLine(string.Format("Duplicate MatchSeqNum: {0} in {1}", seqMatch, xmlPath));
                            }
                        }
                    }
                }

                GC.Collect();
            }
        }

        #endregion
    }
}
