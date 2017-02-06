using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendyApi.Models.Request
{
    public class CampaignRequest : ApiKeyCoreRequest
    {
        ///// <summary>
        ///// your API key, available in Settings.
        ///// </summary>
        //public string api_key { get; set; }

        /// <summary>
        /// the 'From name' of your campaign
        /// </summary>
        public string from_name { get; set; }

        /// <summary>
        /// the 'From email' of your campaign
        /// </summary>
        public string from_email { get; set; }
        /// <summary>
        /// the 'Reply to' of your campaign
        /// </summary>
        public string reply_to { get; set; }
        /// <summary>
        /// the 'Subject' of your campaign
        /// </summary>
        public string subject { get; set; }
        /// <summary>
        /// the 'Plain text version' of your campaign (optional)
        /// </summary>
        public string plain_text { get; set; }
        /// <summary>
        /// the 'HTML version' of your campaign
        /// </summary>
        public string html_text { get; set; }
        /// <summary>
        /// Required only if you set send_campaign to 1 to send the campaign and not just create a draft. List IDs should be single or comma-separated. The encrypted & hashed ids can be found under View all lists section named ID.
        /// </summary>
        public string list_ids { get; set; }
        /// <summary>
        /// Required only if you are creating a 'Draft' campaign (send_campaign set to 0 or left as default). Brand IDs can be found under 'Brands' page named ID.
        /// </summary>
        public string brand_id { get; set; }

        /// <summary>
        /// eg. Google Analytics tags
        /// </summary>
        public string query_string { get; set; }
        /// <summary>
        /// Set to 1 if you want to send the campaign as well and not just create a draft. Default is 0.
        /// </summary>
        public int send_campaign { get; set; }

    }
}
