using MediatR;

namespace Application.Customers.ListCustomers;

public class ListCustomersQuery : IRequest<IReadOnlyList<ListCustomersResponse>> { }
