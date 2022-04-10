using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FPProjectStudentSuccess.Entities
{
    public partial class Shelf
    {
        public Shelf()
        {
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Color { get; set; }
        public int Capacity { get; set; }
        public int PlataformId { get; set; }

        public virtual Plataform Plataform { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
