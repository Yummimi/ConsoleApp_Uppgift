using ConsoleApp_Uppgift.Interfaces;
using ConsoleApp_Uppgift.Models;
using System.ComponentModel;
using System.Text.Json;

namespace ConsoleApp_Uppgift.Services;

public class CustomerService : ICustomerService

{ 
    private readonly List<Customers> _customerList;
    private readonly CustomerListService _customerListService;
    private static int _nextId = 1;

    public CustomerService()
    {
        _customerList = new List<Customers>();
        _customerListService = new CustomerListService();
        var loadedCustomers = _customerListService.LoadCustomersFromFile();
        _customerList = loadedCustomers.ToList();
    }

    /*
    AddCustomerToList should add a customer to list following the "Customers" properties. It makes sure the next Id is equal to 1 instead of 0, Adds the customer to the list, and then uses the SaveCustomerToFile method to save or create a json file in the choice of filepath.
    (You should change the filepath in "CustomerListService.SaveCustomerToFile" method and inside my test-project to ensure you have a valid file path)
    */
    public void AddCustomerToList(Customers customer)
    {
        try
        {
            customer.Id = _nextId++;
            _customerList.Add(customer);
            _customerListService.SaveCustomersToFile(_customerList);

        }

        catch (Exception ex) 
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        
    }

    /*
    RemoveCustomerFromList should remove the customer from the _customerList if the user input matches an already existing email of one of the customers.
    It should also refresh the id of the remaining customers using the "RefreshIds" method inside UpdateCustomerIdService.
    The _nextId = _customerList.Count + 1 makes sure that the next available id for the upcoming customers will be one greater than the previous, so that IDs are not reused.
    Finally, the SaveCustomerToFile method is called with the arguments _customerList, to save the list of customers to a json file within a filePath of my choice, it then returns true.

    If input is not equal to any customer email in the list, it will instead print a message and return false.
    */
    public bool RemoveCustomerFromList(string input)
    {
        try
        {
            UpdateCustomerIdService customerIdService = new UpdateCustomerIdService();
            foreach (Customers customer in _customerList)
            {
                if (customer.Email == input)
                {
                    int removedId = customer.Id;
                    _customerList.Remove(customer);
                    customerIdService.RefreshIds(_customerList, removedId);
                    _nextId = _customerList.Count + 1;
                    _customerListService.SaveCustomersToFile(_customerList);
                    Console.WriteLine($"Customer \n {customer} \n removed successfully.");
                    return true;
                }
            }

            Console.WriteLine("This email does not exist. Try again");
            return false;
        }

        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return false;
        }

        
    }
    /*
    ShowCustomerList should print out the list of customers present within the customerlist and all its properties.
    */
    public void ShowCustomerList()
    {
        try
        {
            CustomerService customerService = new CustomerService();
            Console.WriteLine("List of Customers: ");
            foreach (var cust in _customerList)
            {
                Console.WriteLine($"ID: {cust.Id}, Firstname: {cust.Firstname}, Lastname: {cust.Lastname}, Email: {cust.Email}, Phone: {cust.Phone}, Address: {cust.Address}");
            }
        }

        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

    }
    /*
    GetCustomerList returns the list of customers so that i can use this method in different methods/files to get the list of customers.
    */
    public List<Customers> GetCustomerList()
    {
        return _customerList;
    }
}
