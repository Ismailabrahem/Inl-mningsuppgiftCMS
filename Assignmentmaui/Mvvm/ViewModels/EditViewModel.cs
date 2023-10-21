using Assignmentmaui.Mvvm.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Assignmentmaui.Services;

namespace Assignmentmaui.Mvvm.ViewModels;
// Samma saker för både Create- och DetailsViewmodel, fast skriver om de så att de passar vår EditViewModel.
public partial class EditViewModel : ObservableObject
{
    private readonly CustomerService _customerService;
    public EditViewModel(CustomerService customerService)
    {
        _customerService = customerService;
        Customer = _customerService.CurrentCustomer;
    }


    [ObservableProperty]
    Customer customer = new Customer();

    // Denna kommando kommer istället att spara de nya kundinformationerna och återgå till MainPage iställer för föregående sida (DetailPage) för att se
    // se att kundinformationen har ändrats, och kunna se resterande kunder i listan.
    [RelayCommand]
    public async Task Save()
    {
        _customerService.UpdateOneInList(Customer);
        await Shell.Current.GoToAsync($"../..");
    }


    [RelayCommand]
    public async Task Return()
    {
        await Shell.Current.GoToAsync($"..");
    }

}
