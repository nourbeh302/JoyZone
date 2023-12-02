using MediatR;

namespace Application.Customers.LogInCustomer;

public record LogInCustomerCommand(string Email, string Password) : IRequest<LogInCustomerResponse>;
