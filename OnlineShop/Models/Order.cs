using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Models
{
    public class Order
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string CustomerName { get; set; } = "مشتری مهمان";

        [MaxLength(20)]
        public string CustomerPhone { get; set; } = "-";

        [Column(TypeName = "decimal(18,0)")]
        public decimal TotalAmount { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public string Status { get; set; } = "ثبت شده";

        public List<OrderItem> OrderItems { get; set; } = new();
    }

}