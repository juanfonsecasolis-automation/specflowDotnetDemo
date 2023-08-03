using nUnitSpecflow.Hooks;
using OpenQA.Selenium;

namespace nUnitSpecflow.Pages.Components
{
    internal class InventoryElementsComponent : BaseComponent
    {
        public int Count => _myDriverManager.FindElements(_locator).Count;

        public InventoryElementsComponent(MyDriverManager myDriverManager)
            : base(By.XPath("//*[@class='inventory_item']"), myDriverManager) { }

        public InventoryElementComponent GetValue(int index)
        {
            return new InventoryElementComponent(
                By.XPath($"{_locator.Criteria}[{index + 1}]"),
                _myDriverManager
            );
        }
    }
}
