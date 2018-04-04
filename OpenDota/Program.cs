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
    class Program
    {
        static void Main(string[] args)
        {
            //var dataMath = DataMath.Instance;
            //var test = dataMath.GetHeroAdvantageEnemyCollection(new DateTime(2017, 11, 1), DateTime.Now);
            var dataExplorer = new DataExplorer();
            var test = dataExplorer.GetPlayerMatchCollection(114115565);

            Console.ReadKey(true);
        }
    }
}
