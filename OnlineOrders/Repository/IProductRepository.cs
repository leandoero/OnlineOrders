﻿using OnlineOrders.Models.Domain;

namespace OnlineOrders.Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync(string? filterOn, string? filterQuery, string? sortBy, bool isAscending,
            int pageNumber, int pageSize);
        Task<Product?> GetByIdAsync(Guid id);
        Task<Product> AddAsync(Product product);
        Task<Product?> UpdateAsync(Guid id, Product product);
        Task<Product?> DeleteAsync(Guid id);

    }
}