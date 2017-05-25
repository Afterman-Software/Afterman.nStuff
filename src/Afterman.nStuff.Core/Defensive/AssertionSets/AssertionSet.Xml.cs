using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afterman.nStuff.Core.Defensive.AssertionSets
{
    using System.Xml;

    public partial class AssertionSet
    {
        public AssertionSet AttributeValueIs(string value, XmlNode node, string attributeName)
        {
            return this.Test(value
                , x => Object.Equals(node.Attributes?[attributeName]?.Value, value)
                , nameof(value)
                , $"Attribute {attributeName} value of {value}");
        }
    }
}
