using VeracidataApi.Application.Models.Responses;
using VeracidataApi.Application.Models.Requests;

namespace VeracidataApi.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<long> InsertAsync(CustomerCreateRequest req);
        Task<int> UpdateAsync(CustomerUpdateRequest customer);
        Task<int> UpdateActiveStatusAsync(long id, bool active);
        Task<CustomerResponse?> GetByIdAsync(long id);
        Task<CustomerResponse?> GetByEmailAsync(string email);
        Task<IEnumerable<CustomerListResponse>> GetAllAsync();
        Task<int> DeleteAsync(long id);
    }
}
