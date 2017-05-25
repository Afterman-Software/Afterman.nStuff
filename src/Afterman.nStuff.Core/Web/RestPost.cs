using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afterman.nStuff.Core.Web
{
    using System.Net.Http;

    public class RestPost : IRestPost
    {
        public void Post(string url
            , string payload
            , Dictionary<string, string> headers)
        {
            using (var c = new HttpClient())
            {
                c.BaseAddress = new Uri(url);
                c.DefaultRequestHeaders.Accept.Clear();
                foreach (var header in headers)
                {
                    c.DefaultRequestHeaders.Add(header.Key,header.Value);
                }
                var result =
                    c.PostAsync(new Uri(url), new StringContent(payload))
                        .GetAwaiter()
                        .GetResult();
                if (result.IsSuccessStatusCode == false)
                    throw new Exception("Not successful posting to url for erestaurant - " + result.StatusCode);
            }
        }
    }
}
