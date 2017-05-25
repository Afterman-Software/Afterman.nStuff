using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afterman.nStuff.Core.Core.Dates
{
    /// <summary>
    /// Provides date ranges between two given dates
    /// </summary>
    public class DateRangeProvider : IDateRangeProvider
    {
        /// <summary>
        /// Provides an <see cref="IEnumerable{DateTime}"/> which represents all days between two dates
        /// </summary>
        /// <param name="start">Start Date (Start of Date Range)</param>
        /// <param name="end">End Date (End of Date Range)</param>
        /// <param name="includeBeginning">Include Start Date</param>
        /// <param name="includeEnding">Include End Date</param>
        /// <returns></returns>
        public IEnumerable<DateTime> GetAllDatesBetween(DateTime start, DateTime end, bool includeBeginning, bool includeEnding)
        {
            start = start.Date;
            end = end.Date;
            var current = includeBeginning ? start : start.AddDays(1);
            while (current < end)
            {
                yield return current;
                current = current.AddDays(1);
            }
            if (includeEnding)
                yield return end;
        }
    }
}
