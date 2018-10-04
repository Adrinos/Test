using App.Objects;

namespace App.Facade
{
    public class CustomerDataAccessFacade : ICustomerDataAccessFacade
    {
        public void AddCustomer(Customer customer)
        {
            CustomerDataAccess.AddCustomer(customer);
        }
    }
}