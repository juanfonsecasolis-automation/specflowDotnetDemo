using nUnitSpecflow.DataAccess;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace nUnitSpecflow.Factories
{
    public enum WebBrowserType
    {
        Chrome,
        Firefox,
        Edge,
        ChromeRaspberryPi
    }

    internal class WebDriverFactory
    {
        public static WebDriver GetDriver(WebBrowserType webBrowserType)
        {
            switch (webBrowserType)
            {
                case WebBrowserType.Edge:
                    var edgeOptions = new EdgeOptions();
                    if (SettingsManager.HeadlessEnabled)
                        edgeOptions.AddArgument("headless");
                    return new EdgeDriver(edgeOptions);

                case WebBrowserType.Chrome:
                    var chromeOptions = new ChromeOptions();
                    if (SettingsManager.HeadlessEnabled)
                        chromeOptions.AddArgument("--headless");
                    return new ChromeDriver(chromeOptions);

                case WebBrowserType.ChromeRaspberryPi:
                    var chromeRaspberryPiOptions = new ChromeOptions();
                    chromeRaspberryPiOptions.AddArguments("--no-sandbox");
                    chromeRaspberryPiOptions.AddArguments("--disable-dev-shm-usage");
                    if (SettingsManager.HeadlessEnabled)
                        chromeRaspberryPiOptions.AddArgument("--headless");
                    return new ChromeDriver("/usr/lib/chromium-browser", chromeRaspberryPiOptions); // run `sudo apt-get install chromium-chromedriver` in the RPi

                default:
                    throw new NotSupportedException();
            }
        }
    }
}
