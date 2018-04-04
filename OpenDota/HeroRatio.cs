using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDota
{
    class HeroRatio : IHeroRatio
    {
        #region IHeroRation Members

        public int HeroID { get; set; }
        public int InterplayHeroID { get; set; }
        public int Matches { get; set; }
        public int Wins { get; set; }

        #endregion
    }
}
