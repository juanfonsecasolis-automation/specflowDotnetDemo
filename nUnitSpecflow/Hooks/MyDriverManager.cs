using NUnit.Framework;
using nUnitSpecflow.DataAccess;
using nUnitSpecflow.Factories;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V85.CSS;
using OpenQA.Selenium.Internal;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;
using NUnit.Framework;
using AngleSharp.Html.Dom;
using OpenQA.Selenium.Support.UI;

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
        ScenarioContext _scenarioContext;

        public MyDriverManager(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
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

        internal void SelectElementFromDropdown(By filterDropdownLocator, string filterCriteria)
        {
            var dropdownElement = new SelectElement(_webDriver.FindElement(filterDropdownLocator));
            dropdownElement.SelectByText(filterCriteria);
        }

        private void CaptureSnapshot()
        {
            ((ITakesScreenshot)_webDriver).GetScreenshot().SaveAsFile(
                Path.Combine(_snapshotsFolder, $"{DateTime.Now.ToString("yyMMddmmss")}.png")
            );
        }
    }
}
