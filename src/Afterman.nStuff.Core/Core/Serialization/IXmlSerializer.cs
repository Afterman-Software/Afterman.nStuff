using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afterman.nStuff.Core.Core.Serialization
{
    public interface IXmlSerializer
    {
        T Deserialize<T>(string xml);
        string Serialize(object obj);
    }
}
