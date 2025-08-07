namespace TDSolution.DTOs
{
    public class OrderItemDto
    {
        public int OrderItemID { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }


        public string ProductName { get; set; } = string.Empty;
        public int ProductID { get; set; }
    }

    public class OrderItemCreateDto
    {
        public int Quantity { get; set; }

        public int ProductID { get; set; }
    }
}