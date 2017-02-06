using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendyApi.Infrastructure
{
    public class ResponseContent
    {
        public ResponseContent()
        {

        }

        public Dictionary<string, string> Headers { get; set; }
        public int HttpStatusCode { get; set; }
        public string Content { get; set; }
    }
}
