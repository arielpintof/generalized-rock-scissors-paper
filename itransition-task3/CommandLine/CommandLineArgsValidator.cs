using itransition_task3.Rules;
using itransition_task3.Validation;

namespace itransition_task3.CommandLine;

public class CommandLineArgsValidator : IValidator<CommandLineArgs>
{
    private readonly IEnumerable<IValidationRule> _rules;

    public CommandLineArgsValidator(IEnumerable<IValidationRule> rules)
    {
        _rules = rules;
    }

    public IEnumerable<ValidationError> Validate(CommandLineArgs args)
    {
        return _rules.Select(rule => rule.Validate(args)).Where(error => error != null)
            .Cast<ValidationError>();
    }
}