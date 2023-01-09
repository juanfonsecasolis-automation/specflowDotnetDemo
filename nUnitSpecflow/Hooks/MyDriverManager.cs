using Microsoft.VisualStudio.TestPlatform.Utilities;
using NUnit.Framework;
using nUnitSpecflow.Factories;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace nUnitSpecflow.Hooks
{
    [Binding]
    internal class MyDriverManager
    {
        WebDriver _webDriver;
        string _snapshotsFolder;

        public MyDriverManager() {
            WebBrowserType webBrowserType = (WebBrowserType)Enum.Parse(
                typeof(WebBrowserType), 
                TestContext.Parameters["webBrowser"]
            );
            _webDriver = WebDriverFactory.GetDriver(webBrowserType);
            _webDriver.Url = TestContext.Parameters["webAppUrl"];
            _snapshotsFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\snapshots";
            if (!Directory.Exists(_snapshotsFolder)) {
                Directory.CreateDirectory(_snapshotsFolder);
            }
        }

        internal IWebElement FindElement(By locator)
        {
            try
            {
                return _webDriver.FindElement(locator);
            }
            catch(Exception e){
                CaptureSnapshot();
                throw e;
            }  
        }

        internal void Quit()
        {
            _webDriver.Close();
            _webDriver.Quit();
        }

        private void CaptureSnapshot()
        {
            ((ITakesScreenshot)_webDriver).GetScreenshot().SaveAsFile(
                Path.Combine(_snapshotsFolder, $"{DateTime.Now.ToString("yyMMddmmss")}.png")    
            );
        }
    }
}
