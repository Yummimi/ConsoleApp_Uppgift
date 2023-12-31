using ConsoleApp_Uppgift.Models;


namespace ConsoleApp_Uppgift.Interfaces
{
    public interface ICustomerListService
    {
        string FilePath { get; }
        IEnumerable<Customers> LoadCustomersFromFile(string? filepath = null);
        void SaveCustomersToFile(List<Customers> customerList);
    }
}
