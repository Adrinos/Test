using App.Objects;

namespace App.Interfaces
{
    public interface ICreditCheckStrategy
    {
        Customer DoCreditCheck(Customer customer);
    }
}