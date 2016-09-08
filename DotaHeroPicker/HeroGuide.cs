using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaHeroPicker.Types;

namespace DotaHeroPicker
{
    public class HeroGuide
    {
        #region Properties

        public DotaHero Hero { get; private set; }
        public ReadOnlyCollection<GameGuide> Guides { get; private set; }

        #endregion

        #region Constructors

        public HeroGuide(DotaHero hero, IEnumerable<GameGuide> guides)
        {
            Hero = hero;
            Guides = new ReadOnlyCollection<GameGuide>(guides.ToList());
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return Hero.ToString();
        }

        #endregion
    }
}
