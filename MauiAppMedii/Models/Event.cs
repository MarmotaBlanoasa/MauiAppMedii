using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;
namespace MauiAppMedii.Models
{
    public class Event
    {
        [PrimaryKey, AutoIncrement]
        public int EventId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Schedule> Schedules { get; set; } = new List<Schedule>();
    }
}
