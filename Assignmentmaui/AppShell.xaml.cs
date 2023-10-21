using Assignmentmaui.Mvvm.Views;

namespace Assignmentmaui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(CreatePage), typeof(CreatePage));
            Routing.RegisterRoute(nameof(EditPage), typeof(EditPage));
            Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage));

        }
    }
}