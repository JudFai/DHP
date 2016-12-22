using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using EFDota.Types;
using EFDota;
using EFDota.Secondary;
using System.IO;

namespace DotaApi
{
    class Program
    {
        static void Main(string[] args)
        {
            var pathToFolder = "Matches";

            var matchDetailWorker = new MatchDetailWorker();
            var matchDetailsXmlToDbWorker = new MatchDetailsXmlToDbWorker(pathToFolder);
            var api = new ApiWorker("9E08B26E9B8BEB385FF5A94AAFE9466C");
            var test = new Test(matchDetailWorker, api, matchDetailsXmlToDbWorker, pathToFolder);

            matchDetailsXmlToDbWorker.CreatedMatchDetailsXml += test.OnCreatedMatchDetailsXml;
            //matchDetailsXmlToDbWorker.StartMonitor();

            var matchSeqNum = matchDetailWorker.GetLastMatchSeqNum();
            api.ReceivedXmlMatchHistory += test.OnReceivedXmlMatchHistory;

            Task.Run(() => api.StartGettingXmlMatchHistory(matchSeqNum));
            //api.SaveMatchHistory(matchSeqNum, pathToFolder);
            //api.GetXmlMatchHistory(matchSeqNum);
            //matchDetailWorker.StartSavingMatches();
            ////matchDetailWorker.StartSavingMatches();
            ////matchDetailWorker.StartSavingMatches();
            ////matchDetailWorker.StartSavingMatches();
            //matchDetailWorker.GotTooManyMatchDetails += test.OnGotTooManyMatchDetails;
            //matchDetailWorker.HandeledMatches += test.OnHandeledMatches;
            //api.ReceivedMatchHistory += test.OnGotMatchHistory;
            //api.GetMatchHistoryBySequenceNum(matchSeqNum, 100);
            //var test = new MatchDetailsXmlToDbWorker(@"D:\");
            //test.StartMonitorAndSave();
            while (true)
            {
                //var matches = api.GetMatchHistoryBySequenceNum(matchSeqNum, 100).ToList();
                //matchDetailWorker.SaveMatches(matches);
                //matchSeqNum = (ulong)matches.OrderByDescending(p => p.MatchSeqNum).FirstOrDefault().MatchSeqNum;
            }
        }


        class Test
        {
            private string _pathToFolder;

            public MatchDetailWorker MatchDetailWorker { get; private set; }
            public ApiWorker ApiWorker { get; private set; }
            public MatchDetailsXmlToDbWorker MatchDetailsXmlToDbWorker { get; private set; }
            public bool HandelingTooManyMatches { get; private set; }
            public long LastMatchSeqNum {get; private set;}

            public Test(MatchDetailWorker matchDetailWorker, ApiWorker apiWorker, MatchDetailsXmlToDbWorker matchDetailsXmlToDbWorker, string pathToFolder)
            {
                MatchDetailWorker = matchDetailWorker;
                ApiWorker = apiWorker;
                MatchDetailsXmlToDbWorker = matchDetailsXmlToDbWorker;
                _pathToFolder = pathToFolder;
            }

            public void OnCreatedMatchDetailsXml(object sender, string e)
            {
                Task.Run(() => MatchDetailWorker.SaveMatchDetailsByXmlPath(e));
                //MatchDetailWorker.SaveMatchDetailsByXmlPath(e);
            }

            public void OnSavedMatchHistory(object sender, XmlMatchDetailsEventArgs e)
            {
                ApiWorker.SaveMatchHistory(e.MatchSeqNum, _pathToFolder);
            }

            public void OnReceivedXmlMatchHistory(object sender, XmlMatchDetailsEventArgs e)
            {
                MatchDetailsXmlToDbWorker.AddMatchDetailsToXml(e.Xml);
                //ApiWorker.GetXmlMatchHistory(e.MatchSeqNum);
            }
        }
    }
}
