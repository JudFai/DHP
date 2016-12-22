using EFDota.Secondary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EFDota
{
    public class MatchDetailsXmlToDbWorker : IDisposable
    {
        #region Constants

        private const int MaxIncrement = 10;

        #endregion
        
        #region Fields

        private int _incrementXml = 0;

        private readonly string _pathToFolder;
        private FileSystemWatcher _fileWatcher;

        private XDocument _xml;
        private Logger _logger;
        private readonly object _xmlLocker = new object();

        #endregion

        #region Events

        public event EventHandler<string> CreatedMatchDetailsXml;

        #endregion

        #region Constructors

        public MatchDetailsXmlToDbWorker(string pathToFolder)
        {
            _pathToFolder = pathToFolder;
            _xml = new XDocument();
            _logger = Logger.GetInstance("Logs");
        }

        #endregion

        #region Private Methods

        private void InitFileSystemWatcher()
        {
            if (!Directory.Exists(_pathToFolder))
                Directory.CreateDirectory(_pathToFolder);

            _fileWatcher = new FileSystemWatcher(_pathToFolder, "*.xml");
            _fileWatcher.NotifyFilter = NotifyFilters.FileName;
            _fileWatcher.Created += OnCreatedXml;
            _fileWatcher.EnableRaisingEvents = true;
        }

        private void OnCreatedXml(object sender, FileSystemEventArgs e)
        {
            OnCreatedMatchDetailsXml(e.FullPath);
        }

        #endregion

        #region Private Methods

        private void OnCreatedMatchDetailsXml(string e)
        {
            if (CreatedMatchDetailsXml != null)
                CreatedMatchDetailsXml(this, e);
        }

        #endregion

        #region Public Methods

        public void StartMonitor()
        {
            InitFileSystemWatcher();
        }

        public void AddMatchDetailsToXml(XDocument xml)
        {
            lock (_xmlLocker)
            {
                _xml = new XDocument(new XElement("result", _xml.Descendants("matches").Union(xml.Descendants("matches"))));
                if (++_incrementXml >= MaxIncrement)
                {
                    var pathToFile = Path.Combine(_pathToFolder, string.Format("{0}.xml", DateTime.Now.Ticks));
                    _xml.Save(pathToFile);
                    _logger.WriteLine(string.Format("Saved xml by path '{0}'", pathToFile));
                    OnCreatedMatchDetailsXml(pathToFile);
                    _xml = new XDocument();
                    _incrementXml = 0;
                }
            }
        }

        public void Dispose()
        {
            _fileWatcher.Dispose();
            _fileWatcher = null;
        }

        #endregion
    }
}
