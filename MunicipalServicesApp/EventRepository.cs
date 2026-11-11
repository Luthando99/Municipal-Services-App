
using System;
using System.Collections.Generic;
using MunicipalServicesApp.Models;

namespace MunicipalServicesApp
{
    public static class EventRepository
    {
        // ============================================
        // DATA STRUCTURES
        // ============================================

        // Stores events sorted by date.
        private static readonly SortedDictionary<DateTime, List<MunicipalEvent>>
            eventsByDate =
                new SortedDictionary<DateTime, List<MunicipalEvent>>();

        // Stores unique event categories.
        private static readonly HashSet<string> categories =
            new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        // Stores events in the order they were added.
        private static readonly Queue<MunicipalEvent> upcomingEvents =
            new Queue<MunicipalEvent>();

        // Tracks user interest in each category.
        private static readonly Dictionary<string, int>
            categorySearchHistory =
                new Dictionary<string, int>(
                    StringComparer.OrdinalIgnoreCase);


        // ============================================
        // PUBLIC PROPERTIES
        // ============================================

        public static SortedDictionary<DateTime, List<MunicipalEvent>>
            EventsByDate
        {
            get { return eventsByDate; }
        }

        public static HashSet<string> Categories
        {
            get { return categories; }
        }

        public static Queue<MunicipalEvent> UpcomingEvents
        {
            get { return upcomingEvents; }
        }

        // Allows the form to read category interests.
        // The form cannot modify the dictionary directly.
        public static IReadOnlyDictionary<string, int>
            CategorySearchHistory
        {
            get { return categorySearchHistory; }
        }


        // ============================================
        // RECORD CATEGORY INTEREST
        // ============================================

        public static void RecordCategoryInterest(string category)
        {
            if (string.IsNullOrWhiteSpace(category) ||
                category.Equals(
                    "All Categories",
                    StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            category = category.Trim();

            if (categorySearchHistory.ContainsKey(category))
            {
                categorySearchHistory[category]++;
            }
            else
            {
                categorySearchHistory[category] = 1;
            }
        }


        // ============================================
        // RECORD SEARCH INTEREST
        // ============================================

        public static void RecordSearchInterest(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                return;
            }

            string search = searchText.Trim();

            foreach (string category in categories)
            {
                bool categoryMatches =
                    category.IndexOf(
                        search,
                        StringComparison.OrdinalIgnoreCase) >= 0;

                bool eventMatches = false;

                foreach (var dateGroup in eventsByDate)
                {
                    foreach (MunicipalEvent municipalEvent
                             in dateGroup.Value)
                    {
                        if (!municipalEvent.Category.Equals(
                            category,
                            StringComparison.OrdinalIgnoreCase))
                        {
                            continue;
                        }

                        if (municipalEvent.Title.IndexOf(
                                search,
                                StringComparison.OrdinalIgnoreCase) >= 0 ||
                            municipalEvent.Description.IndexOf(
                                search,
                                StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            eventMatches = true;
                            break;
                        }
                    }

                    if (eventMatches)
                    {
                        break;
                    }
                }

                if (categoryMatches || eventMatches)
                {
                    RecordCategoryInterest(category);
                }
            }
        }


        // ============================================
        // ADD MUNICIPAL EVENT
        // ============================================

        public static void AddEvent(MunicipalEvent municipalEvent)
        {
            DateTime eventDate = municipalEvent.EventDate.Date;

            // Add event to the sorted dictionary.
            if (!eventsByDate.ContainsKey(eventDate))
            {
                eventsByDate[eventDate] =
                    new List<MunicipalEvent>();
            }

            eventsByDate[eventDate].Add(municipalEvent);

            // Add category to the unique-category set.
            categories.Add(municipalEvent.Category);

            // Add event to the queue.
            upcomingEvents.Enqueue(municipalEvent);
        }


        // ============================================
        // LOAD SAMPLE EVENTS
        // ============================================

        public static void LoadSampleEvents()
        {
            // Prevent duplicate sample events.
            if (eventsByDate.Count > 0)
            {
                return;
            }

            // Always generate future event dates.
            DateTime today = DateTime.Today;

            AddEvent(new MunicipalEvent(
                1,
                "Community Clean-Up Campaign",
                "Environment",
                today.AddDays(7),
                "Durban Central",
                "Residents are invited to participate " +
                "in a community clean-up campaign."
            ));

            AddEvent(new MunicipalEvent(
                2,
                "Municipal Career Expo",
                "Education",
                today.AddDays(14),
                "Durban City Hall",
                "A career expo providing information about " +
                "municipal careers and opportunities."
            ));

            AddEvent(new MunicipalEvent(
                3,
                "Community Soccer Tournament",
                "Sports",
                today.AddDays(21),
                "Kings Park Sports Grounds",
                "Local teams are invited to participate " +
                "in a community soccer tournament."
            ));

            AddEvent(new MunicipalEvent(
                4,
                "Water Conservation Workshop",
                "Community",
                today.AddDays(28),
                "Municipal Community Centre",
                "Residents can learn practical methods for " +
                "reducing household water consumption."
            ));

            AddEvent(new MunicipalEvent(
                5,
                "Recycling Awareness Day",
                "Environment",
                today.AddDays(35),
                "Durban Beachfront",
                "An awareness event promoting recycling " +
                "and responsible waste management."
            ));

            AddEvent(new MunicipalEvent(
                6,
                "Public Health Awareness Day",
                "Health",
                today.AddDays(42),
                "Community Health Centre",
                "A community programme promoting health " +
                "awareness and access to municipal services."
            ));
        }


        // ============================================
        // IDENTIFY PREFERRED CATEGORY
        // ============================================

        private static string GetPreferredCategory()
        {
            if (categorySearchHistory.Count == 0)
            {
                return null;
            }

            string preferredCategory = null;
            int highestCount = 0;

            foreach (KeyValuePair<string, int> entry
                     in categorySearchHistory)
            {
                if (entry.Value > highestCount)
                {
                    highestCount = entry.Value;
                    preferredCategory = entry.Key;
                }
            }

            return preferredCategory;
        }


        // ============================================
        // SMART EVENT RECOMMENDATION ALGORITHM
        // ============================================

        public static MunicipalEvent GetRecommendedEvent(
            string category)
        {
            MunicipalEvent bestEvent = null;
            int highestScore = int.MinValue;

            bool specificCategory =
                !string.IsNullOrWhiteSpace(category) &&
                !category.Equals(
                    "All Categories",
                    StringComparison.OrdinalIgnoreCase);

            foreach (var dateGroup in eventsByDate)
            {
                foreach (MunicipalEvent municipalEvent
                         in dateGroup.Value)
                {
                    // Do not recommend past events.
                    if (municipalEvent.EventDate.Date <
                        DateTime.Today)
                    {
                        continue;
                    }

                    int score = 0;

                    // 1. Reward previous category interests.
                    int interestCount;

                    if (categorySearchHistory.TryGetValue(
                        municipalEvent.Category,
                        out interestCount))
                    {
                        score += interestCount * 10;
                    }

                    // 2. Reward the currently selected category.
                    if (specificCategory &&
                        municipalEvent.Category.Equals(
                            category,
                            StringComparison.OrdinalIgnoreCase))
                    {
                        score += 30;
                    }

                    // 3. Prefer events happening sooner.
                    int daysUntilEvent =
                        (municipalEvent.EventDate.Date -
                         DateTime.Today).Days;

                    score += Math.Max(0, 20 - daysUntilEvent);

                    // 4. Keep the highest-scoring event.
                    if (score > highestScore)
                    {
                        highestScore = score;
                        bestEvent = municipalEvent;
                    }
                }
            }

            return bestEvent;
        }
    }
}
