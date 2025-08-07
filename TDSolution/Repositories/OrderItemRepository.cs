using TDSolution.Models;

namespace TDSolution.Repositories
{
    public interface IOrderItemRepository
    {
        List<OrderItem> GetAll();

        OrderItem? Find(int id);

        void Create(OrderItem orderItem);

        void Creates(List<OrderItem> orderItems);

        void Update(OrderItem product);

        void Delete(int id);
    }

    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly IRepository<OrderItem> _repository;

        public OrderItemRepository(IRepository<OrderItem> repository)
        {
            _repository = repository;
        }

        public List<OrderItem> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public OrderItem? Find(int id)
        {
            return _repository.Find(id);
        }

        public void Create(OrderItem orderItem)
        {
            _repository.Add(orderItem);
            _repository.Save();
        }

        public void Creates(List<OrderItem> orderItems)
        {
            _repository.AddRange(orderItems);
            _repository.Save();
        }

        public void Update(OrderItem orderItem)
        {
            _repository.Update(orderItem);
            _repository.Save();
        }

        public void Delete(int id)
        {
            var orderItem = _repository.Find(id);
            if (orderItem != null)
            {
                _repository.Remove(orderItem);
                _repository.Save();
            }
        }
    }
}