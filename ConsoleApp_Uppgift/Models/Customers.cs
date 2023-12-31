
using ConsoleApp_Uppgift.Interfaces;
using System.Xml.Linq;

namespace ConsoleApp_Uppgift.Models
{
    public class Customers : ICustomers
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Address { get; set; } = null!;

    }
}
