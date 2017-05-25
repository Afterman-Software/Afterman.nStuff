namespace Afterman.nStuff.Core.Defensive.AssertionSets
{
    public partial class AssertionSet
    {
        public AssertionSet IsZero(decimal value)
        {
            return this.Test(value
                , x => 0 == x
                , nameof(value)
                , "Zero");
        }

        public AssertionSet IsNegative(decimal value)
        {
            return this.Test(value
                , x => x < 0
                , nameof(value)
                , "Negative");
        }

        public AssertionSet IsPositive(decimal value)
        {
            return this.Test(value
                , x => x > 0
                , nameof(value)
                , "Positive");
        }

        public AssertionSet IsNull(decimal? value)
        {
            return this.Test(value
                , x => x.HasValue == false
                , nameof(value)
                , "NULL");
        }

        
    }
}
