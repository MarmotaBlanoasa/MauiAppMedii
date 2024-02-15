using MauiAppMedii.Models;
namespace MauiAppMedii;

public partial class EventDetailsPage : ContentPage
{
    private readonly Event _eventDetail;

    public EventDetailsPage(Event eventDetail)
    {
        InitializeComponent();
        _eventDetail = eventDetail;
        BindingContext = _eventDetail;
    }
    public void UpdateEventDetails(Event updatedEvent)
    {
        BindingContext = updatedEvent;
    }
    private async void OnDeleteEventClicked(object sender, EventArgs e)
    {
        bool isUserSure = await DisplayAlert("Delete Event",
                                             "Are you sure you want to delete this event?",
                                             "Yes", "No");
        if (isUserSure)
        {
            await App.Database.DeleteEventAsync(_eventDetail);
            await Navigation.PopAsync();
        }
    }
    private async void OnEditClicked(object sender, EventArgs e)
    {
        var eventToEdit = (Event)BindingContext;
        var editPage = new EditEventPage(eventToEdit)
        {
            EventUpdatedCallback = UpdateEventDetails
        };
        await Navigation.PushAsync(editPage);
    }

}
