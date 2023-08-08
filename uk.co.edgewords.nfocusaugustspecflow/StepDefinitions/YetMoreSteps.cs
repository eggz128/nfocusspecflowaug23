using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.edgewords.nfocusaugustspecflow.StepDefinitions
{
    [Binding]
    public class YetMoreSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver _driver;
        public YetMoreSteps(ScenarioContext scenarioContext)
        {

            _scenarioContext = scenarioContext;
            _driver = _scenarioContext["mydriver"] as IWebDriver;
        }



        [Given(@"(?i)I am (?-i)at (?:G|g)oogle")]
        [StepDefinition(@"I am (?:on|at) the Google homepage")]
        public void GivenIAmOnGoogle()
        {
            _driver.Url = "https://www.google.co.uk";
            _driver.FindElement(By.CssSelector("#L2AGLb > div")).Click();

            string bodyText = _driver.FindElement(By.TagName("body")).Text;
            _scenarioContext["theBodyText"] = bodyText;
        }
    }
}
