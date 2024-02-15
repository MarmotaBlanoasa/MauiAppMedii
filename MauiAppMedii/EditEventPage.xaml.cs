using MauiAppMedii.Models;
namespace MauiAppMedii;

public partial class EditEventPage : ContentPage
{
    public Action<Event>? EventUpdatedCallback { get; set; }
    public EditEventPage(Event eventToEdit)
	{
		InitializeComponent();
        BindingContext = eventToEdit;
    }
    private async void OnSaveChangesClicked(object sender, EventArgs e)
    {
        var eventToSave = (Event)BindingContext;
        await App.Database.SaveEventAsync(eventToSave);
        EventUpdatedCallback?.Invoke(eventToSave);
        await Navigation.PushAsync(new EventsPage());
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}