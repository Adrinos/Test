using App.Interfaces;
using App.Objects;

namespace App.Strategies
{
    public class ImportantClientStrategy : ICreditCheckStrategy
    {
        private readonly ICustomerCreditServiceClient _customerCreditServiceClient;

        public ImportantClientStrategy(ICustomerCreditServiceClient customerCreditServiceClient)
        {
            _customerCreditServiceClient = customerCreditServiceClient;
        }

        public Customer DoCreditCheck(Customer customer)
        {
            // Do credit check and double credit limit
            customer.HasCreditLimit = true;
            var creditLimit = _customerCreditServiceClient.GetCreditLimit(customer.Firstname, customer.Surname, customer.DateOfBirth);
            creditLimit = creditLimit * 2;
            customer.CreditLimit = creditLimit;

            return customer;
        }
    }
}