using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SendyApi;

namespace SendyApi.Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void Subscribe()
        {
            var client = new SendyClient(SendApi.Tests.Configuration.Url, SendApi.Tests.Configuration.ApiKey);
            var response = client.Subscribe(new SendyApi.Models.Request.SubscribeRequest()
            {
                email = SendApi.Tests.Configuration.FromEmail,
                name = SendApi.Tests.Configuration.FromName, 
                list = SendApi.Tests.Configuration.ListId
            }).Result;

            Assert.AreEqual(response, true);
        }

        [TestMethod]
        public void SubscriptionStatus()
        {
            var client = new SendyClient(SendApi.Tests.Configuration.Url, SendApi.Tests.Configuration.ApiKey);
            SendyApi.Models.Enums.SubscriptionStatus response = client.SubscriptionStatus(new SendyApi.Models.Request.SubscriptionStatusRequest()
            {
                api_key = SendApi.Tests.Configuration.ApiKey,
                list_id = SendApi.Tests.Configuration.ListId,
                email = SendApi.Tests.Configuration.FromEmail
            }).Result;

            Assert.AreEqual(response, SendyApi.Models.Enums.SubscriptionStatus.Subscribed);
        }

        [TestMethod]
        public void UnSubscribe()
        {
            var client = new SendyClient(SendApi.Tests.Configuration.Url, SendApi.Tests.Configuration.ApiKey);
            var response = client.Unsubscribe(new SendyApi.Models.Request.UnsubscribeRequest()
            {
                email = SendApi.Tests.Configuration.FromEmail,
                list = SendApi.Tests.Configuration.ListId
            }).Result;

            Assert.AreEqual(response, true);
        }

        [TestMethod]
        public void SubscriptionCount()
        {
            var client = new SendyClient(SendApi.Tests.Configuration.Url, SendApi.Tests.Configuration.ApiKey);
            var response = client.SubscriptionsCount(new SendyApi.Models.Request.SubscriptionsCountRequest()
            {
                api_key = SendApi.Tests.Configuration.ApiKey,
                list_id = SendApi.Tests.Configuration.ListId
            }).Result;

            Assert.AreEqual(response, 1);
        }


        [TestMethod]
        public void CampaignCreate()
        {
            var client = new SendyClient(SendApi.Tests.Configuration.Url, SendApi.Tests.Configuration.ApiKey);
            var response = client.CampaignCreate(new SendyApi.Models.Request.CampaignRequest()
            {
                api_key = SendApi.Tests.Configuration.ApiKey,
                from_email = SendApi.Tests.Configuration.FromEmail,
                reply_to = SendApi.Tests.Configuration.FromEmail,
                from_name = SendApi.Tests.Configuration.FromName,
                brand_id = SendApi.Tests.Configuration.BrandId,
                html_text = "<h1>Some html</h1>",
                plain_text = "Some text",
                subject = "Heading"

            }).Result;

            Assert.AreEqual(response, true);
        }

    }
}
