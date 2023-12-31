using ConsoleApp_Uppgift.Models;

namespace ConsoleApp_Uppgift.Interfaces
{
    public interface IUpdateCustomerIdService
    {
        void RefreshIds(List<Customers> customerList, int removedId);
    }
}
