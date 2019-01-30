using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloneTfsVariableGroup.Models
{
    public class Projects
    {
        [JsonProperty(PropertyName = "value")]
        public List<Project> ProjectItems { get; set; }
    }

    public class Project
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
    }
}
