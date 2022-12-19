using nUnitSpecflow.Hooks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace nUnitSpecflow.Factories
{
    public enum WebBrowserType { 
        Chrome,
        Firefox,
        Edge
    }

    internal class WebDriverFactory
    {
        public static WebDriver GetDriver(WebBrowserType webBrowserType) {
            WebDriver webDriver;
            switch (webBrowserType) {
                case WebBrowserType.Edge:
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    webDriver = new EdgeDriver();
                    break;
                default:
                    throw new NotSupportedException();
            }
            return webDriver;
        }
    }
}
