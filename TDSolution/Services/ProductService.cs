using AutoMapper;
using TDSolution.DTOs;
using TDSolution.Repositories;

namespace TDSolution.Services
{
    public interface IProductService
    {
        PaginationDto<ProductDto> Filter(ProductFilterDto filterDto);
    }

    public class ProductService : BaseService, IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IMapper mapper, IProductRepository repository) : base(mapper)
        {
            _repository = repository;
        }

        public PaginationDto<ProductDto> Filter(ProductFilterDto filterDto)
        {
            var products = _repository.GetAll();

            if (filterDto.ProductID.HasValue)
                products = products.Where(q => q.ProductID == filterDto.ProductID.Value).ToList();

            if (!string.IsNullOrWhiteSpace(filterDto.Name))
                products = products.Where(q => q.Name.Contains(filterDto.Name)).ToList();

            if (filterDto.Price > 0)
                products = products.Where(q => q.Price.Equals(filterDto.Price.Value)).ToList();

            var query = _mapper.Map(products, new List<ProductDto>()).AsQueryable();

            return GetPagedResult(query, filterDto.Page, filterDto.PageSize);
        }
    }
}