using TDSolution.DTOs;
using TDSolution.Models;

namespace TDSolution.Repositories
{
    public interface ICustomerRepository
    {
        List<Customer> Filter();

        Customer? Find(int id);

        void Create(Customer customer);

        void Update(Customer customer);

        void Delete(int id);
    }

    public class CustomerRepository : ICustomerRepository
    {
        private readonly IRepository<Customer> _repository;

        public CustomerRepository(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        public List<Customer> Filter()
        {
            return _repository.GetAll().ToList();
        }

        public Customer? Find(int id)
        {
            return _repository.Find(id);
        }

        public void Create(Customer customer)
        {
            _repository.Add(customer);
            _repository.Save();
        }

        public void Update(Customer customer)
        {
            _repository.Update(customer);
            _repository.Save();
        }

        public void Delete(int id)
        {
            var customer = _repository.Find(id);
            if (customer != null)
            {
                _repository.Remove(customer);
                _repository.Save();
            }
        }
    }
}