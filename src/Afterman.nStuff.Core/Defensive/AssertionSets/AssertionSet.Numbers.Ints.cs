namespace Afterman.nStuff.Core.Defensive.AssertionSets
{
    public partial class AssertionSet
    {
        

        public AssertionSet IsZero(int value)
        {
            return this.Test(value
               , x => 0 == x
               , nameof(value)
               , "Zero");
        }

        public AssertionSet IsNegative(int value)
        {
            return this.Test(value
                , x => x < 0
                , nameof(value)
                , "Negative");
        }

        public AssertionSet IsPositive(int value)
        {
            return this.Test(value
                , x => x > 0
                , nameof(value)
                , "Positive");
        }

        public AssertionSet IsZero(uint value)
        {
            return this.Test(value
               , x => 0 == x
               , nameof(value)
               , "Zero");
        }

        public AssertionSet IsNull(int? value)
        {
            return this.Test(value
                , x => x.HasValue == false
                , nameof(value)
                , "NULL");
        }

        public AssertionSet IsNull(uint? value)
        {
            return this.Test(value
                , x => x.HasValue == false
                , nameof(value)
                , "NULL");
        }








    }
}
