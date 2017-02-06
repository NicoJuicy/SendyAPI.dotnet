using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendApi.Tests
{
    public static partial class Configuration
    {
        public static string Url { get; set; }
        public static string ApiKey { get; set; }

        public static string FromEmail { get; set; }
        public static string FromName { get; set; }
        public static string ListId { get; set; }
        public static string BrandId { get; set; }
    }
}
