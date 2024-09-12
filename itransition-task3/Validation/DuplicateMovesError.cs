namespace itransition_task3.Validation;

public class DuplicateMovesError : ValidationError
{
    public override string ErrorMessage => "There must be no duplicate movements.";
}