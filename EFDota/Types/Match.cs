using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaApi.Types
{
    public class Match
    {
        #region Properties

        public ulong MatchID { get; set; }
        /// <summary>
        /// Номер, который формируется в процессе по записи
        /// </summary>
        public ulong MatchSeqNum { get; set; }
        public ulong StartTimeInSeconds { get; set; }
        public DateTime StartTime { get; set; }

        public MatchDetail Detail { get; set; }

        #endregion

        #region Constructors

        public Match(ulong matchID, ulong matchSeqNum, ulong startTimeInSeconds, MatchDetail matchDetail)
        {
            MatchID = matchID;
            MatchSeqNum = matchSeqNum;
            StartTimeInSeconds = startTimeInSeconds;
            StartTime = DateTime.SpecifyKind(new DateTime(1970, 1, 1), DateTimeKind.Utc).AddSeconds(startTimeInSeconds);
            Detail = matchDetail;
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return string.Format("MatchID: {0}", MatchID);
        }

        #endregion
    }
}
