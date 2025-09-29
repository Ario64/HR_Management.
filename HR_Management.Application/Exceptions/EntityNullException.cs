namespace HR_Management.Application.Exceptions;

public class EntityNullException : Exception
{
    public EntityNullException() : base("Entity was null !")
    {
    }
}
