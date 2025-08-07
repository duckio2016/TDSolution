using TDSolution.Models;

namespace TDSolution.Repositories
{
    public interface IOrderRepository
    {
        List<Order> GetAll();

        Order? Find(int id);

        void Create(Order order);

        void Update(Order order);

        void Delete(int id);
    }

    public class OrderRepository : IOrderRepository
    {
        private readonly IRepository<Order> _repository;

        public OrderRepository(IRepository<Order> repository)
        {
            _repository = repository;
        }

        public List<Order> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public Order? Find(int id)
        {
            return _repository.Find(id);
        }

        public void Create(Order order)
        {
            _repository.Add(order);
            _repository.Save();
        }

        public void Update(Order order)
        {
            _repository.Update(order);
            _repository.Save();
        }

        public void Delete(int id)
        {
            var order = _repository.Find(id);
            if (order != null)
            {
                _repository.Remove(order);
                _repository.Save();
            }
        }
    }
}