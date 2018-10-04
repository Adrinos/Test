using System;
using App.Interfaces;
using App.Objects;
using App.Strategies;
using Moq;
using Shouldly;
using Xunit;

namespace Tests
{
    public class DefaultStrategyTests
    {
        private Mock<ICustomerCreditServiceClient> CustomerCreditServiceClientMock { get; }

        public DefaultStrategyTests()
        {
            CustomerCreditServiceClientMock = new Mock<ICustomerCreditServiceClient>();
        }

        [Fact]
        public void DefaultClientGetsCredit()
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

            var sut = new DefaultClientStrategy(CustomerCreditServiceClientMock.Object);

            var result = sut.DoCreditCheck(customer);

            result.CreditLimit.ShouldBe(500);
        }
    }
}