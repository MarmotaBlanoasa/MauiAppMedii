using System;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Maui.Controls;
using MauiAppMedii.Models;

namespace MauiAppMedii
{
    public partial class AddEventPage : ContentPage
    {

        public AddEventPage()
        {
            InitializeComponent();
           
        }


        private async void OnSaveEventClicked(object sender, EventArgs e)
        {
            var newEvent = new Event
            {
                Title = EventTitleEntry.Text,
                Description = EventDescriptionEditor.Text,
                StartDate = EventStartDatePicker.Date,
                EndDate = EventEndDatePicker.Date,
            };

            // Save the event and schedules to the database
            // Assuming you have a method in EventsTrakerDatabase to save the event and schedules
            var result = await App.Database.SaveEventAsync(newEvent);

            if (result > 0)
            {

                await DisplayAlert("Success", "Event added successfully", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                // Handle failure
                await DisplayAlert("Error", "Failed to add event", "OK");
            }
        }
    }
}
