
using ConsoleApp_Uppgift.Interfaces;
using ConsoleApp_Uppgift.Models;

namespace ConsoleApp_Uppgift.Services
{
    /*
    The method RefreshIds should go through the list of customers, check the present customers one by one and where customer.Id is greater than "removedId", it should decrease each and ever Id by one.
    This is to ensure that no customers has the same Id. This method is called upon in other files to make more sense.
    */
    public class UpdateCustomerIdService : IUpdateCustomerIdService
    {
        public void RefreshIds(List<Customers> customerList, int removedId)
        {
            try
            {
                foreach (Customers customer in customerList.Where(c => c.Id > removedId))
                {
                    customer.Id--;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
