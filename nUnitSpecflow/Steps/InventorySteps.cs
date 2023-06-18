using NUnit.Framework;
using nUnitSpecflow.Pages;
using nUnitSpecflow.Pages.Components;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;
using static nUnitSpecflow.Pages.InventoryPage;

namespace nUnitSpecflow.Steps
{
    [Binding]
    internal class InventorySteps : BaseSteps
    {
        public InventorySteps(FeatureContext featureContext, ScenarioContext scenarioContext) : base(featureContext, scenarioContext) { }

        [Then(@"only six items are rendered")]
        public void ThenOnlySixItemsAreRendered()
        {
            Assert.True(6 == ((InventoryPage)CurrentPage).InventoryElements.Count);
        }

        [Then(@"inventory items are ordered from price low to high")]
        public void ThenInventoryItemsAreOrderedFromPriceLowToHigh()
        {
            Regex numberRegex = new Regex(@"[0-9]+\.[0-9]+");
            var inventoryElements = ((InventoryPage)CurrentPage).InventoryElements;
            
            for (int i=0; i<inventoryElements.Count-1; i++) 
            {
                Assert.GreaterOrEqual(
                    double.Parse(numberRegex.Match(inventoryElements.GetValue(i + 1).Price).Value),
                    double.Parse(numberRegex.Match(inventoryElements.GetValue(i).Price).Value)
                );
            }
        }
    }
}
