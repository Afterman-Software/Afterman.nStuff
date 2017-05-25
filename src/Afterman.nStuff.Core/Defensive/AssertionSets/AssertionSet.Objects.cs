namespace Afterman.nStuff.Core.Defensive.AssertionSets
{
    public partial class AssertionSet
    {

        public AssertionSet IsNull(object value)
        {
            return this.Test(value
                , x => null == x
                , nameof(value)
                , "NULL");
        }

        





    }
}
