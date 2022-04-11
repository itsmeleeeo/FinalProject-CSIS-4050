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
        public async Task<Product> InsertProductAsync(string name, string publisher, string plataform, int quantity, int year, decimal price)
        {
            Product newProduct = new Product();

            using (var ctx = new FPProjectStudentSuccessDBContext())
            {
                var getPlataform = ctx.Plataform.Where(x => x.Name == plataform).First();
                var getShelf = ctx.Shelf.Where(x => x.PlataformId == getPlataform.Id).First();
                var checkProduct = ctx.Product.Where(x => x.Name == name && x.PlataformId == getPlataform.Id).FirstOrDefault();

                newProduct.Name = name;
                newProduct.Publisher = publisher;
                newProduct.PlataformId = getPlataform.Id;
                newProduct.Quantity = quantity;
                newProduct.Year = year;
                newProduct.Price = price;
                newProduct.ShelfId = getShelf.Id;

                if (checkProduct == null)
                {
                    ctx.Product.Add(newProduct);
                } else
                {
                    int newQuantity = checkProduct.Quantity + quantity;
                    checkProduct.Quantity = newQuantity;
                    ctx.Product.Update(checkProduct);
                }
                await ctx.SaveChangesAsync();
            }
            return newProduct;
        }        
    }
}
