using itransition_task3.CommandLine;
using itransition_task3.Validation;

namespace itransition_task3.Rules;

public class EvenMovesCountRule : IValidationRule
{
    public ValidationError? Validate(CommandLineArgs args) =>
        args.Moves.Count % 2 == 0 ? new EvenMovesCountError() : null;
}