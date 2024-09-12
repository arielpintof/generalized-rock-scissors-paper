namespace itransition_task3.Validator;

public class EmptyMovesError : ValidationError
{
    public override string ErrorMessage => "No moves provided";
}