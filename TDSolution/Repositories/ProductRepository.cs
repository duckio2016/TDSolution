using Microsoft.EntityFrameworkCore;
using TDSolution.Models;

namespace TDSolution.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAll();

        List<Product> GetAllByProductIDs(IQueryable<int> ids);

        Product? Find(int id);

        void Create(Product product);

        void Update(Product product);

        void Delete(int id);
    }

    public class ProductRepository : IProductRepository
    {
        private readonly IRepository<Product> _repository;

        public ProductRepository(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public List<Product> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public List<Product> GetAllByProductIDs(IQueryable<int> ids)
        {
            return _repository.Query().Where(q => ids.Contains(q.ProductID)).AsNoTracking().ToList();

        }


        public Product? Find(int id)
        {
            return _repository.Find(id);
        }

        public void Create(Product product)
        {
            _repository.Add(product);
            _repository.Save();
        }

        public void Update(Product product)
        {
            _repository.Update(product);
            _repository.Save();
        }

        public void Delete(int id)
        {
            var product = _repository.Find(id);
            if (product != null)
            {
                _repository.Remove(product);
                _repository.Save();
            }
        }
    }
}