using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afterman.nStuff.Core.Defensive
{
    using AssertionSets;
    using Framework;

    public static class FluentlyDefend
    {
        public static AssertionSet AssertThat(ValidationMode validationMode = ValidationMode.RealTime)
        {
            return new AssertionSet(validationMode);
        }
    }
}
