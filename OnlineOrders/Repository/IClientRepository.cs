
using OnlineOrders.Models.Domain;

namespace OnlineOrders.Repository
{
    public interface IClientRepository
    {
        Task<List<Client>> GetAllAsync();
        //Task<Client?> GetByIdAsync(Guid id);
        Task<Client> AddAsync(Client client);
        //Task<Client?> UpdateAsync(Guid id, Client client);
        //Task<Client?> DeleteAsync(Guid id);
    }
}
