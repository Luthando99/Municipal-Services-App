using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalServicesApp.Models
{
    public class MunicipalEvent
    {
        // Unique identifier for the event
        public int EventId { get; set; }

        // Name of the event
        public string Title { get; set; }

        // Category such as Community, Sports or Education
        public string Category { get; set; }

        // Date on which the event will take place
        public DateTime EventDate { get; set; }

        // Location where the event will take place
        public string Location { get; set; }

        // Additional information about the event
        public string Description { get; set; }

        // Constructor
        public MunicipalEvent(
            int eventId,
            string title,
            string category,
            DateTime eventDate,
            string location,
            string description)
        {
            EventId = eventId;
            Title = title;
            Category = category;
            EventDate = eventDate;
            Location = location;
            Description = description;
        }

        // Controls how an event is displayed when added to a ListBox
        public override string ToString()
        {
            return $"{EventDate:dd MMM yyyy} - {Title} - {Category} - {Location}";
        }
    }
}
