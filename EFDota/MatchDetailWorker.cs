using EFDota.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDota
{
    public class MatchDetailWorker
    {
        #region Fields

        private static object _contextLocker = new object();

        #endregion

        #region Constructors

        public MatchDetailWorker()
        {

        }

        #endregion

        #region Public Methods

        public void SaveMatches(List<MatchDetail> matchDetailCollection)
        {
            lock (_contextLocker)
            {
                using (var dc = new DotaContext())
                {
                    dc.MatchDetails.AddRange(matchDetailCollection);
                    dc.SaveChanges();
                }
            }
        }

        #endregion
    }
}
