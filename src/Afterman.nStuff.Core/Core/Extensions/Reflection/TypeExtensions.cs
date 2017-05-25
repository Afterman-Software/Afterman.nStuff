using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afterman.nStuff.Core.Core.Extensions.Reflection
{
    public static class TypeExtensions
    {
        public static Type GetTypeOrUnderlyingNullableType(this Type value)
        {
            return Nullable.GetUnderlyingType(value) ?? value;
        }
    }
}
