using FluentValidation.Results;

namespace PromAdmin.Core.Exceptions;

public class ValidationException : ApplicationException
{
    public IDictionary<string, string[]> Errors;

    public ValidationException() : base("Errores de validación")
    {
        Errors = new Dictionary<string, string[]>();
    }

    public ValidationException(IEnumerable<ValidationFailure> failures) : this()
    {
        Errors = failures.GroupBy(x => x.PropertyName, x => x.ErrorMessage).ToDictionary(y => y.Key, y => y.ToArray());
    }
}