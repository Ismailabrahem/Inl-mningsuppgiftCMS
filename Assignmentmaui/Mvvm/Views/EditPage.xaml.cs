using Assignmentmaui.Mvvm.ViewModels;
namespace Assignmentmaui.Mvvm.Views;
public partial class EditPage : ContentPage
{
    public EditPage(EditViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}