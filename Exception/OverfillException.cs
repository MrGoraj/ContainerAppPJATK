namespace ConsoleApp2.Exception;

public class OverfillException : System.Exception
{
    public OverfillException(string message) : base(message)
    {
    }
}