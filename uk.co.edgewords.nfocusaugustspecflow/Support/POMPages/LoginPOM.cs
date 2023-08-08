using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.edgewords.nfocusaugustspecflow.Support.POMPages
{
    public class LoginPOM
    {
        private IWebDriver _driver;

        public LoginPOM(IWebDriver driver)
        {
            _driver = driver;
        }

        //Locators
        private IWebElement _usernameField => _driver.FindElement(By.Id("username"));
        private IWebElement _passwordField => _driver.FindElement(By.Id("password"));
        private IWebElement _submitButton => _driver.FindElement(By.LinkText("Submit"));

        //Service Methods
        public void Login(string username, string password)
        {
            _usernameField.Clear();
            _usernameField.SendKeys(username);
            _passwordField.Clear();
            _passwordField.SendKeys(password);
            _submitButton.Click();
        }

    }
}
