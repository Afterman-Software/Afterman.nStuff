namespace Afterman.nStuff.Core.Defensive.AssertionSets
{
    using System;
    using System.Data.SqlTypes;

    public partial class AssertionSet
    {
        public AssertionSet IsMinDate(DateTime value)
        {
            return this.Test(value
                , x => x == DateTime.MinValue
                , nameof(value)
                , "DateTime.MinDate");
        }

        public AssertionSet IsSqlMinDate(DateTime value)
        {
            return this.Test(value
                , x => x == SqlDateTime.MinValue.Value
                , nameof(value)
                , "SqlDateTime.MinDate");
        }

        public AssertionSet IsMaxDate(DateTime value)
        {
            return this.Test(value
                , x => x == DateTime.MaxValue
                , nameof(value)
                , "DateTime.MaxDate");
        }

        public AssertionSet IsNull(DateTime? value)
        {
            return this.Test(value
                , x => x.HasValue == false
                , nameof(value)
                , "NULL");
        }

        public AssertionSet IsToday(DateTime value)
        {
            return this.Test(value
                , x => x.Date == DateTime.Now.Date
                , nameof(value)
                , "Today");
        }

        public AssertionSet IsTomorrow(DateTime value)
        {
            return this.Test(value
                , x => x.Date == DateTime.Now.AddDays(1).Date
                , nameof(value)
                , "Tomorrow");
        }

        public AssertionSet IsYesterday(DateTime value)
        {
            return this.Test(value
                , x => x.Date == DateTime.Now.AddDays(-1).Date
                , nameof(value)
                , "Yesterday");
        }

        public AssertionSet IsDayOfWeek(DateTime value, DayOfWeek dayOfWeek)
        {
            return this.Test(value
                , x => x.Date.DayOfWeek == dayOfWeek
                , nameof(value)
                , $"DayOfWeek {Enum.GetName(typeof(DayOfWeek),dayOfWeek)}");
        }

        public AssertionSet IsDayOfMonth(DateTime value, int dayOfMonth)
        {
            return this.Test(value
                , x => x.Date.Day == dayOfMonth
                , nameof(value)
                , $"DayOfMonth {dayOfMonth}");
        }

        
    }
}
