using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Singular_Systems_SelfKiosk_Software.Models
{
    public class UserRole
{
       [Key]
        public int RoleId { get; set; } // Primary Key 

        public string RoleName { get; set; }

        [ForeignKey ("UserId")]
        public int UserId { get; set; }

        public  required User User { get; set; } // Navigation property


        

        
    }
}

