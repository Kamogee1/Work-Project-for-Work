﻿using System.ComponentModel.DataAnnotations;
using Singular_Systems_SelfKiosk_Software.Models;

namespace SingularSystems_SelfKiosk_Software.Models
{
    public class Supplier
    {
       

        [Key]
        public int SupplierId  { get; set; } //Primary Key

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}
