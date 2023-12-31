

using ConsoleApp_Uppgift.Interfaces;
using ConsoleApp_Uppgift.Models;
using ConsoleApp_Uppgift.Services;
using System.Text.Json;
using Moq;
using Xunit;
using System.Collections.Generic;

namespace ConsoleApp_Uppgift_Test.Services
{
    public class CustomerListService_Tests
    {
        private const string FilePath = @"D:\School\Kurs_3_C#\ConsoleApp\ConsoleApp_Uppgift\customer.json";

        [Fact]
        public void LoadCustomersFromFile_WhenFileExists_ShouldReturnCustomerList()
        {
            // Arrange
            var customerListService = new CustomerListService();
            List <Customers> customerList = new List<Customers>();
            Customers customer = new Customers()
            {
                Firstname = "Sarah",
                Lastname = "Tibblin",
                Email = "sarah.tibblin@domain.se",
                Phone = "070-123-4567",
                Address = "Wadköpingsvägen 61"
            };
            customerList.Add(customer);

            // Act
            customerListService.SaveCustomersToFile(customerList);
            var result = customerListService.LoadCustomersFromFile(FilePath);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.IsType<List<Customers>>(result);

        }

        [Fact]
        public void LoadCustomersFromFile_WhenFileDoesNotExist_ShouldReturnNewList()
        {
            // Arrange
            var nonExistentFilePath = @"D:\School\Kurs_3_C#\ConsoleApp\ConsoleApp_Uppgift\nonexistentfile.json";

            // Act
            var customerListService = new CustomerListService();
            var result = customerListService.LoadCustomersFromFile(nonExistentFilePath);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
            Assert.IsType<List<Customers>>(result);
        }


        [Fact]

        public void SaveCustomerToFile_ShouldSaveCustomerToFile_ThenReturnTrue()
        {
            //Arrange
            var customerListService = new CustomerListService();
            List<Customers> customerList = new List<Customers>();
            Customers customer = new Customers()
            {
                Firstname = "Sarah",
                Lastname = "Tibblin",
                Email = "sarah.tibblin@domain.se",
                Phone = "070-123-4567",
                Address = "Wadköpingsvägen 61"
            };
            customerList.Add(customer);

            //Act
            customerListService.SaveCustomersToFile(customerList);

            //Assert
            Assert.True(File.Exists(customerListService.FilePath));
            string[] lines = File.ReadAllLines(customerListService.FilePath);
            Customers expectedCustomer = customer;
            Assert.Contains(expectedCustomer, customerList);
        }

    }
}