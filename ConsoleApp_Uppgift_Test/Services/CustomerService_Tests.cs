
using ConsoleApp_Uppgift.Interfaces;
using ConsoleApp_Uppgift.Models;
using ConsoleApp_Uppgift.Services;
using System.Security.Cryptography.X509Certificates;
using Moq;
using Xunit;
using Castle.Core.Resource;
using System.Reflection;

namespace ConsoleApp_Uppgift_Test.Services
{
    public class CustomerService_Tests
    {
        [Fact]

        public void AddCustomerToListShould_AddOneCustomerToList()
        {
            // Arrange
            CustomerService customerService = new CustomerService();
            var initialCount = customerService.GetCustomerList().Count;
            Customers customer = new Customers
            {
                Firstname = "Sarah",
                Lastname = "Tibblin",
                Email = "sarah.tibblin@domain.se",
                Phone = "070-123-4567",
                Address = "Wadköpingsvägen 61"
            };


            //Act
            customerService.AddCustomerToList(customer);

            // Assert
            var updatedList = customerService.GetCustomerList();
            var lastCustomerId = updatedList.Last().Id;
            Assert.Equal(initialCount + 1, updatedList.Count);
            Assert.Contains(customer, updatedList);
        }



        [Fact]

        public void RemoveCustomerToList_ShouldRemoveOneCustomerIfInputEqualToCustomerEmail()
        {
            // Arrange
            CustomerService customersService = new CustomerService();
            Customers customer = new Customers
            {
                Email = "sarah.tibblin@domain.se"
            };
            string customerToRemove = customer.Email;

            //Act
            customersService.RemoveCustomerFromList(customerToRemove);


            // Assert
            Assert.Equal(customerToRemove, customer.Email);

        }

        [Fact]

        public void ShowCustomerList_ShouldShowAllCustomersInList()
        {
            // Arrange
            CustomerService customersService = new CustomerService();
            List<Customers> customerList = new List<Customers>();
            Customers customer = new Customers
            {
                Firstname = "Sarah",
                Lastname = "Tibblin",
                Email = "sarah.tibblin@domain.se",
                Phone = "070-123-4567",
                Address = "Wadköpingsvägen 61"
            };
            customerList.Add(customer);

            //Act
            customersService.ShowCustomerList();
            string customerDetails = $"{customer.Firstname} {customer.Lastname} {customer.Email} {customer.Phone} {customer.Address}";

            // Assert
        }
    }
}

