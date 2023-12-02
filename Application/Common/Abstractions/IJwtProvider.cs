using Domain.Customers;

namespace Application.Common.Abstractions;

public interface IJwtProvider
{
    string Generate(Customer customer);
}
