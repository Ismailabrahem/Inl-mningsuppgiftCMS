using Assignmentmaui.Mvvm.ViewModels;
namespace Assignmentmaui.Mvvm.Views;
public partial class CreatePage : ContentPage
{
	public CreatePage(CreateViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}