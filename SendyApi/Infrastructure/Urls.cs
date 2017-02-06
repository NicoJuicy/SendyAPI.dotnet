using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendyApi.Infrastructure
{
    public static class Urls
    {
        public static string Subscribe
        {
            get { return "/subscribe"; }
        }

        public static string Unsubscribe
        {
            get { return "/unsubscribe"; }
        }

        public static string SubscribersDelete
        {
            get { return "/api/subscribers/delete.php"; }
        }

        public static string SubscriptionStatus
        {
            get { return "/api/subscribers/subscription-status.php"; }
        }

        public static string SubscriptionCount
        {
            get
            {
                return "/api/subscribers/active-subscriber-count.php";
            }
        }

        public static string CampaignCreateAndSend
        {
            get
            {
                return "/api/campaigns/create.php";
            }
        }



    }
}
