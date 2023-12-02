namespace Domain.Customers;

public interface ICustomerRepository
{
    Task<IReadOnlyList<Customer>> ListAsync();
    Task<Customer?> GetByIdAsync(Guid id);
    Task CreateAsync(Customer customer);
    Task UpdateAsync(Customer customer);
    Task DeleteAsync(Guid id);
    Task<Customer?> LogInAsync(string email, string password);
    Task ResetPasswordAsync(Guid id, string password);
    Task<Customer?> GetByEmailAsync(string email);
}