using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendyApi.Models.Request
{
    public class ApiKeyCoreRequest
    {
        /// <summary>
        /// your API key, available in Settings.
        /// </summary>
        public string api_key { get; set; }
    }


    public class ApiKeyAndListIdCoreRequest : ApiKeyCoreRequest
    {
        /// <summary>
        /// the id of the list you want to get the active subscriber count. This encrypted id can be found under View all lists section named ID
        /// </summary>
        public string list_id { get; set; }
    }
}
