using Assignmentmaui.Mvvm.ViewModels;
namespace Assignmentmaui.Mvvm.Views;
public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

}

