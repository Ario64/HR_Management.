namespace HR_Management.Application.Exceptions;

public class ListNullException : ApplicationException
{
    public ListNullException() : base("List was null !")
    {
    }
}
