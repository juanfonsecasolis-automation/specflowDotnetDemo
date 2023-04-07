using nUnitSpecflow.DataAccess;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;

namespace nUnitSpecflow.Factories
{
    public enum WebBrowserType
    {
        Chrome,
        Firefox,
        Edge
    }

    internal class WebDriverFactory
    {
        public static WebDriver GetDriver(WebBrowserType webBrowserType)
        {
            WebDriver webDriver;
            switch (webBrowserType)
            {
                case WebBrowserType.Edge:
                    var edgeOptions = new EdgeOptions();
                    if (SettingsManager.HeadlessEnabled)
                        edgeOptions.AddArgument("headless");
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    webDriver = new EdgeDriver(edgeOptions);
                    break;
                case WebBrowserType.Chrome:
                    var chromeOptions = new ChromeOptions();
                    if (SettingsManager.HeadlessEnabled)
                        chromeOptions.AddArgument("--headless");
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    webDriver = new ChromeDriver(chromeOptions);
                    break;
                default:
                    throw new NotSupportedException();
            }
            return webDriver;
        }
    }
}
