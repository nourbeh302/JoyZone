using MediatR;

namespace Application.Customers.CreateCustomer;

public record CreateCustomerCommand(
    string Name, 
    string Email, 
    string Password) : IRequest;
