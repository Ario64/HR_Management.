namespace HR_Management.Application.Exceptions;

public class NotFoundException : ApplicationException
{
    public NotFoundException(string name, object key) : base($"name: [{name}] with key: [{key}] was not found !")
    {

    }
}
