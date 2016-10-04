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

namespace DotaApi
{
    class Program
    {
        static void Main(string[] args)
        {
            var api = new ApiWorker("9E08B26E9B8BEB385FF5A94AAFE9466C");
            var matches = api.GetMatchHistoryBySequenceNum(0, 100).ToList();
            var matchDetailWorker = new MatchDetailWorker();
            matchDetailWorker.SaveMatches(matches);
        }
    }
}
