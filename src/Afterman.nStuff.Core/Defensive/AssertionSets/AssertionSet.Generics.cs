namespace Afterman.nStuff.Core.Defensive.AssertionSets
{
    public partial class AssertionSet
    {
        public AssertionSet IsDefaultValue<TInput>(TInput value)
        {
            return this.Test(value
               , x => null == x || x.Equals(default(TInput))
               , nameof(value)
               , $"DefaultValue of {typeof(TInput).FullName}");
        }

        public AssertionSet IsImplementedBy<TInputType, TTestType>(TInputType value)
            where TInputType : class
            where TTestType : class
        {
            return this.Test(value
                , x => x is TTestType
                , nameof(value)
                , $"Implements {typeof(TTestType).FullName}");
        }

        
    }
}
