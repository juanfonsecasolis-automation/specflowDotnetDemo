using nUnitSpecflow.Hooks;
using OpenQA.Selenium;

namespace nUnitSpecflow.Pages.Components
{
    internal class TextFieldComponent : BaseComponent
    {
        public TextFieldComponent(By locator, MyDriverManager myDriverManager) 
            : base(locator, myDriverManager) { }

        public void Type(string text) => FindElement().SendKeys(text);
    }
}
