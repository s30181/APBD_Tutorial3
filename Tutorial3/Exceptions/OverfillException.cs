namespace Tutorial3;

public class OverfillException : Exception
{
    public OverfillException() : base("Overflow") { 
    }
}