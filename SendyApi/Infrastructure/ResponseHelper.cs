using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendyApi.Infrastructure
{
    public static class ResponseHelper
    {
        public static bool asBoolean(this ResponseContent response)
        {
            return response.Content == "1";// response.HttpStatusCode == 200;
        }

        public static bool asCampaignResponse(this ResponseContent response)
        {
            return response.Content == "Campaign created";
        }
        //public static bool isDeleted(this ResponseContent response)
        //{
        //    //200 with content
        //    //204 with no content
        //    return response.HttpStatusCode == 204 || response.HttpStatusCode == 200;
        //}

        //public static bool isUpdated(this ResponseContent response)
        //{
        //    //204, nothing to report
        //    return response.HttpStatusCode == 204;
        //}


    }
}
