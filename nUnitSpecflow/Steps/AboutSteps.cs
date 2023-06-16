using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace nUnitSpecflow.Steps
{
    internal class AboutSteps : BaseSteps
    {

        public AboutSteps(FeatureContext featureContext, ScenarioContext scenarioContext) : base(featureContext, scenarioContext) { }

        [Then(@"the saucelabs webpage is displayed")]
        public void ThenTheSaucelabsWebpageIsDisplayed()
        {
            MyDriverManager.ExecuteJavascript("window.performance.getEntries()");
        }

    }
}
