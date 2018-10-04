using App.Objects;

namespace App.Interfaces
{
    public interface ICustomerCreditContext
    {
        Customer DoCreditCheck(Company company, Customer customer);
    }
}