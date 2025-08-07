namespace TDSolution.Services
{
    public interface IOrderItemService
    {
        string Filter();

        string Insert();

        string Detail(int id);
    }

    public class OrderItemService : IOrderItemService
    {
        public OrderItemService()
        { }

        public string Detail(int id)
        {
            throw new NotImplementedException();
        }

        public string Filter()
        {
            throw new NotImplementedException();
        }

        public string Insert()
        {
            throw new NotImplementedException();
        }
    }
}