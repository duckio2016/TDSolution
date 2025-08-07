namespace TDSolution.DTOs
{
    #region Pagination

    public class FilterDto
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

        public FilterDto()
        {
            Page = 1;
            PageSize = 10;
        }
    }

    public class PaginationDto<T>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

        public int TotalItems { get; set; }
        public IEnumerable<T> Items { get; set; }

        public PaginationDto()
        {
            Page = 1;
            PageSize = 10;
            TotalItems = 0;
            Items = Enumerable.Empty<T>();
        }
    }

    #endregion Pagination

    public class ResultDto
    {
        public ResultDto()
        {
            IsSuccess = false;
            Data = null;
            Message = null;
        }

        public bool IsSuccess { get; set; }
        public object? Data { get; set; }
        public string? Message { get; set; }
    }
}