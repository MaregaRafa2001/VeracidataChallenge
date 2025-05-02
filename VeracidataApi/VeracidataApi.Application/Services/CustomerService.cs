using VeracidataApi.Domain.Interfaces;
using VeracidataApi.Application.Interfaces;
using VeracidataApi.Application.Models.Requests;
using VeracidataApi.Domain.Entities;
using VeracidataApi.Application.Models.Responses;
using VeracidataApi.Application.Helpers;

namespace VeracidataApi.Application.Services
{
    public class CustomerService : ICustomerService
    {
         private readonly ICustomerRepository _customerRepository;
         public CustomerService(ICustomerRepository customerRepository)
         {
             _customerRepository = customerRepository;
         }

        public async Task<long> InsertAsync(CustomerCreateRequest req)
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

        public async Task<CustomerResponse?> GetByIdAsync(long id)
        {
            var c = await _customerRepository.GetByIdAsync(id);
            if (c == null) return null;
            return new CustomerResponse(c.Id, c.Name, c.NickName, c.Phone, c.BirthDate, c.Email, c.Active);
        }

        public async Task<CustomerResponse?> GetByEmailAsync(string email)
        {
            var customer = await _customerRepository.GetByEmailAsync(email);
            if (customer == null) return null;
            return new CustomerResponse(customer.Id, customer.Name, customer.NickName, customer.Phone, customer.BirthDate, customer.Email, customer.Active);
        }

        public async Task<IEnumerable<CustomerListResponse>> GetAllAsync()
        {
            var list = await _customerRepository.GetAllAsync();
            return list.Select(c => new CustomerListResponse(c.Id, c.Name, c.Email, c.Active));
        }

        public async Task<int> UpdateAsync(CustomerUpdateRequest req)
        {
            var entity = new Customer
            {
                Id = req.Id,
                Name = req.Name,
                NickName = req.NickName,
                Phone = req.Phone,
                BirthDate = req.BirthDate,
                Email = req.Email,
                Password = PasswordHelper.Hash(req.Password),
                Active = req.Active
            };
            return await _customerRepository.UpdateAsync(entity);
        }

        public async Task<int> UpdateActiveStatusAsync(long id, bool active)
        {
            return await _customerRepository.UpdateActiveStatusAsync(id, active);
        }

        public Task<int> DeleteAsync(long id) => _customerRepository.DeleteAsync(id);
    }

}
