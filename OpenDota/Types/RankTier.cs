using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDota.Types
{
    class RankTier : IRankTier
    {
        #region Consturctors

        public RankTier(int stars, RankMedal medal)
        {
            Stars = stars;
            Medal = medal;
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return string.Format("{0} [{1}]", Medal, Stars);
        }

        #endregion

        #region IRankTier Members

        public RankMedal Medal { get; private set; }
        public int Stars { get; private set; }

        #endregion
    }
}
