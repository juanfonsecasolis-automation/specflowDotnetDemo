using NUnit.Framework;
using nUnitSpecflow.Hooks;
using OpenQA.Selenium;
using WebDriverManager;

namespace nUnitSpecflow.Pages
{
    internal class InventoryPage : BasePage
    {
        By _productsHeaderLocator = By.XPath("//span[@class='title']");

        public InventoryPage(MyDriverManager myDriverManager) : base(myDriverManager) { }

        public override void VerifyPageLoadedCorrectly()
        {
            Assert.IsTrue(DriverManager.FindElement(_productsHeaderLocator).Displayed);
        }

        internal List<string> GetInventoryItems()
        {
            return this.DriverManager.FindElements(By.CssSelector(".inventory_item"))
                .Select(x => x.Text).ToList<string>();
        }
    }
}
