
using MunicipalServicesApp.Models;
using System;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class LocalEventsForm : Form
    {
        // Prevent programmatic category changes from
        // being recorded as user preferences.
        private bool suppressCategoryTracking = false;

        public LocalEventsForm()
        {
            InitializeComponent();

            EventRepository.LoadSampleEvents();

            LoadEvents();
            LoadCategories();
        }

        private void LoadEvents()
        {
            lstEvents.Items.Clear();

            foreach (var dateEntry in EventRepository.EventsByDate)
            {
                foreach (MunicipalEvent municipalEvent in dateEntry.Value)
                {
                    lstEvents.Items.Add(municipalEvent);
                }
            }
        }

        private void LoadCategories()
        {
            suppressCategoryTracking = true;

            try
            {
                cmbCategory.Items.Clear();
                cmbCategory.Items.Add("All Categories");

                foreach (string category in EventRepository.Categories)
                {
                    cmbCategory.Items.Add(category);
                }

                cmbCategory.SelectedIndex = 0;
            }
            finally
            {
                suppressCategoryTracking = false;
            }
        }

        private void lstEvents_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            if (lstEvents.SelectedItem is MunicipalEvent selectedEvent)
            {
                lblDetailTitle.Text =
                    "Title: " + selectedEvent.Title;

                lblDetailDate.Text =
                    "Date: " +
                    selectedEvent.EventDate.ToString("dd MMMM yyyy");

                lblDetailCategory.Text =
                    "Category: " + selectedEvent.Category;

                lblDetailLocation.Text =
                    "Location: " + selectedEvent.Location;

                lblDetailDescription.Text =
                    "Description: " + selectedEvent.Description;
            }
        }

        private void FilterEvents()
        {
            string searchText =
                txtSearch.Text.Trim().ToLowerInvariant();

            string selectedCategory =
                cmbCategory.SelectedItem != null
                ? cmbCategory.SelectedItem.ToString()
                : "All Categories";

            DateTime selectedDate = dtpEventDate.Value.Date;

            lstEvents.Items.Clear();

            foreach (var dateGroup in EventRepository.EventsByDate)
            {
                foreach (MunicipalEvent municipalEvent in dateGroup.Value)
                {
                    bool matchesSearch =
                        municipalEvent.Title.ToLowerInvariant()
                            .Contains(searchText) ||
                        municipalEvent.Category.ToLowerInvariant()
                            .Contains(searchText) ||
                        municipalEvent.Location.ToLowerInvariant()
                            .Contains(searchText) ||
                        municipalEvent.Description.ToLowerInvariant()
                            .Contains(searchText);

                    bool matchesCategory =
                        selectedCategory == "All Categories" ||
                        municipalEvent.Category == selectedCategory;

                    bool matchesDate =
                        !chkFilterDate.Checked ||
                        municipalEvent.EventDate.Date == selectedDate;

                    if (matchesSearch &&
                        matchesCategory &&
                        matchesDate)
                    {
                        lstEvents.Items.Add(municipalEvent);
                    }
                }
            }
        }

        private void txtSearch_TextChanged(
            object sender, EventArgs e)
        {
            FilterEvents();
        }

        private void txtSearch_KeyDown(
            object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EventRepository.RecordSearchInterest(
                    txtSearch.Text);

                e.SuppressKeyPress = true;
            }
        }

        private void cmbCategory_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            FilterEvents();

            if (!suppressCategoryTracking &&
                cmbCategory.SelectedItem != null)
            {
                string selectedCategory =
                    cmbCategory.SelectedItem.ToString();

                if (selectedCategory != "All Categories")
                {
                    EventRepository.RecordCategoryInterest(
                        selectedCategory);
                }
            }
        }

        private void btnRecommended_Click(
            object sender, EventArgs e)
        {
            string selectedCategory =
                cmbCategory.SelectedItem?.ToString();

            MunicipalEvent recommendedEvent =
                EventRepository.GetRecommendedEvent(
                    selectedCategory);

            if (recommendedEvent == null)
            {
                MessageBox.Show(
                    "No upcoming events are currently available.",
                    "No Recommendation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            // Find the user's recorded interest
            // in the recommended event category.
            int interestCount = 0;

            EventRepository.CategorySearchHistory.TryGetValue(
                recommendedEvent.Category,
                out interestCount);

            // Explain why this event was recommended.
            string reason;

            if (interestCount > 0)
            {
                reason =
                    "This event matches your previous searches " +
                    "and category interests.";
            }
            else if (!string.IsNullOrWhiteSpace(selectedCategory) &&
                     selectedCategory != "All Categories" &&
                     recommendedEvent.Category.Equals(
                         selectedCategory,
                         StringComparison.OrdinalIgnoreCase))
            {
                reason =
                    "This event matches your selected category " +
                    "and is scheduled for an upcoming date.";
            }
            else
            {
                reason =
                    "This event was recommended because " +
                    "it is scheduled for an upcoming date.";
            }

            // Clear filters so the recommended
            // event becomes visible.
            txtSearch.Clear();
            chkFilterDate.Checked = false;

            // Reset category without recording interest.
            suppressCategoryTracking = true;

            try
            {
                cmbCategory.SelectedIndex = 0;
            }
            finally
            {
                suppressCategoryTracking = false;
            }

            FilterEvents();

            // Highlight the recommended event.
            lstEvents.SelectedItem = recommendedEvent;

            // Display recommendation and explanation.
            MessageBox.Show(
                "RECOMMENDED FOR YOU!\n\n" +
                "Event: " + recommendedEvent.Title + "\n" +
                "Category: " + recommendedEvent.Category + "\n" +
                "Date: " +
                recommendedEvent.EventDate.ToString("dd MMMM yyyy") +
                "\n" +
                "Location: " + recommendedEvent.Location +
                "\n\n" +
                "Why this event?\n" + reason,
                "Smart Event Recommendation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void chkFilterDate_CheckedChanged(
            object sender, EventArgs e)
        {
            FilterEvents();
        }

        private void dtpEventDate_ValueChanged(
            object sender, EventArgs e)
        {
            if (chkFilterDate.Checked)
            {
                FilterEvents();
            }
        }

        private void btnBack_Click(
            object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
