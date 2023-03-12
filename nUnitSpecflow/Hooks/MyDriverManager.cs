using NUnit.Framework;
using nUnitSpecflow.DataAccess;
using nUnitSpecflow.Factories;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Reflection;
using TechTalk.SpecFlow;

namespace nUnitSpecflow.Hooks
{
    [Binding]
    internal class MyDriverManager
    {
        WebDriver _webDriver;
        string _snapshotsFolder;

        public MyDriverManager()
        {
            WebBrowserType webBrowserType = (WebBrowserType)Enum.Parse(
                typeof(WebBrowserType),
                SettingsManager.WebBrowser
            );
            _webDriver = WebDriverFactory.GetDriver(webBrowserType);
            _webDriver.Url = TestContext.Parameters["webAppUrl"];
            _snapshotsFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\snapshots";
            if (!Directory.Exists(_snapshotsFolder))
            {
                Directory.CreateDirectory(_snapshotsFolder);
            }
        }

        internal IWebElement FindElement(By locator)
        {
            try
            {
                return _webDriver.FindElement(locator);
            }
            catch
            {
                CaptureSnapshot();
                throw;
            }
        }

        internal ReadOnlyCollection<IWebElement> FindElements(By locator)
        {
            try
            {
                return _webDriver.FindElements(locator);
            }
            catch
            {
                CaptureSnapshot();
                throw;
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
