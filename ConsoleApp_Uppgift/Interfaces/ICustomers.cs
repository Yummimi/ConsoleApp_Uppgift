namespace ConsoleApp_Uppgift.Interfaces
{
    public interface ICustomers
    {
        string Address { get; set; }
        string Email { get; set; }
        string Firstname { get; set; }
        int Id { get; set; }
        string Lastname { get; set; }
        string Phone { get; set; }
    }
}