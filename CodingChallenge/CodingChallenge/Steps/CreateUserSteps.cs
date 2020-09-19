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
    public class CreateUserSteps
    {
        private const string BASE_URL = "https://reqres.in/";
        private readonly CreateUserModel createUserModel;
        private readonly object HandleContent;
        private IRestResponse response;
        public CreateUserSteps(CreateUserModel createUserModel)
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
        
        [Then(@"Validate user is created")]
        public void ThenValidateUserIsCreated()
        {
            var content = HandleContent.getContent<CreateUser>(response);
            Assert.AreEqual(createUserModel.Name, content.Name);
            Assert.AreEqual(createUserModel.Job, content.Job);
        }
    }
}
