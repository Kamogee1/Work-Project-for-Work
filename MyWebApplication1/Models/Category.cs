using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Singular_Systems_SelfKiosk_Software.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; } //Primary Key

        public string CategoryName { get; set; }

        

        public required ICollection<Product> Products
        {
            get; set;

        }
    }
}
