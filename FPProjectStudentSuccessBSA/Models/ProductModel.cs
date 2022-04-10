using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FPProjectStudentSuccessBSA.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public int PlataformId { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public int ShelfId { get; set; }
        public int Quantity { get; set; }
        public ProductModel()
        {
        }
    }
}
