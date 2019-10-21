/*using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using WebAPIBase.Controllers;
using WebAPIStarterData.Models;
using FluentAssertions;
using System.Collections.Generic;
using Moq;
using WebAPIBase.Services;


namespace WebAPIStarter.Tests
{
    public class CustomerControllerTests
    {
        
        [Fact]
        public void getOne()
        {
            //arrange
                //CustomerController customerController= new CustomerController();
            //Arrange
            //var customer= new List<Customer>{
            //    new Customer {Id = 1, Firstname="Steve",LastName="Bishop", Email="steve.bishop@galvanize.com"},
            //    new Customer {Id = 2, Firstname="Tanner",LastName="Bihop", Email="stee.bishop@galvanize.com"},
            //    new Customer {Id = 3, Firstname="Eiud",LastName="Bishp", Email="steve.bihop@galvanize.com"}
            //};
           // CustomerController SUT = new CustomerController(customer);
                var mockService = new Mock<ICustomerService>();
                var fakeCustomer = new Customer {Id = 1, Firstname="Steve",LastName="Bishop", Email="steve.bishop@galvanize.com"};
                mockService.Setup(serv=> serv.GetOne(1)).Returns(fakeCustomer);
                CustomerController SUT = new CustomerController(mockService.Object);

            //Act
                var getResult=(OkObjectResult)SUT.GetOne(1);

            //Assert
                var expected =new Customer {Id = 1, Firstname="Steve",LastName="Bishop", Email="steve.bishop@galvanize.com"};
                    //Assert.IsType<OkObjectResult>(getResult);
                getResult.Value.Should().BeEquivalentTo(expected);

        }



        
        [Fact]
        public void getAll_WhenCalled_ReturnsOKResult()
        {
            

            //arrange
                var mockService = new Mock<ICustomerService>();
                
                CustomerController customerController= new CustomerController(mockService.Object);
            //Act 
                var getResult=customerController.GetAll();

            //Assert
                    Assert.IsType<OkObjectResult>(getResult);

        }
        [Fact]
        public void getUpdate()
        {
            //arrange
                var mockService = new Mock<ICustomerService>();
                CustomerController customerController= new CustomerController(mockService.Object);
                Customer newCustomer = new Customer{
                    Firstname="Eliud",
                    LastName="Garcia",
                    Email="e@email.com"
                };
                
            //Act 
                var getResult=customerController.Update(1, newCustomer);

            //Assert
                    Assert.IsType<NoContentResult>(getResult);

        }
        [Fact]
        public void getDelete()
        {
            //arrange
                var mockService = new Mock<ICustomerService>();
                CustomerController customerController= new CustomerController(mockService.Object);
            //Act 
                var getResult=customerController.Delete(1);

            //Assert
                    Assert.IsType<StatusCodeResult>(getResult);

        }
        [Fact]
        public void getCreate()
        {
            //arrange
                var mockService = new Mock<ICustomerService>();
                CustomerController customerController= new CustomerController(mockService.Object);
            //Act 
               Customer newCustomer = new Customer{
                    Firstname="Eliud",
                    LastName="Garcia",
                    Email="e@email.com"
                };
                 mockService.Setup(serv => serv.Add(newCustomer)).Returns(newCustomer);
                var getResult=customerController.Create(newCustomer);

            //Assert
                    Assert.IsType<CreatedAtActionResult>(getResult);

        }
    }
}*/
