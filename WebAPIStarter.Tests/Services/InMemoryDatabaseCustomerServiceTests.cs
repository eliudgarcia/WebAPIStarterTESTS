using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using WebAPIStarterData.Models;
using WebAPIBase.Services;
using WebAPIStarterData;
using Microsoft.EntityFrameworkCore;
using Xunit;
using FluentAssertions;

namespace WebAPIStartTests.Tests
{
    public class InMemoryDatabaseCustomerServiceTests : IDisposable
    {
        private WebAPIStarterContext context;
        public InMemoryDatabaseCustomerServiceTests()
        {
            var options = new DbContextOptionsBuilder<WebAPIStarterContext>().UseInMemoryDatabase("mock-CustomerService").Options;
            context= new WebAPIStarterContext(options);
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
        var SUT = new InMemoryDatabaseCustomerService(context);
        //When
        var newCustomer = SUT.Add(fakeCustomer);

        //Then
        context.Customers.Find(newCustomer.Id).Should().BeEquivalentTo(newCustomer);
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
        var SUT = new InMemoryDatabaseCustomerService(context);
        //When
        var newCustomer = SUT.Add(fakeCustomer);

        //Then
        SUT.Delete(((Customer)newCustomer));
        context.Customers.Find(newCustomer.Id).Should().BeNull();
        }

        public void Dispose(){
            context.Dispose();
        }
    }
}