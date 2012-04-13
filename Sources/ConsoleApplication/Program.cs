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

            foreach (var buildType in project.BuildTypes.BuildType)
            {
                var task = _teamCityClient.GetBuildTypeDetailsAsync(buildType);
                task.ContinueWith(t => WriteLineBuildTypes(t.Result));
            }
        }

        private void WriteLineBuildTypes(BuildType buildType)
        {
            Console.WriteLine("Build Types => {0} : {1}", buildType.Name, buildType.ProjectName);

            var builds = _teamCityClient.GetBuildsFor(buildType);

            foreach (var build in builds)
            {
                WriteLineBuild(build);
            }
        }

        private void WriteLineBuild(Build build)
        {
            Console.WriteLine("Build => {0}", build.Status);
        }
    }

}
