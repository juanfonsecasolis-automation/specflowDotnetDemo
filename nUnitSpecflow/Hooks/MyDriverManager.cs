using NUnit.Framework;
using nUnitSpecflow.Factories;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace nUnitSpecflow.Hooks
{
    [Binding]
    internal class MyDriverManager
    {
        public WebDriver WebDriver;

        public MyDriverManager() {
            WebBrowserType webBrowserType = (WebBrowserType)Enum.Parse(typeof(WebBrowserType), TestContext.Parameters["webBrowser"]);
            WebDriver = WebDriverFactory.GetDriver(webBrowserType);
            WebDriver.Url = TestContext.Parameters["webAppUrl"];
        }
    }
}
