using Dapper;
using System.Data;
using VeracidataApi.Domain.Entities;
using VeracidataApi.Domain.Interfaces;

namespace VeracidataApi.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDbConnection _connection;

        public CustomerRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<long> InsertAsync(Customer customer)
        {
            const string sql = @"
                INSERT INTO Customers (
                    Name, 
                    NickName, 
                    Phone, 
                    BirthDate, 
                    Email, 
                    Password, 
                    Active
                )
                OUTPUT INSERTED.Id
                VALUES (
                    @Name, 
                    @NickName, 
                    @Phone, 
                    @BirthDate, 
                    @Email, 
                    @Password, 
                    @Active
                )";

            return await _connection.ExecuteScalarAsync<long>(sql, customer);
        }

        public async Task<int> UpdateAsync(Customer customer)
        {
            const string sql = @"
                UPDATE Customers 
                SET 
                    Name = @Name,
                    NickName = @NickName,
                    Phone = @Phone,
                    BirthDate = @BirthDate,
                    Email = @Email,
                    Password = @Password,
                    Active = @Active
                WHERE Id = @Id";

            return await _connection.ExecuteAsync(sql, customer);
        }

        public async Task<int> UpdateActiveStatusAsync(long id, bool active)
        {
            const string sql = @"
                UPDATE Customers 
                SET Active = @Active
                WHERE Id = @Id";

            return await _connection.ExecuteAsync(sql, new { Id = id, Active = active });
        }

        public async Task<Customer?> GetByIdAsync(long id)
        {
            const string sql = "SELECT * FROM Customers WITH (NOLOCK) WHERE Id = @Id";
            return await _connection.QueryFirstOrDefaultAsync<Customer>(sql, new { Id = id });
        }
        
        public async Task<Customer?> GetByEmailAsync(string email)
        {
            const string sql = "SELECT * FROM Customers WITH (NOLOCK) WHERE Email = @Email";
            return await _connection.QueryFirstOrDefaultAsync<Customer>(sql, new { email });
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            const string sql = "SELECT * FROM Customers WITH (NOLOCK)";
            return await _connection.QueryAsync<Customer>(sql);
        }

        public async Task<int> DeleteAsync(long id)
        {
            const string sql = "DELETE FROM Customers WHERE Id = @Id";
            return await _connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}