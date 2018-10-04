using System;
using App.Interfaces;
using App.Objects;
using App.Strategies;
using Moq;
using Shouldly;
using Xunit;

namespace Tests.Tests
{
    public class ImportantClientStrategyTests
    {
        private Mock<ICustomerCreditServiceClient> CustomerCreditServiceClientMock { get; }

        public ImportantClientStrategyTests()
        {
            CustomerCreditServiceClientMock = new Mock<ICustomerCreditServiceClient>();
        }

        [Fact]
        public void ImportantClientGetsCreditDoubled()
        {
            var customer = new Customer
            {
                Company = new Company
                {
                    Classification = Classification.Bronze,
                    Id = 2,
                    Name = "Test"
                },
                DateOfBirth = new DateTime(1991, 10, 17),
                EmailAddress = "Test@Test.com",
                Firstname = "Joe",
                Surname = "Blogs",
                HasCreditLimit = false,
                Id = 0,
                CreditLimit = 0
            };

            CustomerCreditServiceClientMock
                .Setup(x => x.GetCreditLimit(customer.Firstname, customer.Surname, customer.DateOfBirth)).Returns(500);

            var sut = new ImportantClientStrategy(CustomerCreditServiceClientMock.Object);

            var result = sut.DoCreditCheck(customer);

            result.CreditLimit.ShouldBe(1000);
        }
    }
}