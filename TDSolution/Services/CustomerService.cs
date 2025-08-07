using AutoMapper;
using TDSolution.DTOs;
using TDSolution.Models;
using TDSolution.Repositories;

namespace TDSolution.Services
{
    public interface ICustomerService
    {
        PaginationDto<CustomerDetailDto> Filter(FilterDto filterDto);

        int Create(CustomerDto customerDto);

        bool Update(int id, CustomerDto customerDto);

        bool Remove(int id);
    }

    public class CustomerService : BaseService, ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(IMapper mapper, ICustomerRepository repository) : base(mapper)
        {
            _repository = repository;
        }

        public PaginationDto<CustomerDetailDto> Filter(FilterDto filterDto)
        {
            var customers = _repository.Filter();

            var query = _mapper.Map(customers, new List<CustomerDetailDto>()).AsQueryable();
            return GetPagedResult(query, filterDto.Page, filterDto.PageSize);
        }

        public int Create(CustomerDto customerDto)
        {
            // with need check exist customer with property??
            var customer = _mapper.Map(customerDto, new Customer());

            //repo add customer
            _repository.Create(customer);

            return customer.CustomerID;
        }

        public bool Update(int id, CustomerDto customerDto)
        {
            // get customer by id
            var customer = _repository.Find(id);

            // check exist
            if (customer == null)
                throw new KeyNotFoundException($"Not found customer with CustomerID: '{id}'");

            //update profile customer
            _mapper.Map(customerDto, customer);
            _repository.Update(customer);

            return true;
        }

        public bool Remove(int id)
        {
            //remove from repo
            _repository.Delete(id);
            return true;
        }
    }
}