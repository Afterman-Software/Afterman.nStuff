using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afterman.nStuff.Core.Core.Xml
{
    using System.Xml;

    public class XmlPayloadReader : IXmlPayloadReader
    {
        public XmlNode FindChildNodeByAttribute(XmlNode node, string nodeName,
            Func<XmlNode, bool> conditional)
        {
            return this.GetChildNodes(node, nodeName).FirstOrDefault(conditional);
        }

        public IEnumerable<XmlNode> GetChildNodes(XmlNode node, string nodeName)
        {
            foreach (XmlNode childNode in node.ChildNodes)
            {
                if (childNode.Name == nodeName)
                    yield return childNode;
            }
        }


        public T FromAttribute<T>(XmlNode node, string attributeName)
        {
            var val = default(T);
            var rawValue = node?.Attributes?[attributeName]?.Value;
            rawValue = this.CoerceRawValue<T>(rawValue);
            if (String.IsNullOrEmpty(rawValue)) return val;
            Type conversiontype = Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);
            return (T)Convert.ChangeType(rawValue, conversiontype);
        }

        public string CoerceRawValue<T>(string rawValue)
        {
            var val = rawValue?.ToLower();
            if (typeof(T) == typeof(bool) || typeof(T) == typeof(bool?))
            {
                if (val == "y" || val == "yes")
                    return true.ToString();
                else
                    return false.ToString();
            }
            if (typeof(T) == typeof(DateTime) || typeof(T) == typeof(DateTime?))
            {
                if (String.IsNullOrEmpty(rawValue))
                    return default(T)?.ToString();
                DateTime date;
                if (DateTime.TryParse(rawValue, out date))
                {
                    rawValue = date.ToString("yyyyMMdd");
                }
                if (rawValue.Contains("-") == false)
                {
                    return $"{rawValue.Substring(0, 4)}-{rawValue.Substring(4, 2)}-{rawValue.Substring(6, 2)}";
                }

            }
            return rawValue;
        }
    }
}
