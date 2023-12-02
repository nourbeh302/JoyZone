using MediatR;

namespace Application.Customers.DeleteCustomer;

public record DeleteRoomCommand(Guid Id) : IRequest;
