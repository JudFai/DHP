using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDota
{
    interface IDataExplorerUrlBuilder
    {
        string GetHeroEnemyRationCollectionQuery(int beginUnixTimestamp, int endUnixTimestamp);
        string GetHeroWinrateCollectionQuery(int beginUnixTimestamp, int endUnixTimestamp);
        string GetPlayerMatchCollectionQuery(ulong accountId);
        string GetDotaMatchQuery(ulong matchId);
    }
}
