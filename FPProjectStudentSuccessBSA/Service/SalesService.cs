using FPProjectStudentSuccess.Entities;
using FPProjectStudentSuccessBSA.Data;
using FPProjectStudentSuccessBSA.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FPProjectStudentSuccessBSA.Service
{
    public class SalesService
    {
        public static SQLConnectionConfig _conn;
        public SqlConnection connection;
        public SalesService(SQLConnectionConfig conn)
        {
            _conn = conn;
            connection = new SqlConnection(_conn.Value);
        }
        public async Task<List<Sales>> GetSalesAsync()
        {
            using (var ctx = new FPProjectStudentSuccessDBContext())
            {
                var result = ctx.Sales;
                return await Task.FromResult(result.ToList());
            }
        }
        public async Task<Sales> InsertSaleAsync(string name, string plataform, int quantity, decimal salestotal, string email)
        {
            Sales sale = new Sales();

            using (var ctx = new FPProjectStudentSuccessDBContext())
            {               
                var getPlataform = ctx.Plataform.Where(x => x.Name == plataform).First();
                var getProduct = ctx.Product.Where(x => x.Name == name && x.PlataformId == getPlataform.Id).First();
                var getUser = ctx.Users.Where(x => x.Email == email).First();

                int newQuantity = getProduct.Quantity - quantity;
                getProduct.Quantity = newQuantity;
                ctx.Product.Update(getProduct);

                sale.ProductId = getProduct.Id;
                sale.ProductName = name;
                sale.Quantity = quantity;
                sale.SalesTotal = salestotal;
                sale.UserId = getUser.Id;

                ctx.Sales.Add(sale);

                await ctx.SaveChangesAsync();
            }
            return sale;
        }
    }
}
