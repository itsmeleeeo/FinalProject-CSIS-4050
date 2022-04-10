using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FPProjectStudentSuccess.Entities
{
    public partial class Product
    {
        public Product()
        {
            Sales = new HashSet<Sales>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public int PlataformId { get; set; }
        public int Quantity { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public int ShelfId { get; set; }

        public virtual Plataform Plataform { get; set; }
        public virtual Shelf Shelf { get; set; }
        public virtual ICollection<Sales> Sales { get; set; }
    }
}
