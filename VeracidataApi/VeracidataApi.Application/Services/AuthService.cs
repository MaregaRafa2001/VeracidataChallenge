using VeracidataApi.Application.Interfaces;
using VeracidataApi.Application.Models.Requests;
using VeracidataApi.Domain.Entities;
using VeracidataApi.Domain.Interfaces;
using VeracidataApi.Application.Models.Responses;
using VeracidataApi.Domain.Config;
using VeracidataApi.Application.Helpers;

namespace VeracidataApi.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly JwtSettings _jwtSettings;

        public AuthService(
            ICustomerRepository customerRepository,
            JwtSettings jwtSettings)
        {
            _customerRepository = customerRepository;
            _jwtSettings = jwtSettings;
        }

        public async Task<long> RegisterAsync(RegisterRequest req)
        {
            var entity = new Customer
            {
                Name = req.Name,
                NickName = req.NickName,
                Phone = req.Phone,
                BirthDate = req.BirthDate,
                Email = req.Email,
                Password = PasswordHelper.Hash(req.Password),
                Active = true
            };

            return await _customerRepository.InsertAsync(entity);
        }

        public async Task<AuthResponse?> LoginAsync(LoginRequest req)
        {
            var customer = await _customerRepository.GetByEmailAsync(req.Email);
            if (customer == null || !PasswordHelper.Verify(req.Password, customer.Password))
                return null;

            var token = JwtTokenHelper.GenerateJwtToken(customer, _jwtSettings);

            return new AuthResponse(
                customer.Id,
                customer.Email,
                token);
        }
    }
}
