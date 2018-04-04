using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDota.Extensions
{
    public static class DateTimeExtensions
    {
        public static int GetUnixTimestamp(this DateTime dt)
        {
            return (int)(dt.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }
    }
}
