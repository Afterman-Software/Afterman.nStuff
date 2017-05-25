using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afterman.nStuff.Core.Web
{
    public interface IRestPost
    {
        void Post(string url, string payload, Dictionary<string,string> headers );
    }
}
