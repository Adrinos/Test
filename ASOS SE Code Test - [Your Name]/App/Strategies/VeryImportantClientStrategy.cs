using App.Interfaces;
using App.Objects;

namespace App.Strategies
{
    public class VeryImportantClientStrategy : ICreditCheckStrategy
    {
        public Customer DoCreditCheck(Customer customer)
        {
            //Believe there to be a bug here
            customer.HasCreditLimit = true;

            return customer;
        }
    }
}