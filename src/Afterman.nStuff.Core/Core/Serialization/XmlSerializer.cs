using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afterman.nStuff.Core.Core.Serialization
{
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;

    public class XmlSerializer
        : IXmlSerializer
    {
        public string Serialize(object obj)
        {
            var xmlDoc = new XmlDocument();
            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(obj.GetType());
            using (var xmlStream = new MemoryStream())
            {
                xmlSerializer.Serialize(xmlStream, obj);
                xmlStream.Position = 0;
                xmlDoc.Load(xmlStream);
                return xmlDoc.InnerXml;
            }
        }

        public T Deserialize<T>(string xml)
        {
            var oXmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            var newObj = oXmlSerializer.Deserialize(new StringReader(xml));
            return (T)newObj;
        }
    }
}
