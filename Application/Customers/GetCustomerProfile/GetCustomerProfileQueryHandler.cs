using Domain.Customers;
using MediatR;

namespace Application.Customers.GetCustomerProfile;

public class GetCustomerProfileQueryHandler : IRequestHandler<GetCustomerProfileQuery, GetCustomerProfileResponse?>
{

    public readonly ICustomerRepository _customerRepository;

    public GetCustomerProfileQueryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<GetCustomerProfileResponse?> Handle(GetCustomerProfileQuery request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(request.Id);
        
        if (customer is null)
            return null;

        return new GetCustomerProfileResponse(customer.Email, customer.Name);
    }
}
