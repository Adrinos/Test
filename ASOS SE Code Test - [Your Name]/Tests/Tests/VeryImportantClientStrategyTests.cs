using System;
using App.Objects;
using App.Strategies;
using Shouldly;
using Xunit;

namespace Tests.Tests
{
    public class VeryImportantClientStrategyTests
    {

        [Fact]
        public void VeryImportantClientGetsNoCredit()
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

            var sut = new VeryImportantClientStrategy();

            var result = sut.DoCreditCheck(customer);

            result.CreditLimit.ShouldBe(0);
        }
    }
}