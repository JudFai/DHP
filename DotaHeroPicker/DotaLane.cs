using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaHeroPicker
{
    public class DotaLane
    {
        #region Properties

        public Lane Lane { get; private set; }
        public string HtmlName { get; private set; }

        #endregion

        #region Constructors

        private DotaLane(Lane lane, string htmlName)
        {
            Lane = lane;
            HtmlName = htmlName;
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return string.Format("Lane: {0}", Lane);
        }

        #endregion
    }
}
