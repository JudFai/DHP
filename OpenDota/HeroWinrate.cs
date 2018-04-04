using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDota
{
    class HeroWinrate : IHeroWinrate
    {
        #region IHeroWinrate Members

        public int HeroID { get; set; }
        public int Matches { get; set; }
        public int Wins { get; set; }

        #endregion
    }
}
