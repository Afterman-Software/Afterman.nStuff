using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afterman.nStuff.Core.Core.Xml
{
    using System.IO;
    using System.Xml;

    public class XmlPayloadWriter : IXmlPayloadWriter
    {
        private readonly StringWriter _stream;
        private readonly XmlTextWriter _writer;
        public XmlPayloadWriter()
        {
            this._stream = new StringWriter();
            this._writer = new XmlTextWriter(this._stream);
            this._writer.Formatting = Formatting.Indented;
            this._writer.WriteStartDocument();
        }
        public void Dispose()
        {
            this._writer.Dispose();
            this._stream.Dispose();
        }


        public Node New(string name)
        {
            return new Node(name);
        }


    }
}
