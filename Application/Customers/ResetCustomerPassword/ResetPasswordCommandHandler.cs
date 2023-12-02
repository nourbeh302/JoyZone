using Domain.Customers;
using MediatR;

namespace Application.Customers.ResetCustomerPassword;

public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand>
{
    private readonly ICustomerRepository _customerRepository;

    public ResetPasswordCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        var passwordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(request.Password);

        await _customerRepository.ResetPasswordAsync(request.Id, passwordHash);
    }
}
