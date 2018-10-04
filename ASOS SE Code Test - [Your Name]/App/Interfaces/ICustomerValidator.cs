using System;

namespace App.Interfaces
{
    public interface ICustomerValidator
    {
        bool ValidateCustomer(string firstName, string surname, string email, DateTime dateOfBirth);
    }
}