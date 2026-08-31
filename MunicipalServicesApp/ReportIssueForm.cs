using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MunicipalServicesApp.Models;

namespace MunicipalServicesApp
{
    public partial class ReportIssueForm : Form
    {
        private string selectedFilePath = "";
        public ReportIssueForm()
        {
            InitializeComponent();
        }

        private void ReportIssueForm_Load(object sender, EventArgs e)
        {
            cmbCategory.Items.Add("Roads and Potholes");
            cmbCategory.Items.Add("Water and Sanitation");
            cmbCategory.Items.Add("Electricity");
            cmbCategory.Items.Add("Waste Collection");
            cmbCategory.Items.Add("Street Lights");
            cmbCategory.Items.Add("Traffic Lights");
            cmbCategory.Items.Add("Public Facilities");
            cmbCategory.Items.Add("Other");

            cmbCategory.SelectedIndex = -1;
            cmbCategory.Text = "Select a category";
        }

        private void btnAttachFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Select Supporting File";

            openFileDialog.Filter =
                "Supported Files|*.jpg;*.jpeg;*.png;*.pdf;*.doc;*.docx|" +
                "Image Files|*.jpg;*.jpeg;*.png|" +
                "PDF Files|*.pdf|" +
                "Word Documents|*.doc;*.docx|" +
                "All Files|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedFilePath = openFileDialog.FileName;

                lblAttachment.Text =
                    System.IO.Path.GetFileName(selectedFilePath);
            }

            UpdateProgress();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show(
                    "Please enter the location of the issue.",
                    "Missing Location",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtLocation.Focus();
                return;
            }

            if (cmbCategory.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select an issue category.",
                    "Missing Category",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                cmbCategory.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(rtbDescription.Text))
            {
                MessageBox.Show(
                    "Please provide a description of the issue.",
                    "Missing Description",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                rtbDescription.Focus();
                return;
            }

            Issue newIssue = new Issue
            {
                Location = txtLocation.Text.Trim(),
                Category = cmbCategory.SelectedItem.ToString(),
                Description = rtbDescription.Text.Trim(),
                AttachmentPath = selectedFilePath,
                DateReported = DateTime.Now
            };

            IssueRepository.Issues.Add(newIssue);

            

            MessageBox.Show(
                "Issue submitted successfully!\n\n" +
                "Total reports stored: " + IssueRepository.Issues.Count,
                "Report Submitted",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            txtLocation.Clear();
            cmbCategory.SelectedIndex = -1;
            rtbDescription.Clear();

            selectedFilePath = "";
            lblAttachment.Text = "No file selected";

            progressReport.Value = 0;

            txtLocation.Focus();
            lblEngagement.Text =
                    "Let's get started! Tell us where the issue is.";
        }

        private void UpdateProgress()
        {
            int progress = 0;

            if (!string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                progress += 25;
            }

            if (cmbCategory.SelectedIndex != -1)
            {
                progress += 25;
            }

            if (!string.IsNullOrWhiteSpace(rtbDescription.Text))
            {
                progress += 25;
            }

            if (!string.IsNullOrWhiteSpace(selectedFilePath))
            {
                progress += 25;
            }

            progressReport.Value = progress;

            if (progress == 0)
            {
                lblEngagement.Text =
                    "Let's get started! Tell us where the issue is.";
            }
            else if (progress == 25)
            {
                lblEngagement.Text =
                    "Great start! Now choose the type of issue.";
            }
            else if (progress == 50)
            {
                lblEngagement.Text =
                    "You're halfway there! Please describe the problem.";
            }
            else if (progress == 75)
            {
                lblEngagement.Text =
                    "Almost done! You may attach supporting evidence.";
            }
            else if (progress == 100)
            {
                lblEngagement.Text =
                    "Excellent! Your report is ready to submit.";
            }
        }

        private void txtLocation_TextChanged(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        private void rtbDescription_TextChanged(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
