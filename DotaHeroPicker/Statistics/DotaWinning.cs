using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaHeroPicker.Statistics
{
    class DotaWinning : IDotaWinning
    {
        #region Constructors

        public DotaWinning(TimeSpan duration, double percentage, int matches)
        {
            Duration = duration;
            Percentage = percentage;
            Matches = matches;
            var wins = Convert.ToInt32(Math.Round(matches * (percentage / 100)));
            var loses = matches - wins;
            Wins = wins;
            Loses = loses;
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return string.Format("Percentage: {0:F2}%", Percentage);
        }

        #endregion

        #region IDotaWinning Members

        public double Percentage { get; private set; }
        public TimeSpan Duration { get; private set; }
        public int Matches { get; private set; }
        public int Wins { get; private set; }
        public int Loses { get; private set; }

        #endregion

    }
}
