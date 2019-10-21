using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using WebAPIStarterData.Models;
using WebAPIBase.Services;
using WebAPIStartData;

namespace WebAPIStartTests.Tests
{
    public class InMemoryDatabaseCustomerServiceTests : IDisposable
    {
        private WebAPIStartContext context;
        public InMemoryDatabaseCustomerServiceTests()
        {
            var options = DbContextOptionsBuilder<WebAPIStartContext>().InMemoryDatabase("mock-CustomerService").Options;
            context= new WebAPIStartContext(options);
        }

        [Fact]
        public void Add_WhenCalled_AddCustomerContext()
        {
        //Given
        context.Database.EnsureDeleted();
        Customer fakeCustomer = new Customer{
            Firstname="Eliud",
            LastName="Garcia",
            Email="e@email.com"
        };
        var SUT = new InMemoryDatabaseCustomerServiceTests(context);
        //When
        var newCustomer = SUT.Add(fakeCustomer);

        //Then
        context.Customer.Find(newCustomer.Id).Should().BeEquivalentTo(newCustomer);
        }


        [Fact]
        public void Delete_WhenCalled_()
        {
        //Given
        context.Database.EnsureDeleted();
        Customer fakeCustomer = new Customer{
            Firstname="Eliud",
            LastName="Garcia",
            Email="e@email.com"
        };
        var SUT = new InMemoryDatabaseCustomerServiceTests(context);
        //When
        var newCustomer = SUT.Add(fakeCustomer).Entity;

        //Then
        var deletedCustomer = SUT.Delete(newCustomer.Id);
        context.Customer.Find(newCustomer.Id).Should().BeNUll();
        }

        public void Dispose(){
            context.Dispose();
        }
    }
}