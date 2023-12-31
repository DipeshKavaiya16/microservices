﻿using Dapper;
using Discount.DataAccess.Entities;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Discount.DataAccess.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly NpgsqlConnection _connection;

        public DiscountRepository(IConfiguration configuration)
        {
            _connection = new NpgsqlConnection(configuration["ConnectionStrings:DefaultConnection"]);
        }

        public async Task<Coupon> GetDiscount(string productName)
        {
            var coupon = await _connection.QueryFirstOrDefaultAsync<Coupon>("SELECT * FROM Coupon WHERE ProductName = @ProductName", new { ProductName = productName });

            if (coupon == null)
                return new Coupon { ProductName = "No Discount", Amount = 0 , Description = "No Description" };

            return coupon;
        }

        public async Task<bool> CreateDiscount(Coupon coupon)
        {
            var flag = await _connection.ExecuteAsync("INSERT INTO Coupon (ProductName, Description, Amount) VALUES (@ProductName, @Description, @Amount)", new { ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount });

            if (flag == 0)
                return false;

            return true;
        }

        public async Task<bool> UpdateDiscount(Coupon coupon)
        {
            var flag = await _connection.ExecuteAsync("UPDATE Coupon SET ProductName = @ProductName, Description = @Description, Amount = @Amount WHERE Id = @Id", new { ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount, Id = coupon.Id });

            if (flag == 0)
                return false;

            return true;
        }

        public async Task<bool> DeleteDiscount(string productName)
        {
            var flag = await _connection.ExecuteAsync("DELETE FROM Coupon WHERE ProductName = @ProductName", new { ProductName = productName });

            if (flag == 0)
                return false;

            return true;
        }
    }
}
