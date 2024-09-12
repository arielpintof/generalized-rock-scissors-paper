using itransition_task3.CommandLine;
using itransition_task3.Rules;

namespace itransition_task3;

public static class GameFactory
{
    public static Game CreateGame(string[] args)
    {
        var validationRules = new List<IValidationRule>
        {
            new EmptyMovesRule(),
            new InsufficientMovesRule(),
            new EvenMovesCountRule(),
            new DuplicateMovesRule()
        };

        var validator = new CommandLineArgsValidator(validationRules);
        var commandLineParser = new CommandLineParser(validator);

        if (commandLineParser.TryParseArguments(args, out var commandLineArgs, out var errors))
            if (commandLineArgs != null)
                return new Game(commandLineArgs.Moves);

        foreach (var error in errors)
        {
            Console.WriteLine($"Invalid command line arguments: {error}");
        }
        
        throw new ArgumentException("");

    }
}