using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afterman.nStuff.Core.Core.Extensions.Dates
{
    public static class DateRoundingExtensions
    {
        private static DateTime? DropSeconds(this DateTime? date)
        {
            return date.HasValue
                ? new DateTime(date.Value.Year
                , date.Value.Month
                , date.Value.Day
                , date.Value.Hour
                , date.Value.Minute
                , date.Value.Second)
                : default(DateTime?);
        }
    }
}
