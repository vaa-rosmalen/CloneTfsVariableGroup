using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace CloneTfsVariableGroup.Models
{
    public class VariableGroups
    {
        [JsonProperty(PropertyName = "value")]
        public List<VariableGroup> VariableGroupItems { get; set; }
    }
    public class VariableGroup
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "variables")]
        public JObject Variables { get; set; }

        public string type = "Vsts";

        public string description = "Created with CloneTfsVariableGroup";
    }
}
