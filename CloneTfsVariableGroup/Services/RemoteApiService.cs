using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CloneTfsVariableGroup.Handlers;
using CloneTfsVariableGroup.Interfaces;
using CloneTfsVariableGroup.Models;

namespace CloneTfsVariableGroup.Services
{
    public class RemoteTfsApiService
    {
        private readonly ITfsApiDefinition _remoteApi;

        public RemoteTfsApiService(string baseAddress, string token) =>
            _remoteApi = CreateRestApi(baseAddress, token);

        public async Task<List<Project>> GetProjects()
        {
            var projects = await _remoteApi.GetProjects().ConfigureAwait(false);
            if (projects != null && projects.ProjectItems.Any())
                return projects.ProjectItems.ToList();

            return null;
        }

        public async Task<List<Project>> GetFilteredProjects(string filter)
        {
            var projects = await GetProjects().ConfigureAwait(false);
            if (projects != null)
                return projects.Where(x => x.Name.ToLower().Contains(filter.ToLower())).ToList();

            return null;
        }

        public async Task<List<VariableGroup>> GetVariableGroups(string projectName)
        {
            var variableGroups = await _remoteApi.GetVariableGroups(projectName).ConfigureAwait(false);
            if (variableGroups != null && variableGroups.VariableGroupItems.Any())
                return variableGroups.VariableGroupItems;

            return null;
        }

        public async Task CreateNewVariableGroup(string projectName, string newGroupName, VariableGroup variableGroup)
        {
            variableGroup.Name = newGroupName;
            await _remoteApi.CreateNewVariableGroup(projectName, variableGroup).ConfigureAwait(false);
        }
            

        private ITfsApiDefinition CreateRestApi(string baseAddress, string token)
        {
            var httpClient = new HttpClient(new AuthenticatedHttpClientHandler(token));
            httpClient.BaseAddress = new Uri(baseAddress);
            return RestService.For<ITfsApiDefinition>(httpClient);
        }
    }
}
