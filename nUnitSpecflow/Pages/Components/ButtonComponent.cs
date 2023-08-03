using nUnitSpecflow.Hooks;
using OpenQA.Selenium;

namespace nUnitSpecflow.Pages.Components
{
    internal class ButtonComponent : BaseComponent
    {
        public ButtonComponent(By locator, MyDriverManager myDriverManager)
            : base(locator, myDriverManager) { }

        internal void Click() => FindElement().Click();
    }
}
