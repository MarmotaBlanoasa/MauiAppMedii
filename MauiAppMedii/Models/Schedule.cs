using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;
namespace MauiAppMedii.Models
{
    public class Schedule
    {
        [PrimaryKey, AutoIncrement]
        public int ScheduleId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartHour { get; set; }
        public DateTime EndHour { get; set; }
        [ForeignKey(typeof(Event))]
        public int EventId { get; set; }
        [ManyToOne]
        public Event Event { get; set; }
    }
}
