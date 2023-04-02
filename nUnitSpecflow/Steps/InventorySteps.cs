using NUnit.Framework;
using nUnitSpecflow.Hooks;
using nUnitSpecflow.Pages;
using TechTalk.SpecFlow;

namespace nUnitSpecflow.Steps
{
    [Binding]
    internal class InventorySteps : BaseSteps
    {
        public InventorySteps(MyDriverManager myDriverManager, ScenarioContext scenarioContext) : base(myDriverManager, scenarioContext) { }

        [Then(@"only six items are rendered")]
        public void ThenOnlySixItemsAreRendered()
        {
            MyDriverManager.AssertTrue(6==((InventoryPage)CurrentPage).GetInventoryItems().Count);
        }

    }
}
