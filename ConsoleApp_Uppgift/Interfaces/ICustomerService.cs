using ConsoleApp_Uppgift.Models;

namespace ConsoleApp_Uppgift.Interfaces
{
    public interface ICustomerService
    {
        void AddCustomerToList(Customers customer);
        bool RemoveCustomerFromList(string input);
        void ShowCustomerList();
    }
}