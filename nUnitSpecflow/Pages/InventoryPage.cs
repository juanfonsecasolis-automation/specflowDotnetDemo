using NUnit.Framework;
using nUnitSpecflow.Hooks;
using OpenQA.Selenium;

namespace nUnitSpecflow.Pages
{
    internal class InventoryPage : BasePage
    {
        By _productsHeaderLocator = By.XPath("//span[@class='title']");

        public InventoryPage(MyDriverManager myDriverManager) : base(myDriverManager) { }

        public override void VerifyPageLoadedCorrectly()
        {
            Assert.IsTrue(_myDriverManager.FindElement(_productsHeaderLocator).Displayed);
        }
    }
}
