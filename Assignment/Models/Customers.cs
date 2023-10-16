using Assignment.Interfaces;
using System.Net;

namespace Assignment.Models;

public class Customer : ICustomer
// Jag gör en public class med all nödvändig information för en kund
{                                            // ? i "string?" innebär att det kan vara null också, alltså inget.
    public DateTime Created { get; set; } = DateTime.Now;       // Anledningen till att jag har med datum/tid
                                                                // är för att när man visar alla kunder, så kan de senare visas
                                                                // de i den tidsordningen då kunderna har skapats

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public Address? FullAddress { get; set; } // Eftersom att Address består av stad, gatunamn och nummer samt postnummer
                                              // så skapades en egen class för att få dessa (Kolla Address.cs filen)

    public string? FullName => $"{FirstName} {LastName}"; // Denna skriver för- och efternamn som fullständig namn
}
