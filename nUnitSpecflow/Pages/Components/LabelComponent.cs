using nUnitSpecflow.Hooks;
using OpenQA.Selenium;

namespace nUnitSpecflow.Pages.Components
{
    internal class LabelComponent : BaseComponent
    {
        public LabelComponent(By locator, MyDriverManager myDriverManager) 
            : base(locator, myDriverManager){}

        public LabelComponent(By locator, By parentLocator, MyDriverManager myDriverManager)
            : base(locator, parentLocator, myDriverManager){}

        public string Text => FindElement().Text;
    }
}
