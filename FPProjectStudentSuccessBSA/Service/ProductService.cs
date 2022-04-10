using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using FPProjectStudentSuccessBSA.Data;
using FPProjectStudentSuccessBSA.Models;
using System.Data;
using System.Text;
using FPProjectStudentSuccess.Entities;

namespace FPProjectStudentSuccessBSA.Service
{
    public class ProductService
    {
        public static SQLConnectionConfig _conn;
        public SqlConnection connection;
        public ProductService(SQLConnectionConfig conn)
        {
            _conn = conn;
            connection = new SqlConnection(_conn.Value);
        }
        public async Task<List<Product>> GetProductsAsync()
        {            
            using (var ctx = new FPProjectStudentSuccessDBContext())
            {
                var result = ctx.Product;
                return await Task.FromResult(result.ToList());
            }
        }
        public async Task<Product> InsertProductAsync(Product product)
        {
            using (var ctx = new FPProjectStudentSuccessDBContext())
            {
                ctx.Product.Add(product);
                await ctx.SaveChangesAsync();
            }
            return product;
        }        
    }
}
