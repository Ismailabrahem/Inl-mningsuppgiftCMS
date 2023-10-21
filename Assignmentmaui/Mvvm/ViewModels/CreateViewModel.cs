using Assignmentmaui.Mvvm.Models;
using Assignmentmaui.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignmentmaui.Mvvm.ViewModels
{   
    public partial class CreateViewModel : ObservableObject

    {   // här lagras instansen av CustomerService
        private readonly CustomerService _customerService;

        // med hjälp av instansen, så skapas en konstruktor som sätter igång CreateViewModel 
        public CreateViewModel(CustomerService customerService)
        {
            _customerService = customerService;
        }

        // används för att hålla reda på förändringar i kunden/profiler automatiskt.
        [ObservableProperty]
        Customer customer = new Customer();

        // kommando som gör att när den sätts igång så skapas en kund till listan, och så återgår man  till förra sida.
        [RelayCommand]
            public async Task Save()
            {  
                _customerService.CreateToList(Customer);        
                await Shell.Current.GoToAsync($"..");
            }

        // Denna kommando gör så att man återgår till förra sida. I detta fall MainPage.
        [RelayCommand]
        async Task Return()
        {
            await Shell.Current.GoToAsync($"..");
        }
    }
}
    

