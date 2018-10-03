using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App;
using Xunit;

namespace Tests
{
    public class Class1
    {
        [Fact]
        public void CustomerServiceTest()
        {
            var customerService = new CustomerService();

            customerService.AddCustomer("tr", "3", "d", DateTime.MinValue, 2);
        }
    }
}
