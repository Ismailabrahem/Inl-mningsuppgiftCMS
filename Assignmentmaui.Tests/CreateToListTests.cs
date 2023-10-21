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
            // H�r skapar vi en kundprofil med specifika uppgifter som vi vill ska sparas till listan. customer �r en ny instans av Customer
             
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

            // customerService �r en instans av CustomerService, som kommer att trigga metoden CreateToList (ovann�mnda kund)    

            // Act 
            customerService.CreateToList(customer);

            // retrievedCustomer �r kunduppgifterna som vi h�mtar fr�n listan, med hj�lp av metoden GetOneFromList, som h�mtar kunden
            // med specifik kund.id
            
            // Assert
            var retrievedCustomer = customerService.GetOneFromList(x => x.Id == customer.Id);

            // H�r j�mf�r vi ifall kunduppgifterna som vi angav ovan �r detsamma som kunduppgifterna vi h�mtade fr�n listan.
            // Ifall det st�mmer, s� fungerar testet och �ven skapandet av ny kund.
            Assert.NotNull(retrievedCustomer);
            Assert.Equal(customer.FirstName, retrievedCustomer.FirstName);
            Assert.Equal(customer.LastName, retrievedCustomer.LastName);
            Assert.Equal(customer.Email, retrievedCustomer.Email);
    }

    // f�r att kunna k�ra testet, s� var jag tvungen att �ndra p� lite grejer i Assignmentmaui.csproj filen
    // Var tvungen att l�gga till net7.0 bland <TargetFrameworks>net7.0;net7.0-android;net7.0-ios;net7.0-maccatalyst</TargetFrameworks>
    // Dessutom, s� var jag tvungen att �ndra dessa nedan samt starta om:

    // <OutputType>Exe</OutputType> 

    // Till

    // <OutputType Condition="'$(TargetFramework)' != 'net7.0'">Exe</OutputType>
}
