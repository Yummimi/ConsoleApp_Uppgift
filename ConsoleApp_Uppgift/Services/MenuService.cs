
namespace ConsoleApp_Uppgift.Services;

using Castle.Core.Resource;
using ConsoleApp_Uppgift.Interfaces;
using ConsoleApp_Uppgift.Models;
using System.Security.Cryptography.X509Certificates;

public class MenuService : IMenuService
{
    private readonly CustomerService _customerService;
    public MenuService()
    {
        try
        {
            _customerService = new CustomerService();
            ShowMenu();
        }

        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

    }

    public void ShowMenu()
    {
        /*
        While the showMenu bool is true, it should create a loop for the menu/switch i created.
        */
        try
        {
            bool showMenu = true;

            while (showMenu)
            {
                Console.WriteLine("Hello! Please pick an option: ");
                Console.WriteLine("1:  Add a customer to list.");
                Console.WriteLine("2:  Remove a customer from list.");
                Console.WriteLine("3:  Show list of customers.");

                int userInput = Convert.ToInt32(Console.ReadLine()); //Saves the input of user in userInput which is then used to decide which case to enter in the switch.

                switch (userInput)
                {
                    // Entering the first case will create a new customer and save its properties to the Customers class, one property at a time, corresponding to the users input.
                    case 1:
                        var customer = new Customers();
                        Console.WriteLine("Please enter a first name: ");
                        customer.Firstname = Console.ReadLine();

                        Console.WriteLine("Please enter a last name: ");
                        customer.Lastname = Console.ReadLine();

                        Console.WriteLine("Please enter an email: ");
                        customer.Email = Console.ReadLine();

                        Console.WriteLine("Please enter a phone number: ");
                        customer.Phone = Console.ReadLine();

                        Console.WriteLine("Please enter an address: ");
                        customer.Address = Console.ReadLine();
                        _customerService.AddCustomerToList(customer); // It then saves the customer to the file by calling the AddCustomerToList method.
                        break;

                    // Entering the second case will save the input of user to a variable. If customer enters "1" they will return to the main menu. If not, it will run the RemoveCustomerFromList with user input as it's argument.
                    // It will make a bool called "found" and if found is true within the RemoveCustomerFromList method, it will break the loop and return to the main menu. Otherwise it will repeat the case.
                    case 2:

                        while (true)
                        {
                            Console.WriteLine("Please enter the email of the customer you want to remove: ");
                            Console.WriteLine("Press 1 to go back to main menu.");

                            string input = Console.ReadLine();

                            if (input == "1")
                            {
                                break;
                            }

                            else
                            {
                                bool found = _customerService.RemoveCustomerFromList(input);

                                if (found)
                                {
                                    break;
                                }
                            }

                        }
                        break;

                    //Entering case 3 will simply run the ShowCustomerList method which will return a list of customers.
                    case 3:
                        _customerService.ShowCustomerList();
                        break;

                    default:
                        break;
                }
            }
        }

        catch(Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

    }
}
