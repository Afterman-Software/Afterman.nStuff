using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afterman.nStuff.Core.Core.Xml
{
    public interface IXmlPayloadWriter : IDisposable
    {
        Node New(string name);

    }
}
