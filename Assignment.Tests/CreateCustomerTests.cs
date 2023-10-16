using Assignment.Interfaces;
using Assignment.Models;
using Assignment.Services;
using System.Net;
using Xunit;

namespace Assignment.Tests.UnitTests;
public class CreateCustomerTests        // Skapar en ny öppen class 
{
    [Fact]
    public async Task CreateCustomerAsync_ShouldCreateCustomerToList_ReturnTrue()   // det vi testar är ifall  en skapad kundprofil skapas och sparas i listan 
    {
        // Arrange
        ICustomerService customerService = new CustomerService();               // Skapar ny instans av ICustomerService
        var customer = new Customer         //skapar en ny instans av Customer och skriver kontaktuppgifterna nedan
        {                                               // det är dessa uppgifter vi vill testa och se ifall de sparas eller inte.
            FirstName = "Ismail",
            LastName = "Abrahem",
            Email = "isse@gmail.com",
            PhoneNumber = "08123456",
            FullAddress = new Address
            {
                StreetName = "Vasagatan",
                StreetNumber = "2",
                ZipCode = "16373",
                City = "Spånga"
            }
        };


        //Act 
        await customerService.CreateCustomerAsync(customer);        // Under testets gång så kommer den att skapa kunden till listan


        // Assert
        var retrievedCustomer = customerService.GetOneCustomer(customer.Email); // Kunden hämtar man genom min GetOneCustomer funktion, och det sker med Email address

        Assert.NotNull(retrievedCustomer);                                      // kunden som hämtas ska inte vara null
        Assert.Equal(customer.FullName, retrievedCustomer.FullName);            // kunden som hämtas ska ha samm För- och Efternamn som kunden som har angetts ovan
        Assert.Equal(customer.Email, retrievedCustomer.Email);                  // Kunden som vi testar ska ha samma Email som kunden vi hämtar från den sparade listan
        Assert.Equal(customer.PhoneNumber, retrievedCustomer.PhoneNumber);      // kunden vi testar har samma telefonnummer som kunden vi hämtar från den sparade listan
        Assert.Equal(customer.FullAddress?.FullAddress, retrievedCustomer.FullAddress?.FullAddress); // Testar ifall kunden vi har angett har sparats och hämtas från listan
    }

}