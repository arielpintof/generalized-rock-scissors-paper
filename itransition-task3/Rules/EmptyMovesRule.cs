using itransition_task3.CommandLine;
using itransition_task3.Validation;

namespace itransition_task3.Rules;

public class EmptyMovesRule : IValidationRule
{
    public ValidationError? Validate(CommandLineArgs args)
    {
        return args.Moves.Count == 0 ? new EmptyMovesError() : null;
    }
}