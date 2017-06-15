using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaHeroPicker.ServerLog
{
    class DotaServerLogPathWorker : IDotaServerLogPathWorker
    {
        #region IDotaServerLogPathWorker Members

        public string GetPathToServerLog()
        {
            var regKey = Registry.CurrentUser.OpenSubKey(@"Software\Valve\Steam");
            string fullPath = null;
            if (regKey != null)
            {
                var pathToSteam = regKey.GetValue("SteamPath");
                if (pathToSteam != null)
                {
                    var fullPathToDirectory = Path.Combine(pathToSteam.ToString(), @"steamapps/common/dota 2 beta/game/dota");
                    fullPath = Path.Combine(fullPathToDirectory, "server_log.txt");
                    if (!File.Exists(fullPath))
                        fullPath = null;
                }
            }

            return fullPath;
        }

        #endregion
    }
}
