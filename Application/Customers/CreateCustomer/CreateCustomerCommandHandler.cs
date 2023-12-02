using Domain.Customers;
using MediatR;

namespace Application.Customers.CreateCustomer;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand>
{
    private readonly ICustomerRepository _customerRepository;

    public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var passwordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(request.Password);

        Customer customer = new Customer(
            Guid.NewGuid(), 
            request.Name, 
            request.Email,
            passwordHash);

        await _customerRepository.CreateAsync(customer);
    }
}
