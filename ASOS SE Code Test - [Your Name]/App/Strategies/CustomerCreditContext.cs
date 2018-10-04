using System.Collections.Generic;
using App.Interfaces;
using App.Objects;

namespace App.Strategies
{
    public class CustomerCreditContext : ICustomerCreditContext
    {
        private static readonly Dictionary<string, ICreditCheckStrategy> Strategies =
            new Dictionary<string, ICreditCheckStrategy>();

        public CustomerCreditContext(ICustomerCreditServiceClient customerCreditServiceClient)
        {
            var customerCreditServiceClient1 = customerCreditServiceClient;
            Strategies.Add("VeryImportantClient", new VeryImportantClientStrategy());
            Strategies.Add("ImportantClient", new ImportantClientStrategy(customerCreditServiceClient1));
            Strategies.Add("Test", new DefaultClientStrategy(customerCreditServiceClient1));
        }

        public Customer DoCreditCheck(Company company, Customer customer)
        {
            return Strategies[company.Name].DoCreditCheck(customer);
        }
    }
}