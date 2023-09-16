using NUnit.Framework;
using nUnitSpecflow.DataAccess;
using nUnitSpecflow.Pages;
using TechTalk.SpecFlow;
using static nUnitSpecflow.Pages.InventoryPage;

namespace nUnitSpecflow.Steps
{
    internal class LoginSteps : BaseSteps
    {
        public LoginSteps(FeatureContext featureContext, ScenarioContext scenarioContext)
            : base(featureContext, scenarioContext) { }

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
        [When(@"the inventory page is displayed")]
        public void TheInventoryPageIsDisplayed() { }

        [When(@"user selects ""([^""]*)"" in the filter dropdown")]
        public void WhenUserSelectsInTheFilterDropdown(string filterCriteria)
        {
            ((InventoryPage)CurrentPage).FilterBy(filterCriteria);
        }

        [Given(@"user logs in using valid credentials")]
        public void GivenUserLogsInUsingValidCredentials()
        {
            GivenUserOpensTheLoginPage();
            WhenUserLoginsWithUsernameAndPassword(
                SettingsManager.Username,
                SettingsManager.Password
            );
        }

        [Then(@"the ""([^""]*)"" description is displayed")]
        public void ThenTheDescriptionIsDisplayed(string productName)
        {
            Assert.AreEqual(
                _resourceManager.GetString(productName),
                ((InventoryPage)CurrentPage).GetItemDescription(productName)
            );
        }
    }
}
