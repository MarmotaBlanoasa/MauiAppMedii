using MauiAppMedii.ViewModels;

namespace MauiAppMedii;

public partial class CalendarPage : ContentPage
{
	public CalendarPage()
	{
		InitializeComponent();
        BindingContext = new CalendarViewModel();
    }
}