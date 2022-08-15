using CommandLine;

namespace Import
{
    public class CommandLineOptions
    {
       
        [Value(index: 0, Required = true, HelpText = "File Name")]
        public string FileName { get; set; }

        [Value(index: 1, Required = true, HelpText = "File Name")]
        public string Path { get; set; }
    }
}
