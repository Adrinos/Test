using App.Interfaces;
using App.Objects;

namespace App.Strategies
{
    public class DefaultClientStrategy : ICreditCheckStrategy
    {
        private readonly ICustomerCreditServiceClient _customerCreditServiceClient;

        public DefaultClientStrategy(ICustomerCreditServiceClient customerCreditServiceClient)
        {
            _customerCreditServiceClient = customerCreditServiceClient;
        }

        public Customer DoCreditCheck(Customer customer)
        {
            // Do credit check
            customer.HasCreditLimit = true;
            customer.CreditLimit =
                _customerCreditServiceClient.GetCreditLimit(customer.Firstname, customer.Surname, customer.DateOfBirth);

            return customer;
        }
    }
}