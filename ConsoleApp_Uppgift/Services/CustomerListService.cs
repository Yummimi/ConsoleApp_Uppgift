
using ConsoleApp_Uppgift.Models;
using ConsoleApp_Uppgift.Interfaces;
using System.Text.Json;
using System.Linq;

namespace ConsoleApp_Uppgift.Services
{
    public class CustomerListService : ICustomerListService
    {
        public string FilePath { get; private set; } // Creates a FilePath


        public CustomerListService()
        {
            FilePath = @"D:\School\Kurs_3_C#\ConsoleApp\ConsoleApp_Uppgift\customer.json";
        }

        /*
        LoadCustomerFromFile should load the customerlist and all it's customers from existing file located in "FilePath", it handles the deserialization proccess using json and StreamReader.
        It should then return the customerlist to see in our console application.
        If no file is found, it will create a new list/file.
        */
        public IEnumerable<Customers> LoadCustomersFromFile(string? filePath = null)
        {
            try
            {
                if (string.IsNullOrEmpty(filePath))
                {
                    filePath = FilePath;
                }

                if (File.Exists(filePath))
                {
                    string jsonData;
                    using (StreamReader? json = new StreamReader(filePath))
                    {
                        jsonData = json.ReadToEnd();
                    }
                    var customerList = JsonSerializer.Deserialize<List<Customers>>(jsonData);
                    return customerList!;
                }
                else
                {
                    return new List<Customers>();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return new List<Customers>();
            }
        }
        /*
        SaveCustomerToFile should get the customerlist and serialize it to json format, then save the list of customers to file within FilePath.
        */
        public void SaveCustomersToFile(List<Customers> _customerList)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(FilePath))
                {
                    string json = JsonSerializer.Serialize(_customerList);
                    streamWriter.WriteLine(json);
                }
            }

            catch (Exception ex)
            {
                    Console.WriteLine($"An error occurred: {ex.Message}");
            }

        }
    }
}
