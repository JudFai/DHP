using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaHeroPicker.Types;

namespace DotaApi.Types
{
    public class Match
    {
        #region Properties

        public ulong MatchID { get; private set; }
        /// <summary>
        /// Номер, который формируется в процессе по записи
        /// </summary>
        public ulong MatchSeqNum { get; private set; }
        public ulong StartTimeInSeconds { get; private set; }
        public DateTime StartTime { get; private set; }

        #endregion

        #region Constructors

        public Match(ulong matchID, ulong matchSeqNum, ulong startTimeInSeconds)
        {
            MatchID = matchID;
            MatchSeqNum = matchSeqNum;
            StartTimeInSeconds = startTimeInSeconds;
            StartTime = DateTime.SpecifyKind(new DateTime(1970, 1, 1), DateTimeKind.Utc).AddSeconds(startTimeInSeconds);
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
