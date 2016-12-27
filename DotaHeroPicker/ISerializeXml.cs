using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaHeroPicker
{
    interface ISerializeXml<T> where T : class
    {
        string PathToXml { get; }
        T ReadXml();
        bool WriteXml(T obj);
    }
}
