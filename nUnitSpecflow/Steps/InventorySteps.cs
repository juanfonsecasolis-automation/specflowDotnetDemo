using NUnit.Framework;
using nUnitSpecflow.Pages;
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
            Assert.True(6 == ((InventoryPage)CurrentPage).GetInventoryItems(InventoryItemFieldType.Name).Count);
        }

        [Then(@"inventory items are ordered from price low to high")]
        public void ThenInventoryItemsAreOrderedFromPriceLowToHigh()
        {
            Regex numberRegex = new Regex(@"[0-9]+\.[0-9]+");
            var list = ((InventoryPage)CurrentPage).GetInventoryItems(InventoryItemFieldType.Price);
            for (int i = 0; i < list.Count() - 1; i++)
            {
                Assert.GreaterOrEqual(
                    double.Parse(numberRegex.Match(list[i + 1]).Value),
                    double.Parse(numberRegex.Match(list[i]).Value)
                );
            }
        }
    }
}
