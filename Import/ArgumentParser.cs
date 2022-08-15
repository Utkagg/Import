using CommandLine;

namespace Import
{
    public class ArgumentParser
    {
        private IFileOperations fileOperations;
        public void ParseArguments(string[] args)
        {
            Parser parser = new Parser(with => with.HelpWriter = null);

            ParserResult<CommandLineOptions> results = parser.ParseArguments<CommandLineOptions>(args);
            results.WithParsed(FileFormat);

        }

        public void FileFormat(CommandLineOptions options)
        {
            var path = options.Path;
            switch (path?.Split('.')[1])
            {
                case "yaml":
                    fileOperations = new YamlFileOperations();
                    break;
                case "json":
                    fileOperations = new JsonFileOperations();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(path), path, null);
            }
            ActualOperation(path);
        }

        public void ActualOperation(string path)
        {
            var products = fileOperations.Read(path);
            foreach(var p in products)
            {
                Console.WriteLine($"importing: Name: {p.Name}; Categories: {p.Categories}; Twitter: {p.Twitter}");
            }
        }
    }
}
