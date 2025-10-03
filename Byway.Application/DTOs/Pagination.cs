namespace Byway.Application.DTOs
{
    public record Pagination<T>(int PageIndex, int PageSize, int Count, IEnumerable<T> Data);
}
