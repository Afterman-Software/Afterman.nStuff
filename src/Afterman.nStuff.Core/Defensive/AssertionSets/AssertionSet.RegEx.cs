namespace Afterman.nStuff.Core.Defensive.AssertionSets
{
    using System.Text.RegularExpressions;

    public partial class AssertionSet
    {
        public AssertionSet IsMatch(string value, string pattern)
        {
            return this.Test(value
                , x => new Regex(pattern).IsMatch(x)
                , nameof(value)
                , $"Regex Match for pattern {pattern}");
        }




    }
}
