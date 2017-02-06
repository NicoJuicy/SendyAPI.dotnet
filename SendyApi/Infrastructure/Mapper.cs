using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendyApi.Infrastructure
{
    public static class Mapper<T>
    {
        //public static List<T> MapCollectionFromJson(string json, string token = "data")
        //{

        //    return JsonConvert.DeserializeObject<IEnumerable<T>>(json).ToList();
        //}
        // public static apiListable<T> MapCollectionFromJson(string json, string token = "data", Dictionary<string, string> Headers = null)
        public static List<T> MapCollectionFromJson(string json, string token = "data", Dictionary<string, string> Headers = null)
        {
            //apiListable ( used to be this for odata;
            var apiList = new List<T>(JsonConvert.DeserializeObject<List<T>>(json).ToList());

            //only required for odata
            //if (Headers != null)
            //{
            //    if (Headers.ContainsKey("Total-Items"))
            //    {
            //        apiList.TotalItems = int.Parse(Headers["Total-Items"]);
            //    }
            //    if (Headers.ContainsKey("Current-Items"))
            //    {
            //        apiList.CurrentItems = int.Parse(Headers["Current-Items"]);
            //    }
            //}
            return apiList;
        }

        public static T MapFromJson(string json, string parentToken = null)
        {
            // var jsonToParse = string.IsNullOrEmpty(parentToken) ? json : JObject.Parse(json).SelectToken(parentToken).ToString();

            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
