using Newtonsoft.Json;
using NUnit.Framework;
using nUnitSpecflow.DataAccess;
using nUnitSpecflow.DataAccess.DAO;
using nUnitSpecflow.DataAccess.DTO;
using RestSharp;
using TechTalk.SpecFlow;

namespace nUnitSpecflow.Steps
{
    internal class ReqResSteps : BaseSteps
    {
        public enum ReqResRequestType
        {
            ListUsers
        }

        UsersDao _usersDao;

        public ReqResSteps(FeatureContext featureContext, ScenarioContext scenarioContext)
            : base(featureContext, scenarioContext)
        {
            _usersDao = new UsersDao();
        }

        [Given(@"user initializes the ReqRes connection for ""([^""]*)""")]
        public void GivenUserInitializesTheReqResConnectionFor(ReqResRequestType requestType)
        {
            // do nothing...
        }

        [When(@"user requests a list of ""([^""]*)"" users")]
        public void WhenUserRequestsAListOfUsers(int perPageUsers)
        {
            _usersDao.GetUsersList(requestType: ReqResRequestType.ListUsers, usersPerPage: 5);
        }

        [Then(@"only ""([^""]*)"" users are returned")]
        public void ThenOnlyUsersAreReturned(int expectedPerPageUsers)
        {
            Assert.That(_usersDao.Count(), Is.EqualTo(expectedPerPageUsers));
            Assert.That(
                _usersDao.PerPage,
                Is.EqualTo(expectedPerPageUsers),
                "per_page returned an unexpected value."
            );
        }
    }
}
