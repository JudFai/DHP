using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaHeroPicker
{
    public class LanePresence
    {
        #region Properties

        public DotaLane Lane { get; private set; }
        public double PercentagePresence { get; private set; }

        #endregion

        #region Constructors

        public LanePresence(DotaLane lane, double percentagePresence)
        {
            Lane = lane;
            PercentagePresence = percentagePresence;
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return string.Format("{0}: {1}%", Lane.HtmlName, PercentagePresence);
        }

        #endregion
    }
}
