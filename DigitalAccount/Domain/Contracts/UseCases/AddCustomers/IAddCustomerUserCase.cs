using Domain.Entities;

namespace Domain.Contracts.UseCases.AddCustomer
{
    public interface IAddCustomerUserCase
    {
        void AddCustomer(Customer customer);
    }
}
