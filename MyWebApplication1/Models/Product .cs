using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SingularSystems_SelfKiosk_Software.Models;

namespace Singular_Systems_SelfKiosk_Software.Models
{
    public class Product
{
       

        [Key] 
        public int ProductId { get; set; } // Primary Key 

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; } // Foreign Key into the Product Table 
     
        public  int SupplierId { get; set; } // Foreign Key into the Product Table 

        [ForeignKey ("OrderItemId")]
        public int OrderItemId { get; set; } // Foreign Key into the Product Table 

        public string Name { get; set; }

        public string Description { get; set; }
        
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public bool IsAvailable { get; set; }

        public DateTime LastUpdated { get; set; }

       public string Image { get; set; }



        // Navigation property
        public Category Category { get; set; }

        public Supplier Supplier { get; set; }

        // Navigation property    

        public ICollection<OrderItem> OrderItems { get; set; }    

        
        
        

    }
}
