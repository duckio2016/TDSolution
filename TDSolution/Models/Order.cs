using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TDSolution.Models
{
    public class Order
    {
        public Order()
        {
            OrderDate = DateTime.Now;
            TotalAmount = 0.0;
            CustomerID = 0;

            Items= new List<OrderItem>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }

        public DateTime OrderDate { get; set; }
        public double TotalAmount { get; set; }

        [Required]
        public int CustomerID { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<OrderItem> Items { get; set; }
    }
}