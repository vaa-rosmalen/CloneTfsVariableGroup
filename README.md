# CloneTfsVariableGroup

A simple tool to clone a variable group in TFS. Provide a TFS instance url and an access token and it will provide a list of projects and variable groups.

# Get started

Make sure you have .NET Core 2.2 or newer installed. Run the following command:

```
clonetfsvariablegroup
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
