using App.Interfaces;
using App.Objects;

namespace App.Strategies
{
    class VeryImportantClientStrategy : ICreditCheckStrategy
    {
        public Customer DoCreditCheck(Customer customer)
        {
            customer.HasCreditLimit = true;
            customer.CreditLimit = int.MaxValue;

            return customer;
        }
    }
}