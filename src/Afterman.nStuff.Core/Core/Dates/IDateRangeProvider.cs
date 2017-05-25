using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afterman.nStuff.Core.Core.Dates
{
    public interface IDateRangeProvider
    {
        IEnumerable<DateTime> GetAllDatesBetween(DateTime start, DateTime end, bool includeBeginning, bool includeEnding);
    }
}
