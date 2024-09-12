namespace itransition_task3.Validator;

public interface IValidator<in T>
{
    IEnumerable<ValidationError> Validate(T obj);
}