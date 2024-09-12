namespace itransition_task3.Validation;

public class EvenMovesCountError : ValidationError
{
    public override string ErrorMessage => "The total number of moves must be odd.";
}