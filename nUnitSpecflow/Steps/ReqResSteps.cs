using Newtonsoft.Json;
using NUnit.Framework;
using nUnitSpecflow.DataAccess;
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

        RestClient _restClient;
        RestRequest _restRequest;
        JsonSerializable _jsonSerializableResponse;

        public ReqResSteps(FeatureContext featureContext, ScenarioContext scenarioContext)
            : base(featureContext, scenarioContext)
        {
            _restClient = new RestClient(SettingsManager.ReqResUrl);
        }

        [Given(@"user initializes the ReqRes connection for ""([^""]*)""")]
        public void GivenUserInitializesTheReqResConnectionFor(ReqResRequestType requestType)
        {
            _restRequest = new RestRequest(
                requestType switch
                {
                    ReqResRequestType.ListUsers => "/api/users",
                    _ => throw new NotImplementedException()
                }
            );
        }

        [When(@"user requests a list of ""([^""]*)"" users")]
        public void WhenUserRequestsAListOfUsers(int perPageUsers)
        {
            _restRequest.AddParameter("per_page", "5");
            _jsonSerializableResponse = _restClient.Get<UserListDto>(_restRequest);
        }

        [Then(@"only ""([^""]*)"" users are returned")]
        public void ThenOnlyUsersAreReturned(int expectedPerPageUsers)
        {
            var userListDto = (UserListDto)_jsonSerializableResponse;
            Assert.That(userListDto.Data.Count(), Is.EqualTo(expectedPerPageUsers));
            Assert.That(
                userListDto.PerPage,
                Is.EqualTo(expectedPerPageUsers),
                "per_page returned an unexpected value."
            );
        }
    }
}
