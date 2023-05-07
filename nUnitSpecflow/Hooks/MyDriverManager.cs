using NUnit.Framework;
using nUnitSpecflow.DataAccess;
using nUnitSpecflow.Factories;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using System.Reflection;
using TechTalk.SpecFlow;

namespace nUnitSpecflow.Hooks
{
    enum AssertionType
    {
        True,
        False
    }

    [Binding]
    internal class MyDriverManager
    {
        WebDriver _webDriver;
        string _snapshotsFolder;
        WebDriverWait _webDriverWait;

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
            _webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(SettingsManager.SecsTimeoutElementVisible));
        }

        internal IWebElement FindElement(By locator, bool waitUntilVisible=true)
        {
            if (waitUntilVisible)
            {
                _webDriverWait.Until(x => x.FindElement(locator).Enabled && x.FindElement(locator).Displayed);
            }
            return _webDriver.FindElement(locator);
        }

        internal ReadOnlyCollection<IWebElement> FindElements(By locator, bool waitUntilVisible = true)
        {
            if (waitUntilVisible)
            {
                _webDriverWait.Until(x => x.FindElement(locator).Enabled && x.FindElement(locator).Displayed);
            }
            return _webDriver.FindElements(locator);
        }

        internal void Quit()
        {
            _webDriver.Close();
            _webDriver.Quit();
        }

        internal void SelectElementFromDropdown(By filterDropdownLocator, string filterCriteria)
        {
            var dropdownElement = new SelectElement(_webDriver.FindElement(filterDropdownLocator));
            dropdownElement.SelectByText(filterCriteria);
        }

        public string CaptureSnapshot()
        {
            string filename = $"{DateTime.Now.ToString("yyMMddmmss")}.png";
            ((ITakesScreenshot)_webDriver).GetScreenshot().SaveAsFile(
                Path.Combine(_snapshotsFolder, filename)
            );
            return filename;
        }
    }
}
