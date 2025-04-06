
using Microsoft.AspNetCore.Mvc;
using OnlineOrders.Models.Domain;

namespace OnlineOrders.Repository
{
    public interface IClientRepository
    {
        Task<List<Client>> GetAllAsync(string? filterBy, string? filterQuery, string? sortBy, bool isAscending,int pageNumber,int pageSize);
        Task<Client> AddAsync(Client client);
        Task<Client?> UpdateAsync(Guid id, Client client);
        Task<Client?> GetByIdAsync(Guid id);
        Task<Client?> DeleteAsync(Guid id);
    }
}
