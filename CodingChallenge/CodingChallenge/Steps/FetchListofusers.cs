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
    public class Fetchlist
    {
        private const string BASE_URL = "https://reqres.in/";
        private readonly GetuserModel GetuserModel;
        private readonly object HandleContent;
        private IRestResponse response;
        public Fetchlist(GetuserModel GetuserserModel)
        {
            this.GetuserModel = GetuserModel;
        }
        [When(@"I acccess API URL")]
        public void WhenIacccessAPIURL()
        {
            
        }
        [Then(@"I call Get  for listofusers")]
        public void  ThenIcallGetsingleuserdetails()
        {

            var client = new RestClient(BASE_URL);
            var restrequest = new RestRequest("api /users?Page=2", Method.GET);
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
