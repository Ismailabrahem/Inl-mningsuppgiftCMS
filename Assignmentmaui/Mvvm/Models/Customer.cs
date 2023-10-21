namespace Assignmentmaui.Mvvm.Models;

public class Customer
{ // skapar en class för kund information. Lägger till Id så att de går att skilja mellan
  // kunderna när man ska in i kundprofilen och t.ex radera eller ändra osv.
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string StreetName { get; set; } = null!;
    public string StreetNumber { get; set; } = null!;
    public string City { get; set; } = null!;
    public string ZipCode { get; set; } = null!;
}
