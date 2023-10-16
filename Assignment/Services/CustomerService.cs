using Assignment.Interfaces;
using Assignment.Models;
using Newtonsoft.Json;
using System.ComponentModel.Design;

namespace Assignment.Services;

public class CustomerService : ICustomerService
{
    private List<Customer> _customers = new List<Customer>(); // skapar ny privat lista där man kan lagra och hantera datan för kunder


    public async Task CreateCustomerAsync(Customer customer)

    {
        _customers.Add(customer);
        await FileService.SaveToFileAsync(JsonConvert.SerializeObject(_customers));

    } // Skapar en kund, och sedan sparar kundens uppgifter till en jsonfil. Denna konverterar texten vi får till Json filen och lagrar den där.
      // async/await hjälper lagra uppgifterna till filen med en typ av timer, så att de sparas automatiskt

    public async Task DeleteOneCustomerAsync(string email)
    {

        var content = FileService.ReadFromFile();               // här får vi profilerna från filen
        if (_customers.Count == 0)                              // ifall inga kunder finns i kundfilen, så kommer meddelandet "There are no customers"
        {
            Console.WriteLine("There are no customers");
        }
        else
        {
            var removeCustomer = _customers.FirstOrDefault(c => c.Email == email);       // annars så raderasen en specifik kundprofil från filen 
            if (removeCustomer != null)                                                  // i samband med andra funktioner från FileService och MenuService
            {
                _customers.Remove(removeCustomer);                                          // här raderas kunden
                await FileService.SaveToFileAsync(JsonConvert.SerializeObject(_customers)); // efter att kunden har raderats, så sparas filen med en async/await funktion

            }
            else
            {
                Console.WriteLine("This customer can not be found");        // om man anger "email" som inte finns i filen, så får man detta meddelande
            }
        }   // Denna kod hjälper att radera en specifik kund med hjälp av "email". denna "email" är email som anges av kunden i konsolappen,
            // Med hjälp av detta så raderas. 

    }
    public IEnumerable<Customer> GetAllCustomers()          // hämtar alla kundprofiler från filen
    {

        var content = FileService.ReadFromFile();           // här får man tillgång till filen och kan läsa profilerna
        if (!string.IsNullOrEmpty(content))                 // om filen inte är tom VV
        {
            _customers = JsonConvert.DeserializeObject<List<Customer>>(content)!;   // Så konverteras allt i filen till en lista av kunder
        }

        return _customers.OrderByDescending(customers => customers.Created);    // den listan av kunder som vi får kommer att returneras i ordning efter när de skapades
    }

    public Customer GetOneCustomer(string email)                                            // hämta en specifik kund med angiven email
    {
        var content = FileService.ReadFromFile();                                           // funktion för att kunna läsa från json.filen
        if (!string.IsNullOrEmpty(content))                                                 // om filen inte är tom, 
        {
            _customers = JsonConvert.DeserializeObject<List<Customer>>(content)!;           //konvertera texten i json.filen till en kundlista, förväntas inte vara null
        }

        var customer = _customers.FirstOrDefault(x => x.Email == email);            // hämta kund som har samma email som den angivna

        if (customer == null)                                                   // om kunden inte finns
        {
            Console.WriteLine("Customer not found.");                       // skrivs detta meddelande
        }

        return customer!;                                           // annars skrivs kundprofilen ut
    }


}