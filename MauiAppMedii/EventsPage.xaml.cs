using MauiAppMedii.Models;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MauiAppMedii;

public partial class EventsPage : ContentPage, INotifyPropertyChanged
{
    private DateTime _selectedDate = DateTime.Today;
    public DateTime SelectedDate
    {
        get => _selectedDate;
        set
        {
            if (_selectedDate != value)
            {
                _selectedDate = value;
                OnPropertyChanged(nameof(SelectedDate));
                PopulateEventList();
            }
        }
    }
    public ObservableCollection<Event> Events { get; set; }
    public EventsPage()
    {
        Events = new ObservableCollection<Event>();
        InitializeComponent();
        BindingContext = this;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        PopulateEventList();
    }


    private async void PopulateEventList()
    {
        Events.Clear();
        var events = await App.Database.GetEventsAsync();
        foreach (var evt in events)
        {
            if (evt.StartDate.Date == SelectedDate.Date)
            {
                Events.Add(evt);
            }
            
        }
    }

    private async void OnAddEventClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddEventPage());
    }
    private async void OnEventSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Event selectedEvent)
        {
            await Navigation.PushAsync(new EventDetailsPage(selectedEvent));
        }

    // Deselect the item
    ((CollectionView)sender).SelectedItem = null;
    }
    private void OnPreviousDayClicked(object sender, EventArgs e)
    {
        SelectedDate = SelectedDate.AddDays(-1);
    }

    private void OnNextDayClicked(object sender, EventArgs e)
    {
        SelectedDate = SelectedDate.AddDays(1);
    }
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
