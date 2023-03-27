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
            Assert.True(MyDriverManager.FindElement(_usernameFieldLocator).Displayed);
        }

        internal InventoryPage LoginAndGetInventoryPage(string username, string password)
        {
            MyDriverManager.FindElement(_usernameFieldLocator).SendKeys(username);
            MyDriverManager.FindElement(_passwordFieldLocator).SendKeys(password);
            MyDriverManager.FindElement(_loginButtonLocator).Click();
            return new InventoryPage(MyDriverManager); // TODO: handle bad login
        }
    }
}
