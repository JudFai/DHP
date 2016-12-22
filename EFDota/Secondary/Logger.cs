using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDota.Secondary
{
    public class Logger
    {
        #region Constants

        private const string SeparatorBetweenStarts = "================================================================================";

        #endregion

        #region Fields

        private object _fileLocker = new object();
        private static object _instanceLocker = new object();

        private static Logger _instance;

        private DateTime _lastDate;
        private bool _notWrote;
        private string _pathToFolder;        

        #endregion

        #region Constructors

        /// <summary>
        /// Автоматически создаёт папку, а также файл в этой папке формата dd-MM-yyyy.txt
        /// </summary>
        /// <param name="pathToFolder">Путь до папки</param>
        private Logger(string pathToFolder)
        {
            _lastDate = DateTime.Now.Date;
            _pathToFolder = pathToFolder;
            _notWrote = true;
        }

        #endregion

        #region Public Methods

        public void WriteLine(string message, bool withTime = true)
        {
            lock (_fileLocker)
            {
                try
                {
                    var now = DateTime.Now;
                    var row = withTime
                        ? string.Format("<{0:HH:mm:ss}> {1}", now, message)
                        : message;
                    if (now.Date != _lastDate.Date)
                        _lastDate = now.Date;

                    if (!Directory.Exists(_pathToFolder))
                        Directory.CreateDirectory(_pathToFolder);

                    var pathToFile = Path.Combine(_pathToFolder, string.Format("{0:dd-MM-yyyy}.txt", now));
                    using (var sw = new StreamWriter(pathToFile, true))
                    {
                        if (_notWrote)
                        {
                            sw.WriteLine(SeparatorBetweenStarts);
                            _notWrote = false;
                        }

                        sw.WriteLine(row);
                        Console.WriteLine(row);
                    }
                }
                catch
                {
                    // Игнорируем, т.к. полученная информация понадобится лишь нам
                }
            }
        }

        public void WriteLine()
        {
            WriteLine(string.Empty, false);
        }

        public static Logger GetInstance(string pathToFolder = null)
        {
            lock (_instanceLocker)
            {
                if (_instance == null)
                {
                    if (string.IsNullOrEmpty(pathToFolder))
                        throw new Exception("Instance has not been created");

                    _instance = new Logger(pathToFolder);
                }

                return _instance;
            }
        }

        #endregion
    }
}
