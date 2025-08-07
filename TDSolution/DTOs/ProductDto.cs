namespace TDSolution.DTOs
{
    public class ProductDto
    {
        public int ProductID { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
    }

    public class ProductFilterDto : FilterDto
    {
        public int? ProductID { get; set; }
        public string? Name { get; set; }
        public double? Price { get; set; }
    }
}