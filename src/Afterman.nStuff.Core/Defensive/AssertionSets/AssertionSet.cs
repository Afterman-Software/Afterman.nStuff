namespace Afterman.nStuff.Core.Defensive.AssertionSets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Framework;

    public partial class AssertionSet
    {

        protected readonly AssertionMode Mode;
        protected readonly IList<string> Errors;
        protected readonly AssertionSet ParentAssertionSet;
        protected readonly ValidationMode ValidationMode;

        protected AssertionSet(AssertionMode mode, AssertionSet parentAssertionSet)
        {
            this.Mode = mode;
            this.Errors = new List<string>();
            this.ParentAssertionSet = parentAssertionSet;
        }

        public AssertionSet(ValidationMode validationMode)
            : this(AssertionMode.Is, null)
        {
            this.ValidationMode = validationMode;
        }

        protected AssertionSet Head => null != this.ParentAssertionSet ? this.ParentAssertionSet.Head : this;

        protected virtual void Fail(string message)
        {
            this.Head.Errors.Add(message);
            if (this.Head.ValidationMode == ValidationMode.RealTime)
                throw new InvalidOperationException($"Guard Exception - {message}");
        }

        public virtual void Guard()
        {
            if (this.Head.Errors.Any() == false)
                return;

            var builder = new StringBuilder();
            foreach (var item in this.Head.Errors)
            {
                builder.AppendLine(item);
            }
            throw new InvalidOperationException($"Guard Exception - {builder}");
        }

        public IList<string> GetAllErrors()
        {
            return this.Head.Errors;
        }

        protected virtual AssertionSet Test<TType>(TType value
            , Func<TType, bool> isCondition
            , string parameterName
            , string benchmarkValue = null)
        {
            if (ShouldFail(isCondition(value)))
                Fail(GetErrorMessage(value, parameterName, benchmarkValue));
            return this;
        }

        protected virtual string GetErrorMessage<TType>(TType value, string parameterName, string benchmarkValue = null)
        {
            var modifier = Mode == AssertionMode.Is ? "SHOULD" : "SHOULD NOT";
            return $"{parameterName} {modifier} be {benchmarkValue ?? value?.ToString() ?? "NULL"}";
        }

        protected bool ShouldFail(bool isResult)
        {
            return (Mode == AssertionMode.Is) ? !isResult : isResult;
        }

        public AssertionSet AndThat => new AssertionSet(AssertionMode.Is, this);
        public AssertionSet ButNotThat => new AssertionSet(AssertionMode.IsNot, this);


    }

}
