namespace TDSolution.DTOs
{
    public class OrderDto
    {
        public int OrderID { get; set; }

        public DateTime OrderDate { get; set; }
        public double TotalAmount { get; set; }
        public int CustomerID { get; set; }
    }

    public class OrderDetailDto
    {
        public int OrderID { get; set; }

        public DateTime OrderDate { get; set; }
        public double TotalAmount { get; set; }

        public int CustomerID { get; set; }
        public List<OrderItemDto> Items { get; set; } = new List<OrderItemDto>();
    }

    public class OrderCreateDto
    {
        public int CustomerID { get; set; }
        public List<OrderItemCreateDto> Items { get; set; } = new List<OrderItemCreateDto>();
    }

    public class OrderFilterDto : FilterDto
    {
        public DateTime? OrderDate { get; set; }
        public int? CustomerID { get; set; }
    }
}