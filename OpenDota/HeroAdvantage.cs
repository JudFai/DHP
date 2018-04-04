using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDota
{
    class HeroAdvantage : IHeroAdvantage
    {
        #region Constrcutors

        public HeroAdvantage(int heroID, int interplayHeroID, int matches, double advantagePercentage)
        {
            HeroID = heroID;
            InterplayHeroID = interplayHeroID;
            Matches = matches;
            AdvantagePercentage = advantagePercentage;
        }

        #endregion

        #region IHeroAdvantageEnemy Members

        public int HeroID { get; private set; }
        public int InterplayHeroID { get; private set; }
        public int Matches { get; private set; }
        public double AdvantagePercentage { get; private set; }

        #endregion
    }
}
