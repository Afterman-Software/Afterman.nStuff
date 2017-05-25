using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afterman.nStuff.Core.Core.Extensions.Strings
{
    using System.Globalization;

    public static class StringPrimitiveConversionExtensions
    {
        public static bool ToBoolean(this string value)
        {
            if (new List<string> {"y", "yes", "t", "1", "true"}.Contains(value?.Trim()?.ToLower()))
                return true;
            return false;
        }

        public static DateTime? ToDateTime(this string value, string format)
        {
            if (String.IsNullOrEmpty(value))
                return null;
            return DateTime.ParseExact(value, format, new DateTimeFormatInfo(), DateTimeStyles.AssumeLocal);
        }

        
    }
}
