using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendyApi.Models.Request
{
    public class SubscriptionStatusRequest : ApiKeyAndListIdCoreRequest
    {
        ///// <summary>
        ///// your API key, available in Settings.
        ///// </summary>
        //public string api_key { get; set; }
        /// <summary>
        /// user's email
        /// </summary>
        public string email { get; set; }
        ///// <summary>
        ///// the id of the list this email belongs to. This encrypted id can be found under View all lists section named ID
        ///// </summary>
        //public int list_id { get; set; }
    }
}
