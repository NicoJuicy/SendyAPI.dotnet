using SendyApi.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SendyApi.Models;

namespace SendyApi
{
    public class SendyClient
    {
        private string authority { get; set; }
        private string api_key { get; set; }
        private int list_id { get; set; }
        public SendyClient(string authority, string api_key, int list_id = -1)
        {
            this.authority = authority;
            this.api_key = api_key;
            if(list_id>-1)
            { 
                this.list_id = list_id;
            }
        }

        public void setListId(int list_id)
        {
            this.list_id = list_id;
        }
        /// <summary>
        /// This method creates a campaign (with an option to send it too).
        /// </summary>
        /// <remarks>
        /// Important note: You must have a cron job setup for sending in order for your campaign to be sent via this API. The cron job setup instructions can be found at the 'Define recipients' page (the page where you choose lists to send your campaign to) in a blue box at the bottom.
        /// /api/campaigns/create.php
        /// </remarks>
        public async Task<bool> CampaignCreate(Models.Request.CampaignRequest request)
        {
            var url = authority + Urls.CampaignCreateAndSend;
            var body = ParameterBuilder.GetBodyParameters(request);
            var response = await Requestor.Post(url, api_key, body);
         
            return response.asCampaignResponse();
        }

        /// <summary>
        /// This method adds a new subscriber to a list.You can also use this method to update an existing subscriber. On another note, you can also embed a subscribe form on your website using Sendy's subscribe form HTML code. Visit View all lists, select your desired list then click 'Subscribe form' at the top of the page.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <remarks>/subscribe</remarks>
        public async Task<bool> Subscribe(Models.Request.SubscribeRequest request)
        {
            var url = authority + Urls.Subscribe;
            var body = ParameterBuilder.GetBodyParameters(request);
            var response = await Requestor.Post(url, api_key, body);
            return response.asBoolean(); 
        }

        /// <summary>
        /// This method adds a new subscriber to a list.You can also use this method to update an existing subscriber. On another note, you can also embed a subscribe form on your website using Sendy's subscribe form HTML code. Visit View all lists, select your desired list then click 'Subscribe form' at the top of the page.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <remarks>/subscribe</remarks>
        public async Task<bool> Unsubscribe(Models.Request.UnsubscribeRequest request)
        {
            var url = authority + Urls.Unsubscribe;
            var body = ParameterBuilder.GetBodyParameters(request);
            var response = await Requestor.Post(url, api_key, body);
            return response.asBoolean();
        }

        /// <summary>
        /// This method deletes a subscriber off a list (only supported in Sendy version 2.1.1.4 and above).
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<bool> SubscriberDelete(Models.Request.SubscriberDeleteRequest request)
        {
            var url = authority + Urls.SubscribersDelete;
            var body = ParameterBuilder.GetBodyParameters(request);
            var response = await Requestor.Post(url, api_key, body);
            return response.asBoolean();
        }

        /// <summary>
        /// This method gets the current status of a subscriber (eg. subscribed, unsubscribed, bounced, complained).
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Models.Enums.SubscriptionStatus> SubscriptionStatus(Models.Request.SubscriptionStatusRequest request)
        {
            var url = authority + Urls.SubscriptionStatus;
            var body = ParameterBuilder.GetBodyParameters(request);
            var response = await Requestor.Post(url, api_key, body);

            Models.Enums.SubscriptionStatus status;
            switch(response.Content)
            {
                case "Subscribed":
                    status = Models.Enums.SubscriptionStatus.Subscribed;
                    break;
                case "Unsubscribed":
                    status = Models.Enums.SubscriptionStatus.Unconfirmed;
                    break;
                case "Unconfirmed":
                    status = Models.Enums.SubscriptionStatus.Unsubscribed;
                    break;
                case "Bounced":
                    status = Models.Enums.SubscriptionStatus.Bounced;
                    break;
                case "Soft bounced":
                    status = Models.Enums.SubscriptionStatus.SoftBounced;
                    break;
                case "Complained":
                    status = Models.Enums.SubscriptionStatus.Complained;
                    break;
                default:
                    throw new Exception(response.Content);

            }

            return status;
        }

        /// <summary>
        /// This method gets the total active subscriber count of a list.
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public async Task<int> SubscriptionsCount(Models.Request.SubscriptionsCountRequest request)
        {
            var url = authority + Urls.SubscriptionCount;
            var body = ParameterBuilder.GetBodyParameters(request);
            var response = await Requestor.Post(url, api_key, body);
            return Convert.ToInt32(response.Content);
            //return 0;
        }
    }
}
