namespace Afterman.nStuff.Core.Defensive.AssertionSets
{
    using System;

    public partial class AssertionSet
    {
        public AssertionSet IsZero(float value, float tolerance = 0.0000001F)
        {
            return this.Test(value
                , x => Math.Abs(x) < tolerance
                , nameof(value)
                , "Zero");
        }

        public AssertionSet IsNegative(float value)
        {
            return this.Test(value
                , x => x < 0
                , nameof(value)
                , "Negative");
        }

        public AssertionSet IsPositive(float value)
        {
            return this.Test(value
                , x => x > 0
                , nameof(value)
                , "Positive");
        }

        public AssertionSet IsNull(float? value)
        {
            return this.Test(value
                , x => x.HasValue == false
                , nameof(value)
                , "NULL");
        }
    }
}
