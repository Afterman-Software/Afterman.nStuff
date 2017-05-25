namespace Afterman.nStuff.Core.Defensive.AssertionSets
{
    public partial class AssertionSet
    {
        public AssertionSet IsZero(long value)
        {
            return this.Test(value
               , x => 0 == x
               , nameof(value)
               , "Zero");
        }

        public AssertionSet IsNegative(long value)
        {
            return this.Test(value
                , x => x < 0
                , nameof(value)
                , "Negative");
        }

        public AssertionSet IsPositive(long value)
        {
            return this.Test(value
                , x => x > 0
                , nameof(value)
                , "Positive");
        }

        public AssertionSet IsZero(ulong value)
        {
            return this.Test(value
               , x => 0 == x
               , nameof(value)
               , "Zero");
        }

        public AssertionSet IsNull(ulong? value)
        {
            return this.Test(value
                , x => x.HasValue == false
                , nameof(value)
                , "NULL");
        }

        public AssertionSet Null(long? value)
        {
            return this.Test(value
                , x => x.HasValue == false
                , nameof(value)
                , "NULL");
        }
    }
}
