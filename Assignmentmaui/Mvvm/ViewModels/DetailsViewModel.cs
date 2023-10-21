using Assignmentmaui.Mvvm.Models;
using Assignmentmaui.Mvvm.Views;
using Assignmentmaui.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Assignmentmaui.Mvvm.ViewModels;

public partial class DetailsViewModel : ObservableObject
{

    // tar emot instans av CustomerService tilldelar det till _customerService
    private readonly CustomerService _customerService;

    // en konstruktor som tar instans av CustomerService
    // Customer i dethär fallet använder sig av konstruktorn och den ny tilldelade _customerService för att binda sig till CurrentCustomer
    public DetailsViewModel(CustomerService customerService)
    {
        _customerService = customerService;
        Customer = _customerService.CurrentCustomer;
    }
        
    [ObservableProperty]
    Customer customer = new Customer();

    // kommando för att återgå till föregående sida, i det här fallet MainPage.
    [RelayCommand]
    public async Task Return()
    {
        await Shell.Current.GoToAsync($"..");
    }

    // kommando för att gå till EditPage sidan, där man kan ändra på kunduppgifter eller ta bort profilen.
    [RelayCommand]
    public async Task GoToEdit()
    {
        await Shell.Current.GoToAsync(nameof(EditPage));
    }

    // Denna kommando gör så att man kan radera en kundprofil. När man trycket på knappen för att radera
    // så kommer DisplayAlert med meddelandet , om man trycker på Yes så kommer kundprofilen med det specifika customer.Id
    // att raderas från listan. därefter går man tillbaks till föregående sida.
    [RelayCommand]
    public async Task Delete()
    {
        bool answer = await Application.Current.MainPage.DisplayAlert("Confirmation...", "Are you sure you want to delete this customer?", "Yes", "No");
        if (answer)
        {
            _customerService.DeleteOneFromList(customer => customer.Id == Customer.Id);
            await Shell.Current.GoToAsync("..");
        }
    }


}