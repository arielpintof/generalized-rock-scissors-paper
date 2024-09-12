using itransition_task3.Validation;

namespace itransition_task3.CommandLine;

public class CommandLineParser : ICommandLineParser
{
    private readonly IValidator<CommandLineArgs> _validator;
    
    public CommandLineParser(IValidator<CommandLineArgs> validator)
    {
        _validator = validator;
    }
    
    public bool TryParseArguments(string[] args, out CommandLineArgs? commandLineArgs, out List<string> errors)
    {
        commandLineArgs = new CommandLineArgs { Moves = args.ToList() };
        var validationErrors = _validator.Validate(commandLineArgs).ToList();
        errors = validationErrors.Select(e => e.ErrorMessage).ToList();

        return validationErrors.Count == 0;
    }
}