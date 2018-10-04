using System;
using App;
using App.Facade;
using App.Interfaces;
using App.Objects;
using App.Strategies;
using Moq;
using Shouldly;
using Xbehave;
using Xunit;

namespace Tests
{
    public class CustomerServiceTests
    {

        private Mock<ICompanyRepository> CompanyRepositoryMock { get; }
        private Mock<ICustomerCreditContext> CustomerCreditContextMock { get; }
        private Mock<ICustomerCreditServiceClient> CustomerCreditServiceClientMock { get; }
        private Mock<ICustomerDataAccessFacade> CustomerDataAccessFacadeMock { get;  }
        private Mock<ICustomerValidator> CustomerValidatorMock { get; }

        public CustomerServiceTests()
        {
            CompanyRepositoryMock = new Mock<ICompanyRepository>();
            CustomerCreditContextMock = new Mock<ICustomerCreditContext>();
            CustomerCreditServiceClientMock = new Mock<ICustomerCreditServiceClient>();
            CustomerValidatorMock = new Mock<ICustomerValidator>();
            CustomerDataAccessFacadeMock = new Mock<ICustomerDataAccessFacade>();
        }

        [Fact]
        public void VeryImportantClientGetsAdded()
        {
            var sut = new CustomerService(CompanyRepositoryMock.Object, new CustomerCreditContext(CustomerCreditServiceClientMock.Object), CustomerDataAccessFacadeMock.Object, CustomerValidatorMock.Object);
            var dob = new DateTime(1991, 10, 17);
            var company = new Company
                {Classification = Classification.Bronze, Id = 2, Name = "VeryImportantClient" };
            var customer = new Customer
            {
                Company = company,
                DateOfBirth = dob,
                EmailAddress = "Test@Test.com",
                Firstname = "Joe",
                Surname = "Blogs",
                HasCreditLimit = false,
                Id = 0,
                CreditLimit = 0
            };
            var updatedCustomer = new Customer
            {
                Company = company,
                DateOfBirth = dob,
                EmailAddress = "Test@Test.com",
                Firstname = "Joe",
                Surname = "Blogs",
                HasCreditLimit = true,
                Id = 0,
                CreditLimit = 100
            };

            CompanyRepositoryMock.Setup(x => x.GetById(2)).Returns(company);

            var result = sut.AddCustomer("Joe", "Blogs", "Test@Test.com" , dob, 2);

            result.ShouldBe(true);
        }

        [Fact]
        public void ImportantClientGetsAdded()
        {
            var sut = new CustomerService(CompanyRepositoryMock.Object, new CustomerCreditContext(CustomerCreditServiceClientMock.Object));
            var dob = new DateTime(1991, 10, 17);
            var company = new Company
                { Classification = Classification.Bronze, Id = 2, Name = "ImportantClient" };
            var customer = new Customer
            {
                Company = company,
                DateOfBirth = dob,
                EmailAddress = "Test@Test.com",
                Firstname = "Joe",
                Surname = "Blogs",
                HasCreditLimit = false,
                Id = 0,
                CreditLimit = 0
            };
            var updatedCustomer = new Customer
            {
                Company = company,
                DateOfBirth = dob,
                EmailAddress = "Test@Test.com",
                Firstname = "Joe",
                Surname = "Blogs",
                HasCreditLimit = true,
                Id = 0,
                CreditLimit = 100
            };

            CompanyRepositoryMock.Setup(x => x.GetById(2)).Returns(company);

            var result = sut.AddCustomer("Joe", "Blogs", "Test@Test.com", dob, 2);

            result.ShouldBe(false);
        }
    }
}