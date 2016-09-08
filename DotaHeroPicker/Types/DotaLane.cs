using DotaHeroPicker.Factories;
using DotaHeroPicker.Types.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaHeroPicker.Types
{
    public class DotaLane : DotaBase<Lane>
    {
        #region Properties

        internal static DotaLaneFactory Factory
        {
            get { return DotaLaneFactory.GetInstance(); }
        }

        #endregion

        #region Constructors

        private DotaLane(DotaName<Lane> dotaName)
            : base(dotaName)
        {
            
        }

        #endregion
    }
}
