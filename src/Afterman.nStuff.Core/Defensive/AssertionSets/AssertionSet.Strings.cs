namespace Afterman.nStuff.Core.Defensive.AssertionSets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;

    public partial class AssertionSet
    {
        public AssertionSet IsEmptyString(string value)
        {
            return this.Test(value
				, x => x == String.Empty
				, nameof(value)
				, "String.Empty");
        }

        public AssertionSet IsSimpleWhitespace(string value)
        {
            return this.Test(value
				, x => x?.Trim() == String.Empty
				, nameof(value)
				, "simple whitespace");
        }

        public AssertionSet IsInt(string value)
        {
            int targetValue;
            return this.Test(value
                , x => Int32.TryParse(x, out targetValue)
                , nameof(value)
                , $"Integer");
        }

        public AssertionSet IsShort(string value)
        {
            short targetValue;
            return this.Test(value
                , x => Int16.TryParse(x, out targetValue)
                , nameof(value)
                , $"Short");
        }

        public AssertionSet IsLong(string value)
        {
            long targetValue;
            return this.Test(value
                , x => Int64.TryParse(x, out targetValue)
                , nameof(value)
                , $"Long");
        }

        public AssertionSet IsDecimal(string value)
        {
            decimal targetValue;
            return this.Test(value
                , x => Decimal.TryParse(x, out targetValue)
                , nameof(value)
                , $"Decimal");
        }

        public AssertionSet IsDateTime(string value)
        {
            DateTime targetValue;
            return this.Test(value
                , x => DateTime.TryParse(x, out targetValue)
                , nameof(value)
                , $"DateTime");
        }

        public AssertionSet IsUInt(string value)
        {
            uint targetValue;
            return this.Test(value
                , x => UInt32.TryParse(x, out targetValue)
                , nameof(value)
                , $"Unsigned Integer");
        }

        public AssertionSet IsUShort(string value)
        {
            ushort targetValue;
            return this.Test(value
                , x => UInt16.TryParse(x, out targetValue)
                , nameof(value)
                , $"Unsigned Short");
        }

        public AssertionSet IsULong(string value)
        {
            ulong targetValue;
            return this.Test(value
                , x => UInt64.TryParse(x, out targetValue)
                , nameof(value)
                , $"Unsigned Long");
        }

        public AssertionSet IsBoolean(string value)
        {
            bool targetValue;
            return this.Test(value
                , x => Boolean.TryParse(x, out targetValue)
                , nameof(value)
                , $"Boolean");
        }

        public AssertionSet IsBoolean(string value, IList<string> possibleTruthTokens, IList<string> possibleFalseTokens )
        {
            bool targetValue;
            return this.Test(value
                , x => Boolean.TryParse(x, out targetValue) || 
                        (possibleFalseTokens
                            ?.ToList()
                            ?.ConvertAll(y=> y?.Trim()?.ToUpper())
                            .Contains(value?.Trim()?.ToUpper()) ?? false) ||
                        (possibleTruthTokens
                            ?.ToList()
                            ?.ConvertAll(y => y?.Trim()?.ToUpper())
                            .Contains(value?.Trim()?.ToUpper()) ?? false)
                , nameof(value)
                , $"Boolean");
        }
    }
}
