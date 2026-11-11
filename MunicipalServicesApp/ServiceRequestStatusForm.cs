
using MunicipalServicesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class ServiceRequestStatusForm : Form
    {
        // Data structures used in Part 3
        private IssueBinarySearchTree issueTree =
            new IssueBinarySearchTree();

        private IssueAVLTree avlTree =
            new IssueAVLTree();

        private IssueMaxHeap issueHeap =
            new IssueMaxHeap();


        // Constructor
        public ServiceRequestStatusForm()
        {
            InitializeComponent();

            // Build the data structures
            BuildIssueTree();

            // Display submitted service requests
            LoadServiceRequests();

        }


        // Build BST, AVL Tree and Max-Heap

        private void BuildIssueTree()
        {
            issueTree = new IssueBinarySearchTree();
            avlTree = new IssueAVLTree();
            issueHeap = new IssueMaxHeap();

            foreach (Issue issue in IssueRepository.Issues)
            {
                // All requests remain searchable
                issueTree.Insert(issue);
                avlTree.Insert(issue);

                issue.Priority =
                    IssuePriorityHelper.GetPriority(issue.Category);

                // Only unresolved requests enter the priority heap
                if (!string.Equals(
                    issue.Status,
                    "Resolved",
                    StringComparison.OrdinalIgnoreCase))
                {
                    issueHeap.Insert(issue);
                }
            }
        }



        




        // Load all service requests into DataGridView
        private void LoadServiceRequests()
        {
            dgvRequests.DataSource = null;

            dgvRequests.DataSource =
                IssueRepository.Issues
                .Select(issue => new
                {
                    TrackingID = issue.TrackingID,
                    Category = issue.Category,
                    Location = issue.Location,
                    Status = issue.Status,
                    DateReported = issue.DateReported
                })
                .ToList();
        }


        // Display details of the selected request
        private void DisplayRequestDetails(Issue issue)
        {
            if (issue == null)
                return;

            lblTrackingID.Text =
                "Tracking ID: " + issue.TrackingID;

            lblCategory.Text =
                "Category: " + issue.Category;

            lblLocation.Text =
                "Location: " + issue.Location;

            lblStatus.Text =
                "Status: " + issue.Status;

            lblDateReported.Text =
                "Date Reported: " +
                issue.DateReported.ToString("dd MMM yyyy");

            txtDescription.Text = issue.Description;

            // Update progress according to status
            switch (issue.Status)
            {
                case "Pending":
                    progressStatus.Value = 25;
                    break;

                case "In Progress":
                    progressStatus.Value = 50;
                    break;

                case "Under Review":
                    progressStatus.Value = 75;
                    break;

                case "Resolved":
                    progressStatus.Value = 100;
                    break;

                default:
                    progressStatus.Value = 0;
                    break;
            }
        }


        // Back button
        private void btnBack_Click(
            object sender,
            EventArgs e)
        {
            this.Close();
        }


        // Select request from DataGridView
        private void dgvRequests_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            string trackingID =
                dgvRequests.Rows[e.RowIndex]
                .Cells["TrackingID"]
                .Value?.ToString();

            Issue selectedIssue =
                IssueRepository.Issues
                .FirstOrDefault(issue =>
                    issue.TrackingID == trackingID);

            DisplayRequestDetails(selectedIssue);
        }


        // Search for a service request using AVL Tree
        private void btnSearch_Click(
            object sender,
            EventArgs e)
        {
            string trackingID =
                txtSearch.Text.Trim();

            // Validate input
            if (string.IsNullOrWhiteSpace(trackingID))
            {
                MessageBox.Show(
                    "Please enter a Tracking ID.",
                    "Missing Tracking ID",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtSearch.Focus();
                return;
            }

            // Search using AVL Tree
            Issue foundIssue =
                avlTree.Search(trackingID);

            // Request not found
            if (foundIssue == null)
            {
                MessageBox.Show(
                    "No service request was found " +
                    "with this Tracking ID.",
                    "Request Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }

            // Display the matching request
            DisplayRequestDetails(foundIssue);

            // Highlight the matching row
            dgvRequests.ClearSelection();

            foreach (DataGridViewRow row
                in dgvRequests.Rows)
            {
                if (row.Cells["TrackingID"]
                    .Value?.ToString()
                    == foundIssue.TrackingID)
                {
                    row.Selected = true;

                    dgvRequests
                        .FirstDisplayedScrollingRowIndex =
                        row.Index;

                    break;
                }
            }
        }


        private void btnHighPriority_Click(object sender, EventArgs e)
        {
            // Rebuild the heap from the latest submitted requests
            BuildIssueTree();

            // Retrieve the highest-priority request
            Issue highest = issueHeap.Peek();

            if (highest == null)
            {
                MessageBox.Show(
                    "There are currently no service requests.",
                    "No Requests Available",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }

            // Display the selected request details
            DisplayRequestDetails(highest);

            // Highlight the matching request in the DataGridView
            dgvRequests.ClearSelection();

            foreach (DataGridViewRow row in dgvRequests.Rows)
            {
                if (row.Cells["TrackingID"].Value?.ToString()
                    == highest.TrackingID)
                {
                    row.Selected = true;

                    dgvRequests.FirstDisplayedScrollingRowIndex =
                        row.Index;

                    break;
                }
            }

            MessageBox.Show(
                "Highest Priority Service Request\n\n" +
                "Tracking ID: " + highest.TrackingID + "\n" +
                "Category: " + highest.Category + "\n" +
                "Priority: " +
                IssuePriorityHelper.GetPriorityName(highest.Priority),
                "Priority Request",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnNetworkAnalysis_Click(object sender, EventArgs e)
        {
            using (MunicipalNetworkForm networkForm =
                new MunicipalNetworkForm())
            {
                networkForm.ShowDialog(this);
            }
        }
    }
}
