namespace Afterman.nStuff.Core.Defensive.AssertionSets
{
    public partial class AssertionSet
    {
        public AssertionSet IsZero(short value)
        {
            return this.Test(value
               , x => 0 == x
               , nameof(value)
               , "Zero");
        }

        public AssertionSet IsNegative(short value)
        {
            return this.Test(value
                , x => x < 0
                , nameof(value)
                , "Negative");
        }

        public AssertionSet IsPositive(short value)
        {
            return this.Test(value
                , x => x > 0
                , nameof(value)
                , "Positive");
        }

        public AssertionSet IsZero(ushort value)
        {
            return this.Test(value
               , x => 0 == x
               , nameof(value)
               , "Zero");
        }

        public AssertionSet IsNull(short? value)
        {
            return this.Test(value
                , x => x.HasValue == false
                , nameof(value)
                , "NULL");
        }

        public AssertionSet IsNull(ushort? value)
        {
            return this.Test(value
                , x => x.HasValue == false
                , nameof(value)
                , "NULL");
        }


    }
}
