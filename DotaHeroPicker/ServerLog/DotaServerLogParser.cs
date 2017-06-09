using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace DotaHeroPicker.ServerLog
{
    class DotaServerLogParser : IDotaServerLogParser
    {
        #region Fields

        private static readonly object _instanceLocker = new object();
        private static IDotaServerLogParser _instance;

        private readonly string _generalPattern = @"(?<time>\d{2}\/\d{2}\/\d{4}\s\-\s\d{2}\:\d{2}\:\d{2})\:\s\=\[\w{1}:\d+:\d+\:\d+\]\s\(Lobby\s(?<lobby>\d+)\s(?<mode>[\w_]+)(?<players>(\s\d+:\[\w{1}:\d+:\d+\])+)\)\s\(Party\s(?<party>\d+)(?<party_players>(\s\d+:\[\w+:\d+:\d+\])+)\)";
        private readonly string _playerPattern = @"(?<slot>\d+)\:\[\w+\:\d+\:(?<id>\d+)\]";

        #endregion

        #region Properties

        public static IDotaServerLogParser Instance
        {
            get
            {
                lock (_instanceLocker)
                {
                    return _instance ??
                           (_instance = new DotaServerLogParser());
                }
            }
        }

        #endregion

        #region IDotaServerLogParser Members

        public IDotaLobby TryParse(string rowServerLog)
        {
            var generalMatch = Regex.Match(rowServerLog, _generalPattern);
            if (!generalMatch.Success)
                return null;

            var playersMatchs = Regex.Matches(generalMatch.Groups["players"].Value, _playerPattern);
            var partyPlayersMatchs = Regex.Matches(generalMatch.Groups["party_players"].Value, _playerPattern);

            var players = new List<IDotaPlayer>();
            foreach (Match playersMatch in playersMatchs)
            {
                var slot = int.Parse(playersMatch.Groups["slot"].Value);
                var playerId = ulong.Parse(playersMatch.Groups["id"].Value);
                players.Add(new DotaPlayer(playerId, slot));
            }

            var partyPlayers = new List<IDotaPlayer>();
            foreach (Match playersMatch in partyPlayersMatchs)
            {
                var playerId = ulong.Parse(playersMatch.Groups["id"].Value);
                partyPlayers.Add(players.FirstOrDefault(p => p.ID == playerId));
            }

            var partyId = ulong.Parse(generalMatch.Groups["party"].Value);
            var party = new DotaParty(partyPlayers, partyId);
            var loggingTime = DateTime.ParseExact(generalMatch.Groups["time"].Value, "MM/dd/yyyy - HH:mm:ss",
                new DateTimeFormatInfo());
            var lobbyId = ulong.Parse(generalMatch.Groups["lobby"].Value);

            return new DotaLobby(party, players, loggingTime, lobbyId);
        }

        #endregion

    }
}
