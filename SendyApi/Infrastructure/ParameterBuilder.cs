using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SendyApi.Infrastructure
{
    public static class ParameterBuilder
    {
        public static string GetBodyParameters(object obj)
        {
            return ApplyAllParameters(obj, "", true);
        }
        public static string ApplyAllParameters(object obj, string url, bool isBody = false, string format = "HTML")
        {
            if (obj == null) return url;

            StringBuilder sb = new StringBuilder();
            var newUrl = url;
            //BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance
            foreach (var property in obj.GetType().GetRuntimeProperties())
            {
                if (property.CanWrite)
                {
                    var value = property.GetValue(obj, null);
                    if (value != null)
                    {
                        if (isBody)
                        {
                            switch (format.ToUpperInvariant())
                            {
                                case "HTML":
                                    if (value != null)
                                    {
                                        if (newUrl.Length > 0) newUrl += "&";
                                        newUrl += ApplyParameterToBody(url, property.Name,value.ToString());// string.Format("{0}={1}", property.Name, WebUtility.UrlEncode(value.ToString()));
                                    }
                                    //newUrl = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                                    //sb.Append(ApplyParameterToBody(url, property.Name, property.GetValue(property).ToString()));
                                    break;
                                case "JSON":
                                    newUrl = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                                    break;
                                case "BSON":
                                    throw new System.NotImplementedException();
                                    break;
                            }
                        }
                        else
                        {
                            newUrl = ApplyParameterToUrl(newUrl, property.Name, value.ToString());
                        }
                    }
                }
            }

            return newUrl;
        }

        public static string ApplyParameterToBody(string url, string argument, string value)
        {
            var token = "&";

            if (string.IsNullOrEmpty(url))
                token = "";

            if (value == "True") value = "true";

            return string.Format("{0}{1}{2}={3}", url, token, argument, WebUtility.UrlEncode(value)); //  WebUtility.UrlEncode(value));
        }


        public static string ApplyParameterToUrlIfNotNull(string url, string argument, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                return ApplyParameterToUrl(url, argument, value);
            }

            return url;
        }

        public static string ApplyParameterToUrl(string url, string argument, string value)
        {
            var token = "&";


            if (!url.Contains("?"))
                token = "?";


            return string.Format("{0}{1}{2}={3}", url, token, argument, System.Uri.EscapeUriString(value)); // WebUtility.UrlEncode(value));
        }
    }
}
