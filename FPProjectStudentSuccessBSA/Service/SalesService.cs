using FPProjectStudentSuccess.Entities;
using FPProjectStudentSuccessBSA.Data;
using FPProjectStudentSuccessBSA.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<Sales> InsertSaleAsync(Sales sale)
        {
            using (var ctx = new FPProjectStudentSuccessDBContext())
            {
                ctx.Sales.Add(sale);
                await ctx.SaveChangesAsync();
            }
            return sale;
            //TODO: update Product Amount after Sale (baixa de estoque)
        }
    }
}
