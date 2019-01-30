using CommandLine;

namespace CloneTfsVariableGroup.Models
{
    public class Arguments
    {
        [Option('u', "TfsUrl", Required = true, HelpText = "Provide the url to your TFS instance" )]
        public string TfsUrl { get; set; }

        [Option('t', "Token", Required = true, HelpText = "Provide a personal access token to access TFS")]
        public string AccessToken { get; set; }

        [Option('f', "Filter", Required = false, HelpText = "Limit results by filtering the list of projects")]
        public string Filter { get; set; }
    }
}
