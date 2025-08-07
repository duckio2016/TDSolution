using AutoMapper;
using TDSolution.DTOs;

namespace TDSolution.Services
{
    public abstract class BaseService
    {
        protected readonly IMapper _mapper;
        public BaseService(IMapper mapper)
        {
            _mapper = mapper;
        }

        protected PaginationDto<T> GetPagedResult<T>(
            IQueryable<T> query,
            int page,
            int pageSize)
        {
            var totalItems = query.Count();
            var items = query.Skip((page - 1) * pageSize)
                                   .Take(pageSize)
                                   .ToList();

            return new PaginationDto<T>
            {
                Items = items,
                TotalItems = totalItems,
                Page = page,
                PageSize = pageSize
            };
        }
    }
}