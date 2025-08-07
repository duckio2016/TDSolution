using AutoMapper;
using TDSolution.DTOs;
using TDSolution.Models;
using TDSolution.Repositories;

namespace TDSolution.Services
{
    public interface IOrderService
    {
        PaginationDto<OrderDto> Filter(OrderFilterDto filterDto);

        int Create(OrderCreateDto orderCreateDto);

        OrderDetailDto Detail(int id);
    }

    public class OrderService : BaseService, IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderItemRepository _itemRepository;

        public OrderService(IMapper mapper,
            ICustomerRepository customerRepository,
            IOrderRepository repository,
            IProductRepository productRepository,
            IOrderItemRepository itemRepository) : base(mapper)
        {
            _repository = repository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _itemRepository = itemRepository;
        }

        public int Create(OrderCreateDto orderCreateDto)
        {
            if (!orderCreateDto.Items.Any())
                throw new InvalidDataException("Please, enter at least one [Product].");

            ///Check valid products, customer
            var customer = _customerRepository.Find(orderCreateDto.CustomerID);
            if (customer == null)
                throw new KeyNotFoundException($"Not found customer with CustomerID: '{orderCreateDto.CustomerID}'");

            var productIDs = orderCreateDto.Items.Select(q => q.ProductID).Distinct().AsQueryable();
            var products = _productRepository.GetAllByProductIDs(productIDs);


            var itemGroupByProductIDs = orderCreateDto.Items.GroupBy(q => q.ProductID);
            if (itemGroupByProductIDs.Any())
            {
                ///Verify & map to OrderItem
                var order = _mapper.Map(orderCreateDto, new Order());
                _repository.Create(order);

                var orderItems = itemGroupByProductIDs
                    .Where(q => products.Any(prd => prd.ProductID == q.Key))
                    .Select(q =>
                    {
                        var product = products.First(prd => prd.ProductID == q.Key);
                        var quantity = q.Sum(item => item.Quantity);
                        
                        return new OrderItem
                        {
                            Quantity = quantity,
                            UnitPrice = product.Price,
                            OrderID = order.OrderID,
                            ProductID = q.Key,
                        };
                    })
                    .ToList();
                _itemRepository.Creates(orderItems);

                order.TotalAmount = orderItems.Sum(item => item.Quantity * item.UnitPrice);
                _repository.Update(order);

                return order.OrderID;
            }
            throw new InvalidDataException("Input data invalid on system!");

        }

        public PaginationDto<OrderDto> Filter(OrderFilterDto filterDto)
        {
            var orders = _repository.GetAll();

            if (filterDto.OrderDate.HasValue)
                orders = orders.Where(q => q.OrderDate.Date == filterDto.OrderDate.Value.Date).ToList();

            if (filterDto.CustomerID > 0)
                orders = orders.Where(q => q.CustomerID.Equals(filterDto.CustomerID.Value)).ToList();

            var query = _mapper.Map(orders, new List<OrderDto>()).AsQueryable();

            return GetPagedResult(query, filterDto.Page, filterDto.PageSize);
        }

        public OrderDetailDto Detail(int id)
        {
            var order = _repository.Find(id);
            if (order == null)
                throw new KeyNotFoundException($"Not found Order with OrderID: '{id}'");

            return _mapper.Map(order, new OrderDetailDto());
        }
    }
}