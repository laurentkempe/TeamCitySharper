# TeamCitySharper

## About

TeamCitySharper is a .NET 4 library to access [TeamCity](http://www.jetbrains.com/teamcity ) REST API in both Async and Sync ways.

## Usage

### Async usage

```c#
        var teamCityClient = new TeamCityClient("username", "password", "yourServerUrl");
        
        IEnumerable<Task<Project>> allProjects = teamCityClient.GetProjectDetailsAsync();
        
        foreach (var task in allProjects)
        {
            var project = task.Result;
        
            task.ContinueWith(t => WriteLineProjects(project));
        }
```

### Sync usage

```c#
        var teamCityClient = new TeamCityClient("username", "password", "yourServerUrl");
        
        IEnumerable<Project> allProjects = teamCityClient.GetProjectDetailsAsync();
        
        foreach (var project in allProjects)
        {       
            WriteLineProjects(project);
        }
```


## Build

You might use the ClickToBuild.bat which use [psake](https://github.com/psake/psake) or just open the solution in Visual Studio 2010

## Contribute

[https://github.com/laurentkempe/TeamCitySharper](https://github.com/laurentkempe/TeamCitySharper)

## Support / Help

Follow (@[laurentkempe](https://twitter.com/laurentkempe)) on twitter.

Report bugs & issues on [https://github.com/laurentkempe/TeamCitySharper/issues](https://github.com/laurentkempe/TeamCitySharper/issues)

## Credits and Thanks

Copyright (c) 2102 Laurent Kempé (@[laurentkempe](https://twitter.com/laurentkempe))

