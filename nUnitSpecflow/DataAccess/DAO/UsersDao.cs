using nUnitSpecflow.DataAccess.DTO;
using RestSharp;
using static nUnitSpecflow.Steps.ReqResSteps;

namespace nUnitSpecflow.DataAccess.DAO
{
    internal class UsersDao
    {
        RestClient _restClient;
        RestRequest _restRequest;
        UsersDto _usersDto;

        public UsersDao()
        {
            _restClient = new RestClient(SettingsManager.ReqResUrl);
        }

        internal int Count() => _usersDto.Data.Count();

        internal void GetUsersList(ReqResRequestType requestType, int usersPerPage)
        {
            _restRequest = new RestRequest(
                requestType switch
                {
                    ReqResRequestType.ListUsers => "/api/users",
                    _ => throw new NotImplementedException()
                }
            );
            _restRequest.AddParameter("per_page", usersPerPage);
            _usersDto = _restClient.Get<UsersDto>(_restRequest);
        }

        internal int PerPage() => _usersDto.PerPage;
    }
}
