using Domain.Customers;
using MediatR;

namespace Application.Customers.DeleteCustomer;

public class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommand>
{
    private readonly ICustomerRepository _customerRepository;

    public DeleteRoomCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
    {
        await _customerRepository.DeleteAsync(request.Id);
    }
}
