using NUnit.Framework;
using nUnitSpecflow.Hooks;
using OpenQA.Selenium;
using WebDriverManager;

namespace nUnitSpecflow.Pages
{
    internal class InventoryPage : BasePage
    {
        By _productsHeaderLocator = By.XPath("//span[@class='title']");
        By _filterDropdownLocator = By.XPath("//select[@data-test='product_sort_container']");

        public enum InventoryItemFieldType
        {
            Name,
            Price
        }

        public InventoryPage(MyDriverManager myDriverManager) : base(myDriverManager) { }

        public override void VerifyPageLoadedCorrectly()
        {
            Assert.True(MyDriverManager.FindElement(_productsHeaderLocator).Displayed);
        }

        internal void FilterBy(string filterCriteria)
        {
            MyDriverManager.SelectElementFromDropdown(_filterDropdownLocator, filterCriteria);
        }

        internal List<string> GetInventoryItems(InventoryItemFieldType fieldType)
        {
            By locator = fieldType switch
            {
                InventoryItemFieldType.Name => By.ClassName("inventory_item_name"),
                InventoryItemFieldType.Price => By.ClassName("inventory_item_price"),
                _ => By.CssSelector(".inventory_item")
            };
            return MyDriverManager.FindElements(locator).Select(x => x.Text).ToList<string>();
        }

        internal void LogOut()
        {
            MyDriverManager.FindElement(By.Id("react-burger-menu-btn")).Click();
            MyDriverManager.FindElement(By.Id("logout_sidebar_link")).Click();
        }
    }
}
