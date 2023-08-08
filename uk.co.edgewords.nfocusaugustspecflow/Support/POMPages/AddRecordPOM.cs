using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.edgewords.nfocusaugustspecflow.Support.POMPages
{
    public class AddRecordPOM
    {

        private IWebDriver _driver;

        public AddRecordPOM(IWebDriver driver)
        {
            _driver = driver;
        }

        //Locators
        private IWebElement _body => _driver.FindElement(By.TagName("body"));

        //Service Methods
        public string GetBodyText()
        {
            return _body.Text;
        }
    }
}
