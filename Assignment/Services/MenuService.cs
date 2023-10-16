using Assignment.Interfaces;
using Assignment.Models;
using System.Collections.Immutable;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;

namespace Assignment.Services;

public class MenuService
{

    private static readonly ICustomerService customerService = new CustomerService();   // använder oss av genomsnittet för att skapa ny instans CustomerService 

    public static void CreateCustomerMenu()    // för att skapa en kund
    {
        Customer customer = new Customer();                         //för att få en kund från angiven text i konsol-appen så skapar vi en ny instans av klassen Customer

        Console.Write("Vänligen ange ditt Förnamn: ");              // Meddelande som skrivs till kunden
        customer.FirstName = Console.ReadLine();                    // det kunden skriver in som first name
        Console.Write("Vänligen ange ditt Efternamn: ");          //Hela vägen ner det är samma, att kunden först får ett meddelande sen anger svar på dessa egenskaper
        customer.LastName = Console.ReadLine();
        Console.Write("Vänligen ange din E-postadress: ");
        customer.Email = Console.ReadLine();
        Console.Write("Vänligen ange ditt nummer: ");
        customer.PhoneNumber = Console.ReadLine();


        customer.FullAddress = new Address();
        Console.Write("Vänligen ange ditt gatunamn: ");
        customer.FullAddress.StreetName = Console.ReadLine();
        Console.Write("Vänligen ange ditt gatunummer: ");
        customer.FullAddress.StreetNumber = Console.ReadLine();
        Console.Write("Vänligen ange ditt postnummer: ");
        customer.FullAddress.ZipCode = Console.ReadLine();
        Console.Write("Vänligen ange vilken ort du bor på: ");
        customer.FullAddress.City = Console.ReadLine();



        Task.Run(() => customerService.CreateCustomerAsync(customer));
        /* Eftersom att vi använder oss av async/await, så kommer vår kundprofil att sparas till filen men med en delay. Denna delay gör så att 
            profilen sparas automatiskt, fast under tiden profilen sparas så kan man inte göra något annat. Med hjälp av Task.Run så kan man göra annat
            under tiden som en kundprofil sparas
         */
    }


    public static void GetAllCustomersMenu()                // funktion för att hämta alla kundprofiler från json.filen
    {
        var customers = customerService.GetAllCustomers();      // kopplar customers till funktionerna vi har angett i CustomerService

        if (customers.Any())                        // Om vi har kunder
        {
            foreach (var customer in customers)         // för varje kund så skrivs nedanstående egenskaper ut från json.filen till konsolappen
            {
                Console.WriteLine($"{customer.FullName} {customer.Email} {customer.PhoneNumber} {customer?.FullAddress?.FullAddress}");
            }
        }
        else
        {
            Console.WriteLine("There are no customers");            // annars så kommer "there are no customers" att visas, ifall inga kundprofiler finns i filen
        }


    }


    public static void GetOneCustomerMenu()                         // ungefär detsamma som att hämta alla, fast lite skillnad 
    {
        Console.Write("Vänligen ange din E-postadress: ");          // här anger man email som är kopplat till profilen man vill raderna
        var email = Console.ReadLine();                         // det email som anges kommer att vara kopplat till "email"

        var customer = customerService.GetOneCustomer(email!);      // nu kopplar vi det angivna mailet till funktionerna i CustomerService

        if (customer != null)                                       // om kunden inte är null, så anges nedanstående uppgifter för den angivna profilen
        {
            Console.WriteLine($"{customer.FullName} {customer.Email} {customer.PhoneNumber} {customer?.FullAddress?.FullAddress}");
        }
    }



    public static void DeleteOneCustomerMenu()                              //Det samma som ovanstående, fast att efter man raderar en profil
    {                                                                           // så sparas filen, eftersom att man ändrar på filen
        Console.Write("Vänligen ange din E-postadress: ");
        var email = Console.ReadLine();
        Task.Run(() => customerService.DeleteOneCustomerAsync(email!));
    }

    public static void MainMenu()           // Denna meny är vad man kommer att se såfort man får upp konsolapplikationen
    {
        do
        {
            Console.Clear();
            Console.WriteLine("1. Skapa ny kund ");                             // man skriver ner alla alternativ som man har användning av
            Console.WriteLine("2. Visa alla kunder ");
            Console.WriteLine("3. Visa en specifik kund ");
            Console.WriteLine("4. Radera en specifik kund ");
            Console.WriteLine("0. Avsluta ");
            Console.WriteLine("Var vänligen och välj ett alternativ: ");
            var option = Console.ReadLine();            // denna kod kopplas till switch alternativet nedan, som kommer att leda till vad som kommer att ske


            Console.Clear();

            switch (option)
            {
                case "1":                                       // väljer man att skapa en ny kund, så kommer man att skickas vidare till sidan där man skapar kundprofilen
                    MenuService.CreateCustomerMenu();               // det samma gäller alla 4 alternativ
                    break;

                case "2":
                    MenuService.GetAllCustomersMenu();
                    break;

                case "3":
                    MenuService.GetOneCustomerMenu();
                    break;

                case "4":
                    MenuService.DeleteOneCustomerMenu();
                    break;

                case "0":
                    Environment.Exit(0);                    // för att avsluta programmet, så knappar man in "0" och så avslutas applikationen
                    break;

            }

            Console.ReadKey();

        } while (true);
    }
}

