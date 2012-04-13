using System;
using System.Collections.Generic;
using TeamCitySharper;
using TeamCitySharper.Model;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new Test();
            test.Start();

            Console.ReadKey();
        }
    }

    public class Test
    {
        private readonly TeamCityClient _teamCityClient;

        public Test()
        {
            _teamCityClient = new TeamCityClient("username", "password", "yourServerUrl");
        }

        public void Start()
        {
            var allProjects = _teamCityClient.GetProjectDetailsAsync();

            foreach (var task in allProjects)
            {
                var project = task.Result;

                task.ContinueWith(t => WriteLineProjects(project));
            }

        }

        private void WriteLineProjects(Project project)
        {
            Console.WriteLine("Project => {0} : {1}", project.Id, project.Name);

            WriteLineBuildTypes(project.BuildTypes.BuildType);
        }

        private void WriteLineBuildTypes(IEnumerable<BuildType> buildTypes)
        {
            foreach (var buildType in buildTypes)
            {
                Console.WriteLine("Build Types => {0} : {1}", buildType.Name, buildType.ProjectName);
            }
        }
    }

}
