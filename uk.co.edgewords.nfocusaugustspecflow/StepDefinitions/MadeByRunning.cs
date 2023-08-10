using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V113.FedCm;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace uk.co.edgewords.nfocusaugustspecflow.StepDefinitions
{
    [Binding]
    public class StepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver _driver;
        public StepDefinitions(ScenarioContext scenarioContext)
        {
            
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext["mydriver"] as IWebDriver;
        }


        [StepDefinition(@"I search for '(.*)'")]
        public void WhenISearchForEdgewords(string searchTerm)
        {
            Console.WriteLine((string)_scenarioContext["theBodyText"]);
            _driver.FindElement(By.Name("q")).SendKeys(searchTerm);
            //_driver.FindElement(By.CssSelector("body > div.L3eUgb > div.o3j99.ikrT4e.om7nvf > form > div:nth-child(1) > div.A8SBwf > div.FPdoLc.lJ9FBc > center > input.gNO89b")).Click();
            new WebDriverWait(_driver, TimeSpan.FromSeconds(3)).Until(drv => drv.FindElement(By.CssSelector("body > div.L3eUgb > div.o3j99.ikrT4e.om7nvf > form > div:nth-child(1) > div.A8SBwf.emcav > div.UUbT9 > div.aajZCb > div.lJ9FBc > center > input.gNO89b"))).Click();
        }

        [Then(@"'(.*)' is the top result")]
        public void ThenEdgewordsIsTheTopResult(string resultTerm)
        {
            //May need a wait here
            string topResult = _driver.FindElement(By.CssSelector("#search div.MjjYud")).Text;
            //Nunit Constraint
            Assert.That(topResult, Does.Contain(resultTerm), "Edgewords was not the top result");
            //Fluent Assertion
            topResult.Should().Contain(resultTerm);
        }

        [Then(@"I should see in the results")]
        public void ThenIShouldSeeInTheResults(Table table)
        {
            string results = _driver.FindElement(By.Id("rso")).Text;

            foreach (var row in table.Rows)
            {
                Assert.That(results, Does.Contain(row["url"]));
                Assert.That(results, Does.Contain(row["description"]));
            }
        }

    }
}