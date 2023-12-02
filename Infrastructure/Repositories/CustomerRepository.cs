using Domain.Customers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _context;

    public CustomerRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Customer>> ListAsync()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task<Customer?> GetByIdAsync(Guid id)
    {
        var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);

        if (customer is null)
            return null;

        return customer;
    }

    public async Task CreateAsync(Customer customer)
    {
        await _context.Customers
            .AddAsync(customer);

        _context.SaveChanges();
    }

    public async Task UpdateAsync(Customer customer)
    {
        await _context.Customers
            .Where(c => c.Id == customer.Id)
            .ExecuteUpdateAsync(s =>
                s.SetProperty(c => c.Name, customer.Name)
                    .SetProperty(c => c.Email, customer.Email)
                    .SetProperty(c => c.Password, customer.Password));
    }

    public async Task DeleteAsync(Guid id)
    {
        await _context.Customers
            .Where(c => c.Id == id)
            .ExecuteDeleteAsync();
    }

    public async Task<Customer?> LogInAsync(string email, string password)
    {
        var customer = await _context.Customers
            .FirstOrDefaultAsync(c => c.Email == email && c.Password == password);

        if (customer is null) return null;

        return customer;
    }

    public async Task ResetPasswordAsync(Guid id, string password)
    {
        await _context.Customers
            .Where(c => c.Id == id)
            .ExecuteUpdateAsync(s =>
                s.SetProperty(c => c.Password, password));
    }

    public async Task<Customer?> GetByEmailAsync(string email)
    {
        var customer = await _context.Customers
            .FirstOrDefaultAsync(c => c.Email.Equals(email));

        if (customer is not null)
            return customer;

        return null;
    }
}