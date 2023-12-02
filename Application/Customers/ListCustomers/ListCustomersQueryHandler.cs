using Domain.Customers;
using MediatR;
using System.Collections.Generic;

namespace Application.Customers.ListCustomers;

public class ListCustomersQueryHandler : IRequestHandler<ListCustomersQuery, IReadOnlyList<ListCustomersResponse>>
{
    private readonly ICustomerRepository _customerRepository;

    public ListCustomersQueryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<IReadOnlyList<ListCustomersResponse>> Handle(ListCustomersQuery request, CancellationToken cancellationToken)
    {
        var customers = await _customerRepository.ListAsync();

        return customers.Select(c => new ListCustomersResponse(
            c.Id,
            c.Name,
            c.Email)).ToList();
    }
}
