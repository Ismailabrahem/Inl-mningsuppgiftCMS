using Assignmentmaui.Mvvm.ViewModels;
namespace Assignmentmaui.Mvvm.Views;
public partial class DetailsPage : ContentPage
{
    public DetailsPage(DetailsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private void Button_SizeChanged(object sender, EventArgs e)
    {

    }
}
