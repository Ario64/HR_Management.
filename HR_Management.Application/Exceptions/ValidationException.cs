using FluentValidation.Results;

namespace HR_Management.Application.Exceptions;

public class ValidationException : ApplicationException
{
    public List<string> Exceptions { get; set; } = new();

    public ValidationException(ValidationResult result)
    {
        foreach (var error in result.Errors)
        {
            Exceptions.Add(error.ErrorMessage);
        }
    }
}
