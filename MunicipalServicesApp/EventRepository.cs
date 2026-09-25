using System;
using System.Collections.Generic;
using MunicipalServicesApp.Models;

namespace MunicipalServicesApp
{
    public static class EventRepository
    {
        // Stores events automatically sorted by date
        private static readonly SortedDictionary<DateTime, List<MunicipalEvent>>
            eventsByDate = new SortedDictionary<DateTime, List<MunicipalEvent>>();

        // Stores unique event categories
        private static readonly HashSet<string>
            categories = new HashSet<string>();

        // Stores upcoming events in the order they were added
        private static readonly Queue<MunicipalEvent>
            upcomingEvents = new Queue<MunicipalEvent>();

        // Tracks how often the user shows interest in each event category
        private static readonly Dictionary<string, int>
            categorySearchHistory = new Dictionary<string, int>(
                StringComparer.OrdinalIgnoreCase);

        // Gives other parts of the application access to the events
        public static SortedDictionary<DateTime, List<MunicipalEvent>> EventsByDate
        {
            get { return eventsByDate; }
        }

        // Gives access to the unique categories
        public static HashSet<string> Categories
        {
            get { return categories; }
        }

        // Gives access to the upcoming-events queue
        public static Queue<MunicipalEvent> UpcomingEvents
        {
            get { return upcomingEvents; }
        }

        // Records the user's interest in an event category
        public static void RecordCategoryInterest(string category)
        {
            // Ignore empty values and All Categories
            if (string.IsNullOrWhiteSpace(category) ||
                category == "All Categories")
            {
                return;
            }

            // Increase the count if the category already exists
            if (categorySearchHistory.ContainsKey(category))
            {
                categorySearchHistory[category]++;
            }
            else
            {
                // First time the user has shown interest in this category
                categorySearchHistory[category] = 1;
            }
        }

        // Adds an event to the required data structures
        public static void AddEvent(MunicipalEvent municipalEvent)
        {
            DateTime eventDate = municipalEvent.EventDate.Date;

            // Add the event to the SortedDictionary
            if (!eventsByDate.ContainsKey(eventDate))
            {
                eventsByDate[eventDate] = new List<MunicipalEvent>();
            }

            eventsByDate[eventDate].Add(municipalEvent);

            // HashSet automatically prevents duplicate categories
            categories.Add(municipalEvent.Category);

            // Add the event to the upcoming-events queue
            upcomingEvents.Enqueue(municipalEvent);
        }

        // Loads sample municipal events into the application
        public static void LoadSampleEvents()
        {
            // Prevent duplicate sample events if this method is called again
            if (eventsByDate.Count > 0)
            {
                return;
            }

            AddEvent(new MunicipalEvent(
                1,
                "Community Clean-Up Campaign",
                "Environment",
                new DateTime(2026, 10, 3),
                "Durban Central",
                "Residents are invited to participate in a community clean-up campaign."
            ));

            AddEvent(new MunicipalEvent(
                2,
                "Municipal Career Expo",
                "Education",
                new DateTime(2026, 10, 10),
                "Durban City Hall",
                "A career expo providing information about municipal careers and opportunities."
            ));

            AddEvent(new MunicipalEvent(
                3,
                "Community Soccer Tournament",
                "Sports",
                new DateTime(2026, 10, 17),
                "Kings Park Sports Grounds",
                "Local teams are invited to participate in a community soccer tournament."
            ));

            AddEvent(new MunicipalEvent(
                4,
                "Water Conservation Workshop",
                "Community",
                new DateTime(2026, 10, 24),
                "Municipal Community Centre",
                "Residents can learn practical methods for reducing household water consumption."
            ));

            AddEvent(new MunicipalEvent(
                5,
                "Recycling Awareness Day",
                "Environment",
                new DateTime(2026, 10, 31),
                "Durban Beachfront",
                "An awareness event promoting recycling and responsible waste management."
            ));

            AddEvent(new MunicipalEvent(
                6,
                "Public Health Awareness Day",
                "Health",
                new DateTime(2026, 11, 7),
                "Community Health Centre",
                "A community programme promoting health awareness and access to municipal services."
            ));
        }

        // Determines which category the user has shown the most interest in
        private static string GetPreferredCategory()
        {
            if (categorySearchHistory.Count == 0)
            {
                return null;
            }

            string preferredCategory = null;
            int highestCount = 0;

            foreach (KeyValuePair<string, int> entry in categorySearchHistory)
            {
                if (entry.Value > highestCount)
                {
                    highestCount = entry.Value;
                    preferredCategory = entry.Key;
                }
            }

            return preferredCategory;
        }

        public static MunicipalEvent GetRecommendedEvent(string category)
        {
            List<MunicipalEvent> possibleEvents = new List<MunicipalEvent>();

            string categoryToUse = category;

            // If no specific category is currently selected,
            // use the category the user has shown the most interest in
            if (string.IsNullOrWhiteSpace(category) ||
                category == "All Categories")
            {
                string preferredCategory = GetPreferredCategory();

                if (!string.IsNullOrWhiteSpace(preferredCategory))
                {
                    categoryToUse = preferredCategory;
                }
            }

            // Search through events in date order
            foreach (KeyValuePair<DateTime, List<MunicipalEvent>> entry in eventsByDate)
            {
                foreach (MunicipalEvent municipalEvent in entry.Value)
                {
                    // Only consider upcoming events
                    if (municipalEvent.EventDate.Date >= DateTime.Today)
                    {
                        bool matchesCategory =
                            string.IsNullOrWhiteSpace(categoryToUse) ||
                            categoryToUse == "All Categories" ||
                            municipalEvent.Category.Equals(
                                categoryToUse,
                                StringComparison.OrdinalIgnoreCase);

                        if (matchesCategory)
                        {
                            possibleEvents.Add(municipalEvent);
                        }
                    }
                }
            }

            if (possibleEvents.Count == 0)
            {
                return null;
            }

            // Randomly select from events that match the user's preference
            Random random = new Random();

            int index = random.Next(possibleEvents.Count);

            return possibleEvents[index];
        }
    }
}