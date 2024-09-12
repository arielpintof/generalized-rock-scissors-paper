namespace itransition_task3.Validation;

public class EmptyMovesError : ValidationError
{
    public override string ErrorMessage => "No moves provided";
}