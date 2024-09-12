namespace itransition_task3.CommandLine;

public interface ICommandLineParser
{
    bool TryParseArguments(string[] args, out CommandLineArgs? commandLineArgs, out List<string> errors);
}