# TeamCitySharper

## About

TeamCitySharper is a .NET library to access [TeamCity](http://www.jetbrains.com/teamcity ) REST API in both Async and Sync ways.

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


## Install

## Contribute

[https://github.com/laurentkempe/TeamCitySharper](https://github.com/laurentkempe/TeamCitySharper)

## Support / Help

Follow (@[laurentkempe](https://twitter.com/laurentkempe)) on twitter.

Report bugs & issues on [https://github.com/laurentkempe/TeamCitySharper/issues](https://github.com/laurentkempe/TeamCitySharper/issues)

## Credits and Thanks

Copyright (c) 2102 Laurent Kempé (@[laurentkempe](https://twitter.com/laurentkempe))

