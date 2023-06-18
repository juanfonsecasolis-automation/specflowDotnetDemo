using NUnit.Framework;
using nUnitSpecflow.Hooks;
using OpenQA.Selenium;

namespace nUnitSpecflow.Pages.Components
{
    internal abstract class BaseComponent
    {
        protected MyDriverManager _myDriverManager;
        protected By? _parentLocator;
        protected By _locator;
        public bool IsDisplayed => FindElement().Displayed;

        public BaseComponent(By locator, MyDriverManager myDriverManager)
        {
            _parentLocator = null;
            _locator = locator;
            _myDriverManager = myDriverManager;
        }

        public BaseComponent(By locator, By parentLocator, MyDriverManager myDriverManager)
        {
            _parentLocator = parentLocator;
            _locator = locator;
            _myDriverManager = myDriverManager;
        }

        protected IWebElement FindElement()
        {
            return _parentLocator == null ? _myDriverManager.FindElement(_locator)
                : _myDriverManager.FindElement(_parentLocator).FindElement(_locator);
        }
    }
}
