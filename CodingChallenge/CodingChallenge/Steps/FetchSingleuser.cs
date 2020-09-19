using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using RestSharp.Deserializers;
using System;
using TechTalk.SpecFlow;
using CodingChallenge;
using CodingChallenge.Models;
using CodingChallenge.Models.Request;
using RestSharp.Extensions;
using System.Web.UI;
using RestSharp.Serialization.Json;

namespace CodingChallenge.Steps
{
    [Binding]
    public class FetchSingleuser
    {
        private const string BASE_URL = "https://reqres.in/";
        private readonly GetuserModel GetuserModel;
        private readonly object HandleContent;
        private IRestResponse response;
        public FetchSingleuser(GetuserModel GetuserserModel)
        {
            this.GetuserModel = GetuserModel;
        }
        [When(@"I acccess API URL")]
        public void WhenIacccessAPIURL()
        {
            var client = new RestClient(BASE_URL);
         
        }
        [Then(@"Get call returns singleuser details")]
        public void ThenIGetcallreturnssingleuserdetails()
        {
            var client = new RestClient(BASE_URL);
            var restrequest = new RestRequest("api/users/2", Method.GET);
             restrequest.AddHeader("Accept", "application/json");
            restrequest.RequestFormat = DataFormat.Json;
            IRestResponse response = client.Execute(restrequest);
            var content = response.Content;
            var user = JsonDeserializer<GetuserModel>(content);

        }
        private object JsonDeserializer<T>(string content)
        {
            throw new NotImplementedException();
        }

    }
}