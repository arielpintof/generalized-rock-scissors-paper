namespace itransition_task3.Validation;

public interface IValidator<in T>
{
    IEnumerable<ValidationError> Validate(T obj);
}