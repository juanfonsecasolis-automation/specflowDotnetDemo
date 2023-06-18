using nUnitSpecflow.Hooks;
using OpenQA.Selenium;

namespace nUnitSpecflow.Pages.Components
{
    internal class MenuComponent : BaseComponent
    {
        public MenuComponent(By locator, MyDriverManager myDriverManager) 
            : base(locator, myDriverManager) {}

        internal void ClickElementByText(string elementText)
        {
            FindElement().FindElement(By.XPath($".//*[text()='{elementText}']")).Click();
        }
    }
}
