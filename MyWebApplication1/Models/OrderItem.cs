using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Singular_Systems_SelfKiosk_Software.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; } //Primary Key 

        [ForeignKey("OrderId")]
        public  int OrderId { get; set; } // Foreign Key into the OrderItem Table

        [ForeignKey("ProductId")]
        public int ProductId { get; set; } // Foreign key into the Order Item Table 

        public int OrderItemsQuantity { get; set; }

        public decimal OrderItemSubtotal { get; set; }

        public int Quantity { get; set; }

        public  Order Order { get; set; }   

        public Product Product { get; set; }


    }
}
