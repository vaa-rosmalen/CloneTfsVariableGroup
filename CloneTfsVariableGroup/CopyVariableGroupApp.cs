using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CloneTfsVariableGroup.Models;
using CloneTfsVariableGroup.Services;

namespace CloneTfsVariableGroup
{
    public class CopyVariableGroupApp
    {
        private readonly Arguments _arguments;
        private readonly RemoteTfsApiService _remoteTfsApi;
        public CopyVariableGroupApp(Arguments arguments)
        {
            _arguments = arguments;
            _remoteTfsApi = new RemoteTfsApiService(arguments.TfsUrl, arguments.AccessToken);
        }

        public async Task Start()
        {
            try
            {
                while(true)
                {
                    StartMenu(_arguments);
                    var project = await SelectProject(_arguments.Filter).ConfigureAwait(false);
                    var variableGroup = await SelectVariableGroup(project.Name).ConfigureAwait(false);
                    var newGroupName = GetNewGroupName();

                    Console.WriteLine(Constants.NEW_LINE);
                    Console.WriteLine($"Selected project: {project.Name}");
                    Console.WriteLine($"Selected variable group: {variableGroup.Name}");
                    Console.WriteLine($"New group name: {newGroupName}");
                    Console.WriteLine(Constants.NEW_LINE);

                    Console.WriteLine($"Are you sure you want to clone group {variableGroup.Name} into {newGroupName} (y/n)?");
                    var key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Y)
                        await _remoteTfsApi.CreateNewVariableGroup(project.Name, newGroupName, variableGroup).ConfigureAwait(false);
                }
            }
            catch (Exception)
            {
                throw;
            }

            // TODO: try again
        }

        private void StartMenu(Arguments arguments)
        {
            Console.WriteLine(Constants.NEW_LINE);
            Console.WriteLine($"TFS Instance: {arguments.TfsUrl}");

            if(!string.IsNullOrEmpty(arguments.Filter))
                Console.WriteLine($"Filter: {arguments.Filter}");

        }

        private async Task<Project> SelectProject(string filter)
        {
            List<Project> projects;
            if (!string.IsNullOrEmpty(filter))
                projects = await _remoteTfsApi.GetFilteredProjects(filter).ConfigureAwait(false);
            else
                projects = await _remoteTfsApi.GetProjects().ConfigureAwait(false);

            Console.WriteLine(Constants.NEW_LINE);

            int i = 0;
            projects.ForEach(x =>
            {
                Console.WriteLine($"{i}: {x.Name}");
                i++;
            });

            Console.WriteLine(Constants.NEW_LINE);

            Console.WriteLine("Which project do you want to select?");

            var input = Console.ReadLine();
            if (int.TryParse(input, out int projectNumber) && projectNumber <= projects.Count)
            {
                Console.WriteLine(Constants.NEW_LINE);
                Console.WriteLine($"Selected project: {projectNumber}: {projects[projectNumber].Name}");

                return projects[projectNumber];
            }
                

            throw new ArgumentException("Provided input is wrong");
        }

        private async Task<VariableGroup> SelectVariableGroup(string projectName)
        {
            var variableGroups = await _remoteTfsApi.GetVariableGroups(projectName).ConfigureAwait(false);

            Console.WriteLine(Constants.NEW_LINE);

            int j = 0;
            variableGroups.ForEach(x =>
            {
                Console.WriteLine($"{j}: {x.Name}");
                j++;
            });

            Console.WriteLine(Constants.NEW_LINE);
            Console.WriteLine("Which variable group do you want to close?");
            var inputGroup = Console.ReadLine();
            if (int.TryParse(inputGroup, out int groupNumber) && groupNumber <= variableGroups.Count && variableGroups[groupNumber] != null)
            {
                Console.WriteLine(Constants.NEW_LINE);
                Console.WriteLine($"Selected group: {groupNumber}: {variableGroups[groupNumber].Name}");
                return variableGroups[groupNumber];
            }
                

            throw new ArgumentException("Provided input is wrong");
        }

        private string GetNewGroupName()
        {
            Console.WriteLine(Constants.NEW_LINE);

            Console.WriteLine("What is the new group name?");
            var newName = Console.ReadLine();

            if (!string.IsNullOrEmpty(newName))
                return newName;

            throw new ArgumentException("Provided input is wrong");
        }
    }
}
