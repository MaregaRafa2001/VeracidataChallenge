using VeracidataApi.Application.Models.Requests;
using VeracidataApi.Application.Models.Responses;

namespace VeracidataApi.Application.Interfaces
{
    public interface IAuthService
    {
        Task<long> RegisterAsync(RegisterRequest customer);
        Task<AuthResponse?> LoginAsync(LoginRequest req);
    }
}
