using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace nUnitSpecflow.Steps
{
    internal class MenuSteps : BaseSteps
    {
        public enum HamburgerElementType
        {
            About
        }

        public MenuSteps(FeatureContext featureContext, ScenarioContext scenarioContext)
            : base(featureContext, scenarioContext) { }

        [When(@"user selects ""([^""]*)"" in the hamburger menu")]
        public void WhenUserSelectsInTheHamburgerMenu(HamburgerElementType elementType)
        {
            MyDriverManager.FindElement(By.Id("react-burger-menu-btn")).Click();
            MyDriverManager
                .FindElement(
                    elementType switch
                    {
                        HamburgerElementType.About => By.Id("about_sidebar_link"),
                        _ => throw new NotImplementedException()
                    }
                )
                .Click();
        }
    }
}
