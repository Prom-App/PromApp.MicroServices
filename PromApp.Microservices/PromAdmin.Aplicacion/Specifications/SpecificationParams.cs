namespace PromAdmin.Core.Specifications;

public abstract class SpecificationParams
{
    private const int MaxPageSize = 50;
    private int _pageSize = 3;
    public string? Sort { get; set; }
    public int PageIndex { get; set; } = 1;
    public string? Search { get; set; }

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
    }
}