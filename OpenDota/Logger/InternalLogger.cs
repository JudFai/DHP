using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDota.Logger
{
    class InternalLogger : ILogger
    {
        #region Fields

        private static object _instanceLocker = new object();
        private static ILogger _instance;

        #endregion

        #region Constructors

        private InternalLogger() { }

        #endregion

        #region Public Methods

        public static ILogger GetInstance()
        {
            lock (_instanceLocker)
            {
                return _instance ??
                       (_instance = new InternalLogger());
            }
        }

        #endregion

        #region ILogger Members

        public void WriteLog(string format, object param1)
        {
            var row = string.Format(format, param1);
            WriteLog(row);
        }

        public void WriteLog(string row)
        {
#if DEBUG
            Console.WriteLine(row);
#endif
        }

        public void WriteLog()
        {
            WriteLog(string.Empty);
        }

        #endregion
    }
}
