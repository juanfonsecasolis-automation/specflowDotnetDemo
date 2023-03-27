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

        private void CaptureSnapshot()
        {
            ((ITakesScreenshot)_webDriver).GetScreenshot().SaveAsFile(
                Path.Combine(_snapshotsFolder, $"{DateTime.Now.ToString("yyMMddmmss")}.png")
            );
        }

        List<string> FindReportedTickets() 
        {
            List<string> ignoreTags = _scenarioContext.ScenarioInfo.Tags.Where(x => x.Contains("ignore")).ToList();
            List<string> reportedTickets = new List<string>();
            if (0<ignoreTags.Count)
            {
                var ticketRegex = new Regex("[0-9+]");
                foreach (var ignoreTag in ignoreTags) 
                {
                    reportedTickets.AddRange(ticketRegex.Matches(ignoreTag).Select(x => x.Value));
                    
                } 
            }
            return reportedTickets;
        }

        public void AssertTrue(bool condition)
        {
            Assert(AssertionType.True, condition);
        }

        public void AssertFalse(bool condition)
        {
            Assert(AssertionType.False, condition);
        }

        void Assert(AssertionType assertionType, bool condition) 
        {
            List<string> reportedTickets = FindReportedTickets();
            if (0 < reportedTickets.Count)
            {
                // TODO: optionally, if there is a connection to Azure DevOps you can make this fail
                // after a period has elapsed (e.g. fail a TC after 30 days a ticket has been reported
                // and not solved).
                NUnit.Framework.Assert.Ignore($"A bug has been already reported on ticket(s): {string.Join(", ", reportedTickets)}");
            }
            else 
            {
                switch(assertionType)
                {
                    case AssertionType.True: NUnit.Framework.Assert.True(condition); break;
                    case AssertionType.False: NUnit.Framework.Assert.False(condition); break;
                    default: throw new NotImplementedException($"Assertion");
                }
            }
        }
    }
}
