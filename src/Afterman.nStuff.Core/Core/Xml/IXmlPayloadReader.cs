using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afterman.nStuff.Core.Core.Xml
{
    using System.Xml;

    public interface IXmlPayloadReader
    {
        XmlNode FindChildNodeByAttribute(XmlNode node, string nodeName,
            Func<XmlNode, bool> conditional);

        IEnumerable<XmlNode> GetChildNodes(XmlNode node, string nodeName);

        T FromAttribute<T>(XmlNode node, string attributeName);

        string CoerceRawValue<T>(string rawValue);

    }
}
