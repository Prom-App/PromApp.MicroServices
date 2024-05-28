using FluentValidation.Results;

namespace PromAdmin.Core.Modelos;

public class BaseApiResponse<T>
{
    public bool IsSuccess { get; set; }
    public T? Data { get; set; }
    public string? Message { get; set; }
    public IEnumerable<ValidationFailure>? Errors { get; set; }
}