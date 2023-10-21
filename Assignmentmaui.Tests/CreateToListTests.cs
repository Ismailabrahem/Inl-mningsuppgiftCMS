using Assignmentmaui.Mvvm.ViewModels;
using Assignmentmaui.Services;
using Assignmentmaui.Mvvm.Models;
using Assignmentmaui.Mvvm.Views;
namespace Assignmentmaui.Tests;


public class CreateToListTests        
{
    // Vi testar ifall en kundprofil skapas till listan 
    [Fact]
    public void CreateToList_ShouldCreateCustomerToList_ReturnTrue()
    {
            // Här skapar vi en kundprofil med specifika uppgifter som vi vill ska sparas till listan. customer är en ny instans av Customer
             
            // Arrange
            CustomerService customerService = new CustomerService();
            var customer = new Customer
            {
                FirstName = "Banan",
                LastName = "Skal",
                Email = "banan@gmail.com",
                PhoneNumber = "08123456",
                StreetName = "Banangatan",
                StreetNumber = "8",
                ZipCode = "16373",
                City = "Banan"
                
            };

            // customerService är en instans av CustomerService, som kommer att trigga metoden CreateToList (ovannämnda kund)    

            // Act 
            customerService.CreateToList(customer);

            // retrievedCustomer är kunduppgifterna som vi hämtar från listan, med hjälp av metoden GetOneFromList, som hämtar kunden
            // med specifik kund.id
            
            // Assert
            var retrievedCustomer = customerService.GetOneFromList(x => x.Id == customer.Id);

            // Här jämför vi ifall kunduppgifterna som vi angav ovan är detsamma som kunduppgifterna vi hämtade från listan.
            // Ifall det stämmer, så fungerar testet och även skapandet av ny kund.
            Assert.NotNull(retrievedCustomer);
            Assert.Equal(customer.FirstName, retrievedCustomer.FirstName);
            Assert.Equal(customer.LastName, retrievedCustomer.LastName);
            Assert.Equal(customer.Email, retrievedCustomer.Email);
    }

    // för att kunna köra testet, så var jag tvungen att ändra på lite grejer i Assignmentmaui.csproj filen
    // Var tvungen att lägga till net7.0 bland <TargetFrameworks>net7.0;net7.0-android;net7.0-ios;net7.0-maccatalyst</TargetFrameworks>
    // Dessutom, så var jag tvungen att ändra dessa nedan samt starta om:

    // <OutputType>Exe</OutputType> 

    // Till

    // <OutputType Condition="'$(TargetFramework)' != 'net7.0'">Exe</OutputType>
}
