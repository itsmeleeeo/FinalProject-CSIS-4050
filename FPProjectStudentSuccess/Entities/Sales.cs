using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FPProjectStudentSuccess.Entities
{
    public partial class Sales
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal SalesTotal { get; set; }
        public int UserId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Users User { get; set; }
    }
}
