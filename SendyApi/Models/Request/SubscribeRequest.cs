using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendyApi.Models.Request
{
    public class SubscribeRequest
    {
        public SubscribeRequest()
        {
            boolean = true;
        }
        /// <summary>
        /// user's name is optional
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// user's email
        /// </summary>
        public string email { get; set; }
        /// <summary>
        /// the list id you want to subscribe a user to. This encrypted & hashed id can be found under View all lists section named ID
        /// </summary>
        public string list { get; set; }
        ///// <summary>
        ///// set this to "true" so that you'll get a plain text response
        ///// </summary>
        public bool boolean { get; set; }
    }
}
