using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using TechTalk.SpecFlow;
using CodingChallenge;
using CodingChallenge.Models;
using CodingChallenge.Models.Request;
using RestSharp.Extensions;

namespace CodingChallenge.Steps
{
    [Binding]
    public class UpdateUserSteps
    {
        private const string BASE_URL = "https://reqres.in/";
        private readonly CreateUserModel createUserModel;
        private readonly object HandleContent;
        private IRestResponse response;
        public UpdateUserSteps(CreateUserModel createUserModel)
        {
            this.createUserModel = createUserModel;
        }
        [Given(@"I input name ""(.*)""")]
        public void GivenIInputName(string name)
        {
            createUserModel.Name = name;
        }
        
        [Given(@"I input role ""(.*)""")]
        public void GivenIInputRole(string role)
        {
            createUserModel.Job = role;
        }
        
        [When(@"I send create user request")]
        public void WhenISendCreateUserRequest()
        {
            //var api = new Api<CreateUser>();
           // var api = new Models.CreateUser;

            //response = api.createUser(BASE_URL, "api/users", createUserModel);
           IRestResponse response = api.createUser(BASE_URL, "api/users", Method.POST);
            
        }
        
        [When(@"Validate user is created")]
        public void WhenValidateUserIsCreated()
        {
            var content = HandleContent.getContent<CreateUser>(response);
            Assert.AreEqual(createUserModel.Name, content.Name);
            Assert.AreEqual(createUserModel.Job, content.Job);
        }
        [When(@"User is updated with  ""(.*)""")]
        public void WhenUserisupdatedwith(string name)
        {
            createUserModel.Name = name;
            IRestResponse response = api.createUser(BASE_URL, "api/users/2", Method.PUT);
        }
        [Then(@"Responsecodeis200")]
        public void ThenResponsecodeis200()
        {

            var client = new RestClient(BASE_URL);
            var restrequest = new RestRequest("api/users/2", Method.GET);
            restrequest.AddHeader("Accept", "application/json");
            restrequest.RequestFormat = DataFormat.Json;
            IRestResponse response = client.Execute(restrequest);
            //Extract status code from received response and store in an Interger
            int StatusCode = (int)response.StatusCode;
            //Assert that correct Status is returned
            Assert.AreEqual(200, StatusCode, "Status code is 200");
        }

    }
}
