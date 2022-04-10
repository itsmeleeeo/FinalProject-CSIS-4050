using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FPProjectStudentSuccess.Entities
{
    public partial class Plataform
    {
        public Plataform()
        {
            Product = new HashSet<Product>();
            Shelf = new HashSet<Shelf>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Product> Product { get; set; }
        public virtual ICollection<Shelf> Shelf { get; set; }
    }
}
