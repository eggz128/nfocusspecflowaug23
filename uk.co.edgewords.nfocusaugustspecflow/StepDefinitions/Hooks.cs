using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        [Before]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _scenarioContext["mydriver"] = _driver;
            //_scenarioContext["mydriver"] = "bob"; //No compile time warnings that this is wrong
        }


        [After]
        public void TearDown()
        {
            Thread.Sleep(2000); //So we can see what's going on
            _driver.Quit();
        }
    }
}
