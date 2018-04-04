using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OpenDota
{
    class DataExplorerUrlBuilder : IDataExplorerUrlBuilder
    {
        #region Fields

        private readonly string _openDotaApiExplorer = @"https://api.opendota.com/api/explorer?sql={0}";
        private readonly string _openDotaApiPlayerMatches = @"https://api.opendota.com/api/players/{0}/matches";

        #endregion

        #region Private Methods

        private string GetSqlQueryFromFile(string fileName)
        {
            string commandText;
            var thisAssembly = Assembly.GetExecutingAssembly();
            var fullPath = string.Format("OpenDota.SqlQueries.{0}", fileName);
            using (var s = thisAssembly.GetManifestResourceStream(fullPath))
            {
                using (var sr = new StreamReader(s))
                {
                    commandText = sr.ReadToEnd();
                }
            }

            return commandText;
        }

        private string GetUrlWithSqlQuery(string fileName)
        {
            var commandText = GetSqlQueryFromFile(fileName);
            return string.Format(_openDotaApiExplorer, HttpUtility.UrlPathEncode(commandText));
        }

        #endregion

        #region IDataExplorerQueryBuilder Members

        public string GetHeroEnemyRationCollectionQuery(int beginUnixTimestamp, int endUnixTimestamp)
        {
            return string.Format(GetUrlWithSqlQuery("HeroEnemyRatio.sql"), beginUnixTimestamp, endUnixTimestamp);
        }

        public string GetHeroWinrateCollectionQuery(int beginUnixTimestamp, int endUnixTimestamp)
        {
            return string.Format(GetUrlWithSqlQuery("HeroWinrate.sql"), beginUnixTimestamp, endUnixTimestamp);
        }

        public string GetPlayerMatchCollectionQuery(ulong accountId)
        {
            return string.Format(_openDotaApiPlayerMatches, accountId);
        }

        #endregion
    }
}
