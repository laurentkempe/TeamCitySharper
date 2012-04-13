using System.Collections.Generic;
using System.Threading.Tasks;
using TeamCitySharper.Model;

namespace TeamCitySharper
{
    public interface ITeamCityClient
    {
        Task<List<Project>> GetAllProjectsAsync();
        IEnumerable<Project> GetAllProjects();

        IEnumerable<Task<Project>> GetProjectDetailsAsync();
    }
}