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

        Task<BuildType> GetBuildTypeDetailsAsync(BuildType buildType);
        
        Task<List<Build>> GetBuildsForAsync(BuildType buildType, int count = 5);
        List<Build> GetBuildsFor(BuildType buildType, int count = 5);
    }
}