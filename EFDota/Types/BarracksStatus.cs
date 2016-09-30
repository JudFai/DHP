using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDota.Types
{
    [Flags]
    public enum BarracksStatus : int
    {
        None = 0,
        TopMelee = 1,
        TopRanged = 2,
        MiddleMelee = 4,
        MiddleRanged = 8,
        BottomMelee = 16,
        BottomRanged = 32
    }
}
