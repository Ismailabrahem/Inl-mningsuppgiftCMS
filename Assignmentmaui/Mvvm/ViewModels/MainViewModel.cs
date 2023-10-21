using Assignmentmaui.Mvvm.Models;
using Assignmentmaui.Mvvm.Views;
using Assignmentmaui.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Assignmentmaui.Mvvm.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly CustomerService _customerService;

    // Här används UpdateCustomerList och Update för att uppdatera kundlistan så att alla ändringar finns med på nytt.
    public MainViewModel(CustomerService customerService)
    {
        _customerService = customerService;
        UpdateCustomerList();
        Update();
    }

    //Denna används för att se om ändringar sker i koden, i det här faller customers som är kundlistan.
    [ObservableProperty]
    ObservableCollection<Customer> customers = new ObservableCollection<Customer>();

    // Kommando som tar oss till CreatePage för att skapa en profil
    [RelayCommand]
    public async Task GoToCreate()
    {
        await Shell.Current.GoToAsync($"{nameof(CreatePage)}");
    }
 
    // Kommando som tar oss till DetailPage för att se en specifik profil/ ändra på uppgifter / radera profil.
    [RelayCommand]
    public async Task GoToDetail(Customer customer)
    {
        _customerService.CurrentCustomer = customer;
        await Shell.Current.GoToAsync(nameof(DetailsPage));
    }

    // Denna kommando använder sig av två funktioner, UpdateCustomerList som hjälper att uppdatera kundlistan 
    // När CustomerUpdated händelsen sker, så utlöses funktionen Update
    // Update metoden hämtar alla kunder från listan, tömmer den och skriver om kunderna på nytt med de ändringar
    // På så sätt får vi kundlistan på nytt, med alla ändringar

    [RelayCommand]
    private void UpdateCustomerList()
    {
        _customerService.CustomerUpdated += () =>
        {
            Update();
        };
    }

    private void Update()
    {
        var _customers = _customerService.GetAllFromList();
        Customers.Clear();
        foreach (var customer in _customers)
        {
            Customers.Add(customer);
        }
    }

}

