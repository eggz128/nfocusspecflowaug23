using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using uk.co.edgewords.nfocusaugustspecflow.Support.POMPages;

namespace uk.co.edgewords.nfocusaugustspecflow.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver _driver;

        public LoginSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = (IWebDriver)_scenarioContext["mydriver"];

        }
        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            _driver.Url = "https://www.edgewordstraining.co.uk/webdriver2/sdocs/auth.php";
        }

        [When(@"I login using '(.*)' and '(.*)'")]
        public void WhenILoginUsingAnd(string username, string password)
        {
            LoginPOM loginPage = new LoginPOM(_driver);
            loginPage.Login(username, password); //a comment
            //Another comment
        }

        [Then(@"I am logged in successfully")]
        public void ThenIAmLoggedInSuccessfully()
        {
            Thread.Sleep(1000);
            AddRecordPOM addRecordPage = new AddRecordPOM(_driver);
            Assert.That(addRecordPage.GetBodyText(), Does.Contain("User is logged in").IgnoreCase, "Not logged in");
        }
    }
}
