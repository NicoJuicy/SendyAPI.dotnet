using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace SendyApi.Infrastructure
{
    internal static class Requestor
    {

        public static async Task<Infrastructure.ResponseContent> Post(string url, string apiKey = null, string body = "")
        {
            return await RequestWithData(url, HttpMethod.Post, apiKey, body, "HTML");
        }

        private static async Task<Infrastructure.ResponseContent> Request(string url, HttpMethod method, string apikey = null,string body = "", string format = "") //string apikey = null, 
        {
            var wr = GetWebRequest(url, method, apikey, false, "", format);

            return await ExecuteWebRequest(wr);
        }

        private static async Task<Infrastructure.ResponseContent> RequestWithData(string url, HttpMethod method, string apikey = null, string body = "", string format = "")
        {
            var requestMessage = GetWebRequest(url, method, apikey, false, body, format);

            return await RequestWithData(requestMessage);
        }

        private static async Task<Infrastructure.ResponseContent> RequestWithData(HttpRequestMessage requestMessage)
        {
            return await ExecuteWebRequest(requestMessage);
        }


        internal static HttpRequestMessage GetWebRequest(string url, HttpMethod method,string apikey, bool useBearer = false, string body = "", string format = "json")
        {
            HttpRequestMessage request = new HttpRequestMessage(method, url);
            request.Headers.Add("User-Agent", "SendyAPI.dotnet-CLIENT");

            string mediaType = "application/x-www-form-urlencoded";
            switch (format.ToUpperInvariant())
            {
                case "HTML":
                    mediaType = "application/x-www-form-urlencoded";
                    break;
                case "JSON":
                    mediaType = "application/json";
                    break;
                case "JSONPATCH":
                    mediaType = "application/json-patch+json";
                    break;
                case "BSON":
                    mediaType = "application/bson";
                    break;

            }
            request.Headers.TryAddWithoutValidation("Content-Type", mediaType);

            if (!string.IsNullOrEmpty(body))
            {
                //Opgelet, momenteel geen andere manier om dit te doen ( probeer dit uit en kijk of er problemen zijn)

                UTF8Encoding encoding = new UTF8Encoding();//ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] bytes = encoding.GetBytes(body);
                request.Content = new StringContent(body, Encoding.UTF8, mediaType);

            }

            return request;

        }

        private static async Task<Infrastructure.ResponseContent> ExecuteWebRequest(HttpRequestMessage requestMessage)
        {
            try
            {
                ResponseContent response = await ExecuteWebRequestCore(requestMessage);

                //while(response.HttpStatusCode == 503)
                //{
                //    System.Threading.Tasks.Task.Delay(5000);
                //    response =  await ExecuteWebRequestCore(requestMessage);
                //}

                return response;
            }
            catch (AggregateException aggregateException)
            {
                throw;
            }
            catch(Exception ex)
            {
                throw;
            }
            //catch (WebException webException)
            //{
            //    if (webException.Response != null)
            //    {
            //        var statusCode = ((HttpWebResponse)webException.Response).StatusCode;

            //        var stripeError = new Omnisoft.Exceptions.OmnisoftError();

            //        if (requestMessage.RequestUri.ToString().Contains("oauth"))
            //            stripeError = Mapper<Omnisoft.Exceptions.OmnisoftError>.MapFromJson(ReadStream(webException.Response.GetResponseStream()));
            //        else
            //            stripeError = Mapper<Omnisoft.Exceptions.OmnisoftError>.MapFromJson(ReadStream(webException.Response.GetResponseStream()), "error");

            //    }

            //    throw;
            //}
        }

        internal static async Task<Infrastructure.ResponseContent> ExecuteWebRequestCore(HttpRequestMessage requestMessage)
        {
            var compressClient = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip
            };
            using (var client = new HttpClient(compressClient))
            {

                client.DefaultRequestHeaders.ExpectContinue = false;

                HttpResponseMessage response = response = await client.SendAsync(requestMessage);

                if (response.IsSuccessStatusCode)
                {
                    HttpContent content = response.Content;

                    var dicHeaders = new Dictionary<string, string>();
                    foreach (var header in response.Headers)
                    {
                        dicHeaders.Add(header.Key, header.Value.ToString());
                    }

                    return new ResponseContent()
                    {
                        Content = await content.ReadAsStringAsync(),
                        HttpStatusCode = (int)response.StatusCode,
                        Headers = dicHeaders
                    };
                }
                else
                {
                    ResourceManager rm = HttpStatus.HttpStatus.ResourceManager;
                    throw new InvalidOperationException(string.Format(
                        "Http Status= {0} - {1}", (int)response.StatusCode,
                        rm.GetString(response.StatusCode.ToString())));
                }
                //else if (response.StatusCode == HttpStatusCode.ServiceUnavailable)
                //{
                //    throw new InvalidOperationException("The API is currently unavailable. Update in progress.. Please wait +/- 15 minutes");
                //}
                //else {

                //    throw new InvalidOperationException(string.Format("{0}-{1}", (int)response.StatusCode,response.StatusCode.ToString()));//await response.Content.ReadAsStringAsync());
                //}

            }
        }
    }

   
}
