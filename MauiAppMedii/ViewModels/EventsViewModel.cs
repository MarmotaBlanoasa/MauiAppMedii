using System.Collections.ObjectModel;
using MauiAppMedii.Models;
using MauiAppMedii;
using System.Diagnostics;

public class EventsViewModel
{
    internal ObservableCollection<Event> Events { get; set; }

    public EventsViewModel()
    {
        Events = new ObservableCollection<Event>();
        LoadEvents();
    }

    private async void LoadEvents()
    {
        var eventsList = await App.Database.GetEventsAsync();
        Debug.WriteLine($"Events count: {eventsList.Count}");
        foreach (var evt in eventsList)
        {
            Events.Add(evt);
        }
    }
}
