using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TDSolution.Models
{
    public class Product
    {
        public Product()
        {
            Name = string.Empty;
            Price = 0.0;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }

        public string Name { get; set; }
        public double Price { get; set; }
    }
}