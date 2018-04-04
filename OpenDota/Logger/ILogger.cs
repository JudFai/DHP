using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDota.Logger
{
    interface ILogger
    {
        void WriteLog(string format, object param1);
        void WriteLog(string row);
        void WriteLog();
    }
}
