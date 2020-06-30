using CommandLine;

namespace ABNtoYNAB
{
    internal class CLIOptions
    {
        [Option('f', "file", Required = true, HelpText = "Inform the path (full or relative) to the source file.")]
        public string FilePath { get; set; }
    }
}
