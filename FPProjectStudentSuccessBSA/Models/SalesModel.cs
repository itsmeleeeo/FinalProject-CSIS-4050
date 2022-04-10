using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FPProjectStudentSuccessBSA.Models
{
    public class SalesModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal SalesTotal { get; set; }
        public int UserId { get; set; }
    }
}
