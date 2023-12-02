using MediatR;

namespace Application.Customers.ResetCustomerPassword;

public record ResetPasswordCommand(Guid Id, string Password) : IRequest;
