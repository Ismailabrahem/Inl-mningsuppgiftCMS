using Assignmentmaui.Mvvm.ViewModels;
using Assignmentmaui.Mvvm.Views;
using Assignmentmaui.Services;
using Microsoft.Extensions.Logging;

namespace Assignmentmaui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<CustomerService>();

            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<MainPage>();

            builder.Services.AddTransient<CreateViewModel>();
            builder.Services.AddTransient<CreatePage>();

            builder.Services.AddTransient<EditViewModel>();
            builder.Services.AddTransient<EditPage>();

            builder.Services.AddTransient<DetailsViewModel>();
            builder.Services.AddTransient<DetailsPage>();


            return builder.Build();
        }
    }
}