using MunicipalServicesApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class LocalEventsForm : Form
    {
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
            cmbCategory.Items.Clear();

            cmbCategory.Items.Add("All Categories");

            foreach (string category in EventRepository.Categories)
            {
                cmbCategory.Items.Add(category);
            }

            cmbCategory.SelectedIndex = 0;
        }

        private void lstEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstEvents.SelectedItem is MunicipalEvent selectedEvent)
            {
                lblDetailTitle.Text = "Title: " + selectedEvent.Title;
                lblDetailDate.Text = "Date: " + selectedEvent.EventDate.ToString("dd MMMM yyyy");
                lblDetailCategory.Text = "Category: " + selectedEvent.Category;
                lblDetailLocation.Text = "Location: " + selectedEvent.Location;
                lblDetailDescription.Text = "Description: " + selectedEvent.Description;
            }
        }

        private void FilterEvents()
        {
            string searchText = txtSearch.Text.Trim().ToLower();

            string selectedCategory = cmbCategory.SelectedItem != null
                ? cmbCategory.SelectedItem.ToString()
                : "All Categories";

            DateTime selectedDate = dtpEventDate.Value.Date;

            lstEvents.Items.Clear();

            foreach (var dateGroup in EventRepository.EventsByDate)
            {
                foreach (MunicipalEvent municipalEvent in dateGroup.Value)
                {
                    // Check whether the event matches the search text
                    bool matchesSearch =
                        municipalEvent.Title.ToLower().Contains(searchText) ||
                        municipalEvent.Category.ToLower().Contains(searchText) ||
                        municipalEvent.Location.ToLower().Contains(searchText) ||
                        municipalEvent.Description.ToLower().Contains(searchText);

                    // Check whether the event matches the selected category
                    bool matchesCategory =
                        selectedCategory == "All Categories" ||
                        municipalEvent.Category == selectedCategory;

                    // Check whether the event matches the selected date.
                    // If Filter by Date is NOT checked, all dates are accepted.
                    bool matchesDate =
                        !chkFilterDate.Checked ||
                        municipalEvent.EventDate.Date == selectedDate;

                    // Event must satisfy all active filters
                    if (matchesSearch && matchesCategory && matchesDate)
                    {
                        lstEvents.Items.Add(municipalEvent);
                    }
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterEvents();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterEvents();

            if (cmbCategory.SelectedItem != null)
            {
                string selectedCategory = cmbCategory.SelectedItem.ToString();

                EventRepository.RecordCategoryInterest(selectedCategory);
            }
        }

        private void btnRecommended_Click(object sender, EventArgs e)
        {
            string selectedCategory = cmbCategory.SelectedItem?.ToString();

            MunicipalEvent recommendedEvent =
                EventRepository.GetRecommendedEvent(selectedCategory);

            if (recommendedEvent == null)
            {
                MessageBox.Show(
                    "No upcoming events are available for this category.",
                    "No Recommendation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            // Make sure the recommended event is visible in the list
            cmbCategory.SelectedItem = "All Categories";
            txtSearch.Clear();

            LoadEvents();

            // Select the recommended event
            lstEvents.SelectedItem = recommendedEvent;

            MessageBox.Show(
                "We found an event you may be interested in!\n\n" +
                recommendedEvent.Title + "\n" +
                recommendedEvent.EventDate.ToString("dd MMMM yyyy") + "\n" +
                recommendedEvent.Location,
                "Recommended Event",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void chkFilterDate_CheckedChanged(object sender, EventArgs e)
        {
            FilterEvents();
        }

        private void dtpEventDate_ValueChanged(object sender, EventArgs e)
        {
            if (chkFilterDate.Checked)
            {
                FilterEvents();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
