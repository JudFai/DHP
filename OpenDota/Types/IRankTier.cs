using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDota.Types
{
    public interface IRankTier
    {
        RankMedal Medal { get; }
        int Stars { get; }
    }
}
