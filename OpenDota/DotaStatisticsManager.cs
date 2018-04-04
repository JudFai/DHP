using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDota
{
    public class DotaStatisticsManager : IDotaStatisticsManager
    {
        #region Fields

        private readonly static object _instanceLocker = new object();
        private static IDotaStatisticsManager _instance;

        #endregion

        #region Properties

        internal IDataExplorer DataExplorer { get; set; }

        public static IDotaStatisticsManager Instance
        {
            get
            {
                lock (_instanceLocker)
                {
                    return _instance ??
                           (_instance = new DotaStatisticsManager());
                }
            }
        }

        #endregion

        #region Consturctors

        private DotaStatisticsManager()
        {

        }

        #endregion

        #region IDotaStatisticsManager Members

        public List<IPlayerMatch> GetJoinMatchesOfPlayers(uint player1, uint player2)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
