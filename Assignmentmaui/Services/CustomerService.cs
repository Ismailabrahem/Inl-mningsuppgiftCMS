using Assignmentmaui.Mvvm.Models;
using Newtonsoft.Json;
using Assignmentmaui.Services;
using System.Diagnostics;
using System.Collections.Specialized;
using System.Linq.Expressions;

namespace Assignmentmaui.Services;
public class CustomerService

{   // Fildestination
    private readonly string savedFile = @"c:\Assignment\customers.json";

    // Skapar listan som håller koll på kundobjekt
    private List<Customer> _customerlist = new List<Customer>();

    // Håller reda på den nuvarande kunden
    public Customer CurrentCustomer { get; set; } = null!;

    // Denna händelse aktiveras när en kund uppdateras
    public event Action CustomerUpdated;

    // Kontruktorn använder sig av GetallFromList metoden, som uppdaterar listan
    public CustomerService()
    {
        GetAllFromList();
        CustomerUpdated += () =>
        {
            if (CurrentCustomer != null)
                UpdateCurrentCustomer(CurrentCustomer.Id);

        };
    }

    // Denna metod lägger till kund i listan, sparar listan i filen och sen uppdaterar.
    public void CreateToList(Customer customer)
    {
        _customerlist.Add(customer);
        FileService.SaveToFile(savedFile, JsonConvert.SerializeObject(_customerlist));
        CustomerUpdated.Invoke();
    }

    // Denna metod hämtar alla kunder från litan från en fil genom att läsa och konvertera
    // Json texten till läsbar text.
    public IEnumerable<Customer> GetAllFromList()
    {
        try
        {
            var customers = FileService.ReadFromFile(savedFile);
            if (!string.IsNullOrEmpty(customers))
            {
                _customerlist = JsonConvert.DeserializeObject<List<Customer>>(customers)!;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        return _customerlist;
    }


    // Denna metod söker och hämtar en specifik kund från listan baserat på expression delen,
    // I vårt fall kommer villkoren att vara i Mainpage där man kan trycka på en kund för att
    // trigga igång denna metod och hämta kunduppgifterna
    public Customer GetOneFromList(Func<Customer, bool> expression)
    {
        try
        {
            var customer = _customerlist.FirstOrDefault(expression);
            if (customer != null!)
                return customer;
        }
        catch (Exception ex) { Debug.Write(ex.Message); }
        return null;
    }

        // Denna metod används för att uppdater uppgifterna hos en kund
        // Genom att säga ifall gamla kunduppgiften inte är samma som den nya
        // och finns nån skillnad, så uppdateras informatonen, och därefter sparas till filen
        public Customer UpdateOneInList(Customer customer)
        {
            var _customer = _customerlist.FirstOrDefault(x => x.Id == customer.Id);
            if (_customer != null)
            {
                if (_customer.FirstName != customer.FirstName)
                    _customer.FirstName = customer.FirstName;
           
                if (_customer.LastName != customer.LastName)
                    _customer.LastName = customer.LastName;

                if (_customer.Email != customer.Email)
                    _customer.Email = customer.Email;

                if (_customer.PhoneNumber != customer.PhoneNumber)
                    _customer.PhoneNumber = customer.PhoneNumber;

                if (_customer.StreetName != customer.StreetName)
                    _customer.StreetName = customer.StreetName;

                if (_customer.StreetNumber != customer.StreetNumber)
                    _customer.StreetNumber = customer.StreetNumber;

                if (_customer.ZipCode != customer.ZipCode)
                    _customer.ZipCode = customer.ZipCode;

                if (_customer.City != customer.City)
                    _customer.City = customer.City;


                FileService.SaveToFile(savedFile, JsonConvert.SerializeObject(_customerlist));
                CustomerUpdated.Invoke();
                return _customer;
            }

            return null!;
        }


        // Denna metod raderar en kund från listan genom att använda sig av GetOneFromList,
        // Det vill säga att den hämtar en specifik kund, raderar den från listan
        // Och sedan sparar filen
        public bool DeleteOneFromList(Func<Customer, bool> expression)
    {
        var customer = GetOneFromList(expression);
        if (customer != null)
        {
            _customerlist.Remove(customer);
            FileService.SaveToFile(savedFile, JsonConvert.SerializeObject(_customerlist));
            CustomerUpdated.Invoke();
            return true;
        }

        return false;
    }

    // Denna metod används för att uppdatera den nuvarande kunden
    // som indentifieras med hjälp av Id
    private void UpdateCurrentCustomer(string id)
    {
        CurrentCustomer = GetOneFromList(x => x.Id == id);
    }

}




