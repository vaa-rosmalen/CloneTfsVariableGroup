using CloneTfsVariableGroup.Models;
using Refit;
using System.Threading.Tasks;

namespace CloneTfsVariableGroup.Interfaces
{
    [Headers("Authorization: Basic")]
    public interface ITfsApiDefinition
    {
        [Get("/_apis/projects?api-version=4.1-preview.1")]
        Task<Projects> GetProjects();

        [Get("/{projectName}/_apis/distributedtask/variablegroups?api-version=4.1-preview.1")]
        Task<VariableGroups> GetVariableGroups(string projectName);

        [Post("/{projectName}/_apis/distributedtask/variablegroups?api-version=4.1-preview.1")]
        Task CreateNewVariableGroup(string projectName, [Body]VariableGroup variableGroup);
    }
}
