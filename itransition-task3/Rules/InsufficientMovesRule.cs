using itransition_task3.CommandLine;
using itransition_task3.Validation;

namespace itransition_task3.Rules;

public class InsufficientMovesRule : IValidationRule
{
    public ValidationError? Validate(CommandLineArgs args)
    {
        return args.Moves.Count < 3 ? new InsufficientMovesError() : null;
    }
}