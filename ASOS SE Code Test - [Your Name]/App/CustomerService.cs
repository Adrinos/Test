using System;
using App.Facade;
using App.Interfaces;
using App.Objects;
using App.Repository;
using App.Services;
using App.Strategies;

namespace App
{
    public class CustomerService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ICustomerCreditContext _customerCreditContext;
        private readonly ICustomerDataAccessFacade _customerDataAccessFacade;
        private readonly ICustomerValidator _customerValidator;

        public CustomerService()
        {
            ICustomerCreditServiceClient customerCreditServiceClient = new CustomerCreditServiceClient();

            _customerDataAccessFacade = new CustomerDataAccessFacade();
            _customerValidator = new CustomerValidator();
            _companyRepository = new CompanyRepository();
            _customerCreditContext = new CustomerCreditContext(customerCreditServiceClient);
        }

        public CustomerService(ICompanyRepository companyRepository, ICustomerCreditContext customerCreditContext, ICustomerDataAccessFacade customerDataAccessFacade, ICustomerValidator customerValidator)
        {
            _companyRepository = companyRepository;
            _customerCreditContext = customerCreditContext;
            _customerDataAccessFacade = customerDataAccessFacade;
            _customerValidator = customerValidator;
        }

        public bool AddCustomer(string firstName, string surname, string email, DateTime dateOfBirth, int companyId)
        {

            if (!_customerValidator.ValidateCustomer(firstName, surname, email, dateOfBirth)) return false;

            var company = _companyRepository.GetById(companyId);

            var customer = new Customer
                               {
                                   Company = company,
                                   DateOfBirth = dateOfBirth,
                                   EmailAddress = email,
                                   Firstname = firstName,
                                   Surname = surname
                               };

            var updatedCustomer = _customerCreditContext.DoCreditCheck(company, customer);

            if (updatedCustomer.HasCreditLimit && updatedCustomer.CreditLimit < 500)
            {
                return false;
            }

            _customerDataAccessFacade.AddCustomer(customer);

            return true;
        }
    }
}