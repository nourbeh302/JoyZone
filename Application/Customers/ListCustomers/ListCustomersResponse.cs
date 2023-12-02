using Domain.Customers;

namespace Application.Customers.ListCustomers;

public record ListCustomersResponse(
    Guid Id, string Name, string Email);
