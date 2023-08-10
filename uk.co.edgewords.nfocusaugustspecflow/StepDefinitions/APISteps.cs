using System;
using TechTalk.SpecFlow;
using RestSharp;
using RestSharp.Authenticators;
using NUnit.Framework;

namespace uk.co.edgewords.nfocusaugustspecflow.StepDefinitions
{
    [Binding]
    public class APISteps
    {
        private readonly ScenarioContext _scenarioContext;
        private RestClient client;
        private RestResponse response;

        public APISteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            client = (RestClient)_scenarioContext["restClient"];
        }
        [When(@"I request user number '(.*)'")]
        public void WhenIRequestUserNumber(string userNumber)
        {


            RestRequest request = new RestRequest("users/" + userNumber, Method.Get);

            response = client.Execute(request); //Executes synchronously
            
            
        }

        [Then(@"I get a '(\d{3})' response code")] //Changed regex to capture digits
        public void ThenIGetAResponseCode(int expectedStatus) //Specflow will pass through an int now instead of a string
        {
            int statusCode = (int)response.StatusCode;
            Assert.That(statusCode, Is.EqualTo(expectedStatus));
            statusCode.Should().Be(expectedStatus);
        }

        [Then(@"The user is '(.*)'")]
        public void ThenTheUserIs(string name)
        {
            Assert.That(response.Content, Does.Contain(name), "Wrong user");
            response.Content.Should().Contain(name);
        }
    }
}