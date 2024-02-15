using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiAppMedii.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MauiAppMedii.ViewModels
{
    public class CalendarViewModel : INotifyPropertyChanged
    {
        public ICommand PreviousDayCommand { get; }
        public ICommand NextDayCommand { get; }
        private DateTime _selectedDate = DateTime.Today;
        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                OnPropertyChanged();
                LoadEventsForSelectedDate();
            }
        }

        public ObservableCollection<Event> EventsForSelectedDate { get; } = new ObservableCollection<Event>();

        public event PropertyChangedEventHandler PropertyChanged;

        public CalendarViewModel()
        {
            LoadEventsForSelectedDate();
            PreviousDayCommand = new Command(() => SelectedDate = SelectedDate.AddDays(-1));
            NextDayCommand = new Command(() => SelectedDate = SelectedDate.AddDays(1));
        }

        private async void LoadEventsForSelectedDate()
        {
            // Simulate loading events for the selected date.
            // Replace this with your actual data loading logic.
            EventsForSelectedDate.Clear();
            var events = await App.Database.GetEventsAsync();
            foreach (var evt in events)
            {
                if (evt.StartDate.Date == SelectedDate.Date)
                {
                    EventsForSelectedDate.Add(evt);
                }
            }
            //EventsForSelectedDate.Add(new Event { Title = $"Event on {SelectedDate.ToShortDateString()}", StartDate = SelectedDate, EndDate = SelectedDate });
            // Add more events as needed.
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
