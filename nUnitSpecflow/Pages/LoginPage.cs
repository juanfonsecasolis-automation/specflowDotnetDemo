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

        public LoginPage(MyDriverManager myDriverManager) : base(myDriverManager) { }

        public override void VerifyPageLoadedCorrectly()
        {
            Assert.True(_myDriverManager.WebDriver.FindElement(_usernameFieldLocator).Displayed);
        }

        internal void LogInWithUsernameAndPassword(string username, string password)
        {
        }
    }
}
