using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaHeroPicker
{
    public class HeroName
    {
        #region Properties

        public Hero Hero { get; private set; }
        public string FullName { get; private set; }
        public string HtmlName { get; private set; }

        #endregion

        #region Constrcutors

        private HeroName()
        { 
        }

        public HeroName(Hero hero, string fullName)
        {
            Hero = hero;
            FullName = fullName;
            HtmlName = fullName.ToLower()
                .Replace(" ", "-")
                .Replace("'", string.Empty);
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return FullName;
        }

        #endregion
    }
}
