using NUnit.Framework;
using nUnitSpecflow.Hooks;
using nUnitSpecflow.Pages.Components;
using OpenQA.Selenium;

namespace nUnitSpecflow.Pages
{
    internal class InventoryPage : WithUpperMenuPage
    {
        LabelComponent _productHeaderLabel;
        DropdownComponent _filterDropdown;
        public InventoryElementsComponent InventoryElements;

        public InventoryPage(MyDriverManager myDriverManager)
            : base(myDriverManager)
        {
            _productHeaderLabel = new LabelComponent(
                By.XPath("//span[@class='title']"),
                MyDriverManager
            );
            _filterDropdown = new DropdownComponent(
                By.XPath("//select[@data-test='product_sort_container']"),
                MyDriverManager
            );
            InventoryElements = new InventoryElementsComponent(MyDriverManager);
            VerifyPageLoadedCorrectly();
        }

        public override void VerifyPageLoadedCorrectly()
        {
            Assert.True(_productHeaderLabel.IsDisplayed);
        }

        internal void FilterBy(string filterCriteria)
        {
            _filterDropdown.SelectElementByText(filterCriteria);
        }
    }
}
