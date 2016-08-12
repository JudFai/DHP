using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaHeroPicker.Types;

namespace DotaHeroPicker
{
    public class HeroLanePresence
    {
        #region Properties

        public DotaHero Hero { get; private set; }
        public ReadOnlyCollection<LanePresence> LanePresenceCollection { get; private set; }

        #endregion

        #region Constructors

        public HeroLanePresence(DotaHero hero, IList<LanePresence> lanePresenceCollection)
        {
            Hero = hero;
            LanePresenceCollection = new ReadOnlyCollection<LanePresence>(lanePresenceCollection);
        }

        #endregion
    }
}
