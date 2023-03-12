using NUnit.Framework;
using nUnitSpecflow.Hooks;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nUnitSpecflow.Pages
{
    internal class LoginPage : BasePage
    {
        By _usernameFieldLocator = By.XPath("//*[@data-test='username']");
        By _passwordFieldLocator = By.XPath("//*[@data-test='password']");
        By _loginButtonLocator = By.XPath("//*[@data-test='login-button']");

        public LoginPage(MyDriverManager myDriverManager) : base(myDriverManager) { }

        public override void VerifyPageLoadedCorrectly()
        {
            Assert.True(DriverManager.FindElement(_usernameFieldLocator).Displayed);
        }

        internal InventoryPage LoginAndGetInventoryPage(string username, string password)
        {
            DriverManager.FindElement(_usernameFieldLocator).SendKeys(username);
            DriverManager.FindElement(_passwordFieldLocator).SendKeys(password);
            DriverManager.FindElement(_loginButtonLocator).Click();
            return new InventoryPage(DriverManager); // TODO: handle bad login
        }
    }
}
