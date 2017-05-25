using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afterman.nStuff.Core.Core.Dates.Calendars
{
    public interface IFiscalCalendar
    {
        DateTime ClosestSundayForDate(DateTime dateTime);
        DateTime FiscalYearEndDateForCalendarYear(int year);
        DateTime LastSeptemberDateForCalendarYear(int year);
        int FiscalYearForCalendarDate(DateTime dateTime);
        DateTime FiscalYearBeginDateForFiscalYear(int year);
        DateTime FiscalYearEndDateForFiscalYear(int year);
        int FiscalWeekForDate(DateTime dateTime);
        int FiscalPeriodForDate(DateTime dateTime);
    }
}
