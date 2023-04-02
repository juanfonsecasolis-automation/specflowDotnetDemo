using nUnitSpecflow.Hooks;
using nUnitSpecflow.Pages;
using TechTalk.SpecFlow;

namespace nUnitSpecflow.Steps
{
    internal class LoginSteps : BaseSteps
    {
        public LoginSteps(MyDriverManager myDriverManager, ScenarioContext scenarioContext) : base(myDriverManager, scenarioContext) { }

        [Given(@"user opens the login page")]
        public void GivenUserOpensTheLoginPage()
        {
            CurrentPage = new LoginPage(MyDriverManager);
        }

        [When(@"user logins with username ""([^""]*)"" and password ""([^""]*)""")]
        public void WhenUserLoginsWithUsernameAndPassword(string username, string password)
        {
            CurrentPage = ((LoginPage)CurrentPage).LoginAndGetInventoryPage(username, password);
        }

        [Then(@"the inventory page is displayed")]
        public void ThenTheInventoryPageIsDisplayed()
        {
        }

        [When(@"user selects ""([^""]*)"" in the filter dropdown")]
        public void WhenUserSelectsInTheFilterDropdown(string filterCriteria)
        {
            ((InventoryPage)CurrentPage).FilterBy(filterCriteria);
        }

        [Then(@"inventory items are ordered from low to high")]
        public void ThenInventoryItemsAreOrderedFromLowToHigh()
        {
            throw new PendingStepException();
        }


    }
}
