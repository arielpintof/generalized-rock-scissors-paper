using itransition_task3.CommandLine;
using itransition_task3.Validation;

namespace itransition_task3.Rules;

public interface IValidationRule
{
    ValidationError? Validate(CommandLineArgs args);
}