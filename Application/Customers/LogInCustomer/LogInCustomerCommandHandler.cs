using Application.Common.Abstractions;
using Domain.Customers;
using MediatR;

namespace Application.Customers.LogInCustomer;

public class LogInCustomerCommandHandler : IRequestHandler<LogInCustomerCommand, LogInCustomerResponse?>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IJwtProvider _jwtProvider;

    public LogInCustomerCommandHandler(ICustomerRepository customerRepository, IJwtProvider jwtProvider)
    {
        _customerRepository = customerRepository;
        _jwtProvider = jwtProvider;
    }

    public async Task<LogInCustomerResponse?> Handle(LogInCustomerCommand request, CancellationToken cancellationToken)
    {
        // Get the customer
        var customer = await _customerRepository.GetByEmailAsync(request.Email);

        if (customer is null)
            throw new Exception($"Customer with specified email: {request.Email} is not found.");

        var isValidPassword = BCrypt.Net.BCrypt.EnhancedVerify(request.Password, customer.Password);

        if (!isValidPassword)
            throw new Exception("Invalid password.");

        // Generate the token
        string token = _jwtProvider.Generate(customer);

        // Return the token
        return new LogInCustomerResponse(token);
    }
}
