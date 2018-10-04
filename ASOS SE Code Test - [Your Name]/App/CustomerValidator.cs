using System;
using App.Interfaces;

namespace App
{
    public class CustomerValidator : ICustomerValidator
    {

        public bool ValidateCustomer(string firstName, string surname, string email, DateTime dateOfBirth)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(surname))
            {
                return false;
            }

            if (!email.Contains("@") && !email.Contains("."))
            {
                return false;
            }

            var now = DateTime.Now;
            var age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;

            if (age < 21)
            {
                return false;
            }

            return true;
        }
    }
}