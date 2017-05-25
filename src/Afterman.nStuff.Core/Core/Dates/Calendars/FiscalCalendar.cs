namespace Afterman.nStuff.Core.Core.Dates.Calendars
{
    using System;


    

    public class FiscalCalendar : IFiscalCalendar
    {
        public DateTime ClosestSundayForDate(DateTime dateTime)
        {
            var dayOfWeek = (int) dateTime.DayOfWeek;

            return dayOfWeek > 3 ? (dateTime.AddDays(7 - dayOfWeek)) : (dateTime.AddDays(-1*dayOfWeek));
        }

        public DateTime FiscalYearEndDateForCalendarYear(int year)
        {
            return (ClosestSundayForDate(LastSeptemberDateForCalendarYear(year)));
        }

        public DateTime LastSeptemberDateForCalendarYear(int year)
        {
            return (new DateTime(year, 9, 30));
        }

        public int FiscalYearForCalendarDate(DateTime dateTime)
        {
            DateTime targetDate = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0);

            if (targetDate > FiscalYearEndDateForCalendarYear(targetDate.Year))
                return (targetDate.Year + 1);
            else
                return (targetDate.Year);
        }

        public DateTime FiscalYearBeginDateForFiscalYear(int year)
        {
            return FiscalYearEndDateForCalendarYear(year - 1).AddDays(1);
        }

        public DateTime FiscalYearEndDateForFiscalYear(int year)
        {
            return FiscalYearEndDateForCalendarYear(year);
        }

        public int FiscalWeekForDate(DateTime dateTime)
        {
            DateTime currentWeekDateEnd =
                FiscalYearBeginDateForFiscalYear(FiscalYearForCalendarDate(dateTime)).AddDays(7);
            int currentWeek = 1;
            DateTime targetDate = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0);

            while (currentWeek < 54)
            {
                if (targetDate < currentWeekDateEnd)
                {
                    return currentWeek;
                }
                ++currentWeek;
                currentWeekDateEnd = currentWeekDateEnd.AddDays(7);
            }
            return 0;
        }

        public int FiscalPeriodForDate(DateTime dateTime)
        {
            int fiscalWeek = FiscalWeekForDate(dateTime);
            if (fiscalWeek > 0)
            {
                int aPeriod = fiscalWeek/4;
                if (fiscalWeek == 53)
                {
                    return aPeriod;
                }
                else
                {
                    return (fiscalWeek%4) > 0 ? aPeriod + 1 : aPeriod;
                }
            }
            return 0;
        }
    }
}
