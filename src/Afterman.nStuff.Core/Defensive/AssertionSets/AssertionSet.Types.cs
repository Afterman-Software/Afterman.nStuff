using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afterman.nStuff.Core.Defensive.AssertionSets
{
    using System.Security.Cryptography.X509Certificates;

    public partial class AssertionSet
    {
        public AssertionSet ImplementOrInherits(Type potentialChildType, Type knownBaseType)
        {
            return this.Test(potentialChildType
                , knownBaseType.IsAssignableFrom
                , nameof(potentialChildType)
                , $"Implements or Inherits from type {knownBaseType.FullName}");
        }

        public AssertionSet IsAbstract(Type value)
        {
            return this.Test(value
                , x => x.IsAbstract
                , nameof(value)
                , $"Abstract Class");
        }

        public AssertionSet IsInterface(Type value)
        {
            return this.Test(value
                , x => x.IsInterface
                , nameof(value)
                , $"Interface");
        }

        public AssertionSet IsValueType(Type value)
        {
            return this.Test(value
                , x => x.IsValueType
                , nameof(value)
                , $"Value Type");
        }

        public AssertionSet IsConcreteClass(Type value)
        {
            return this.Test(value
                , x => x.IsClass
                , nameof(value)
                , $"Concrete Class");
        }

        public AssertionSet IsOpenType(Type value)
        {
            return this.Test(value
                , x => x.IsGenericType
                , nameof(value)
                , $"Open Type");
        }

        public AssertionSet IsNullableType(Type value)
        {
            return this.Test(value
                , x => null != Nullable.GetUnderlyingType(x)
                , nameof(value)
                , $"Nullable<>");
        }

        public AssertionSet HasClosingGenericType(Type value, Type proposedClosingType)
        {
            return this.Test(value
                , x => x.GetGenericArguments().Contains(proposedClosingType)
                , nameof(value)
                , $"Closed by type {proposedClosingType.FullName}");
        }


    }
}
