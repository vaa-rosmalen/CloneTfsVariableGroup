[![Build status](https://ci.appveyor.com/api/projects/status/5y76tvvcxbbofol1/branch/master?svg=true)](https://ci.appveyor.com/project/JacobDuijzer88395/clonetfsvariablegroup/branch/master) [![Nuget status](https://buildstats.info/nuget/clonetfsvariablegroup-cli?includePreReleases=false)](https://www.nuget.org/packages/clonetfsvariablegroup-cli/) 

# CloneTfsVariableGroup

A simple tool to clone a variable group in TFS. Provide a TFS instance url and an access token and it will provide a list of projects and variable groups.

# Get started

Make sure you have .NET Core 2.2 or newer installed. Run the following command:

```
dotnet tool install -g clonetfsvariablegroup-cli
```

Run the tool to start cloning:
```
CloneTfsVariableGroup -u {tfs-instance-url} -t {access-token}
```

If your TFS instance has a lot of projects it might be easier to add a filter:
```
CloneTfsVariableGroup -u {tfs-instance-url} -t {access-token} -f {part-of-projectname}
```

# To do

* Clone variable group into a different project
