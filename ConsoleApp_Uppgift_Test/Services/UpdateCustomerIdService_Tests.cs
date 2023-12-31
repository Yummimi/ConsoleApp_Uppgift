using ConsoleApp_Uppgift.Interfaces;
using ConsoleApp_Uppgift.Models;
using ConsoleApp_Uppgift.Services;
using System.Text.Json;
using Moq;
using Xunit;
using System.Collections.Generic;

namespace ConsoleApp_Uppgift_Test.Services
{
    public class UpdateCustomerIdService_Tests
    {
        [Fact]
        public void UpdateCustomerIdService_ShouldDecreaseCustomerIdByOneOnCustomerWithRemovedId()
        {
            //Arrange
            UpdateCustomerIdService customerIdService = new UpdateCustomerIdService();
            List<Customers> customerList = new List<Customers>();
            Customers customer1 = new Customers()
            {
                Id = 1,
            };
            Customers customer2 = new Customers()
            {
                Id = 2,
            };
            Customers customer3 = new Customers()
            {
                Id = 3,
            };
            customerList.Add(customer1);
            customerList.Add(customer2);
            customerList.Add(customer3);
            int removedId = 2;
            //Act
            customerIdService.RefreshIds(customerList, removedId);

            //Assert
            Assert.Equal(1, customerList[0].Id);
            Assert.Equal(customerList[1].Id, customerList[2].Id);
            Assert.Equal(3, customerList.Count);

        }
    }
}
