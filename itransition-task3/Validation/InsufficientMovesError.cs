namespace itransition_task3.Validation;

public class InsufficientMovesError : ValidationError
{
    public override string ErrorMessage => "There must be at least three movements.";
}