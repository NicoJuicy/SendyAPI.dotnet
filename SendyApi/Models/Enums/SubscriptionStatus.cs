using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendyApi.Models.Enums
{
    public enum SubscriptionStatus : int
    {
        Subscribed = 1,
        Unsubscribed = -1,
        Unconfirmed = 0,
        Bounced = 2,
        SoftBounced = 3,
        Complained = -2
    }
}
