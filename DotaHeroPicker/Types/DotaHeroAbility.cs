using DotaHeroPicker.Types.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaHeroPicker.Factories;

namespace DotaHeroPicker.Types
{
    public class DotaHeroAbility : DotaBase<Ability>
    {
        #region Fields

        public static DotaHeroAbility AttributeBonus =
            Factory.CreateElement(new DotaName<Ability>(Ability.AttributeBonus, "Attribute Bonus"));

        #endregion

        #region Properties

        internal static DotaHeroAbilityFactory Factory
        {
            get { return DotaHeroAbilityFactory.GetInstance(); }
        }

        #endregion

        #region Constructors

        private DotaHeroAbility(DotaName<Ability> dotaName)
            : base(dotaName)
        {
            
        }

        #endregion
    }
}
