using MediatR;

namespace Application.Customers.GetCustomerProfile;

public record GetCustomerProfileQuery(Guid Id) : IRequest<GetCustomerProfileResponse?>;
