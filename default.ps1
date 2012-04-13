properties {
    $BaseDir = Resolve-Path .
    $SolutionFile = "$BaseDir\TeamCitySharper.sln"
}

$framework = '4.0'

Task Default -depends Build

Task Init {
	cls
}

Task Build -depends Init {
	Exec { msbuild $SolutionFile }
}
