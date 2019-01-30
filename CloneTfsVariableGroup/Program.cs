using CommandLine;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CloneTfsVariableGroup.Models;

namespace CloneTfsVariableGroup
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var arguments = ParseArguments(args);

                await new CopyVariableGroupApp(arguments)
                    .Start()
                    .ConfigureAwait(false);
            }
            catch (Exception)
            {

            }
        }

        private static Arguments ParseArguments(string[] args) =>
            Parser.Default
                .ParseArguments<Arguments>(args)
                .MapResult((parsedArguments) =>
                {
                    return new Arguments
                    {
                        AccessToken = parsedArguments.AccessToken,
                        Filter = parsedArguments.Filter,
                        TfsUrl = parsedArguments.TfsUrl
                    };
                }, (errors) => null);
    }
}
