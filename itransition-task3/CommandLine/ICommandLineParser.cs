namespace itransition_task3.CommandLine;

public interface ICommandLineArgument
{
    bool TryParseArguments(string[] args, out CommandLineArgs? commandLineArgs, out List<string> errors);
}