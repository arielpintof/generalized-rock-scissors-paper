using itransition_task3.CommandLine;
using itransition_task3.Validation;

namespace itransition_task3.Rules;

public class DuplicateMovesRule : IValidationRule
{
    public ValidationError? Validate(CommandLineArgs args)
    {
        return args.Moves.GroupBy(s => s).Any(g => g.Count() > 1) ? new DuplicateMovesError() : null;
    }
}