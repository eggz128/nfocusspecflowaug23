using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using RestSharp.Authenticators;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(8)]
namespace uk.co.edgewords.nfocusaugustspecflow.StepDefinitions
{
    [Binding]
    public class Hooks
    {
        private IWebDriver _driver;
        private readonly ScenarioContext _scenarioContext;
        
        public Hooks(ScenarioContext scenarioContext)
        {

            _scenarioContext = scenarioContext;
        }

        [Before("@API")]
        public void SetUpAPI()
        {
            //Options object to pass to RestClient on creation. In this case a BaseURL to use for all future requests
            RestClientOptions options = new RestClientOptions("http://localhost:2002/api/");
            options.Authenticator = new HttpBasicAuthenticator("edge", "edgewords");

            //Create the client
            RestClient client = new RestClient(options);
            _scenarioContext["restClient"] = client;

        }

        [Before("@GUI")]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _scenarioContext["mydriver"] = _driver;
            //_scenarioContext["mydriver"] = "bob"; //No compile time warnings that this is wrong
        }


        [After("@GUI")]
        public void TearDown()
        {
            Thread.Sleep(2000); //So we can see what's going on
            _driver.Quit();
        }
    }
}
