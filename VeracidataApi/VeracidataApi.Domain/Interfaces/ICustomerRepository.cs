using VeracidataApi.Domain.Entities;

namespace VeracidataApi.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<long> InsertAsync(Customer customer);
        Task<int> UpdateAsync(Customer customer);
        Task<int> UpdateActiveStatusAsync(long id, bool active);
        Task<Customer?> GetByIdAsync(long id);
        Task<Customer?> GetByEmailAsync(string email);
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<int> DeleteAsync(long id);
    }
}
