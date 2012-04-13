using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using TeamCitySharper.Model;
using TeamCitySharper.RestSharp;

namespace TeamCitySharper
{
    public class TeamCityClient : ITeamCityClient
    {
        private readonly string _username;
        private readonly string _password;
        private readonly RestClient _restClient;

        public TeamCityClient(string username, string password, string serverUrl)
        {
            _username = username;
            _password = password;

            _restClient = new RestClient(serverUrl) { Authenticator = new HttpBasicAuthenticator(_username, _password) };
        }

        public Task<List<Project>> GetAllProjectsAsync()
        {
            var request = GetRestRequestFor("/httpAuth/app/rest/projects");
            request.RootElement = "project";

            return _restClient.GetAsync<List<Project>>(request);
        }

        public IEnumerable<Project> GetAllProjects()
        {
            var allProjectsAsync = GetAllProjectsAsync();
            allProjectsAsync.Wait();

            return allProjectsAsync.Result;
        }

        public IEnumerable<Task<Project>> GetProjectDetailsAsync()
        {
            var allProjects = GetAllProjects();

            return allProjects.Select(GetProjectDetailAsync);
        }

        private Task<Project> GetProjectDetailAsync(Project project)
        {
            return _restClient.GetAsync<Project>(GetRestRequestFor(project.Href));
        }

        private static RestRequest GetRestRequestFor(string resource)
        {
            var request = new RestRequest { Resource = resource };
            request.AddHeader("Accept", "application/json");
            
            return request;
        }
    }
}