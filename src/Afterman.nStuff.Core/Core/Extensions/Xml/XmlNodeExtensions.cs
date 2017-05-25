namespace Afterman.nStuff.Core.Core.Extensions.Xml
{
    using System.Collections.Generic;
    using System.Xml;

    public static class XmlNodeExtensions
    {
        public static IEnumerable<XmlNode> GetChildNodes(this XmlNode node, string nodeName)
        {
            foreach (XmlNode childNode in node.ChildNodes)
            {
                if (childNode.Name == nodeName)
                    yield return childNode;
            }
        }




        
    }
}
