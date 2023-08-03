using nUnitSpecflow.Hooks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace nUnitSpecflow.Pages.Components
{
    internal class DropdownComponent : BaseComponent
    {
        public DropdownComponent(By locator, MyDriverManager myDriverManager)
            : base(locator, myDriverManager) { }

        internal void SelectElementByText(string filterCriteria)
        {
            new SelectElement(FindElement()).SelectByText(filterCriteria);
        }
    }
}
