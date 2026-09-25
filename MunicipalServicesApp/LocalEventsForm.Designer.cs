namespace MunicipalServicesApp
{
    partial class LocalEventsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblHeading = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblUpcomingEvents = new System.Windows.Forms.Label();
            this.lstEvents = new System.Windows.Forms.ListBox();
            this.lblEventDetailsHeading = new System.Windows.Forms.Label();
            this.grpEventDetails = new System.Windows.Forms.GroupBox();
            this.lblDetailDescription = new System.Windows.Forms.Label();
            this.lblDetailLocation = new System.Windows.Forms.Label();
            this.lblDetailCategory = new System.Windows.Forms.Label();
            this.lblDetailDate = new System.Windows.Forms.Label();
            this.lblDetailTitle = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnRecommended = new System.Windows.Forms.Button();
            this.dtpEventDate = new System.Windows.Forms.DateTimePicker();
            this.chkFilterDate = new System.Windows.Forms.CheckBox();
            this.pnlHeader.SuspendLayout();
            this.grpEventDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.MidnightBlue;
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblHeading);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(982, 150);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblSubtitle.Location = new System.Drawing.Point(304, 104);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(380, 25);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Discover what\'s happening in your community";
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.BackColor = System.Drawing.Color.Transparent;
            this.lblHeading.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.ForeColor = System.Drawing.Color.White;
            this.lblHeading.Location = new System.Drawing.Point(132, 40);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(723, 50);
            this.lblHeading.TabIndex = 1;
            this.lblHeading.Text = "LOCAL EVENTS AND ANNOUNCEMENTS";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(105, 217);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(124, 23);
            this.lblSearch.TabIndex = 1;
            this.lblSearch.Text = "Search Events:";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(240, 210);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(250, 30);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(551, 217);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(89, 23);
            this.lblCategory.TabIndex = 3;
            this.lblCategory.Text = "Category:";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(651, 209);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(180, 31);
            this.cmbCategory.TabIndex = 4;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // lblUpcomingEvents
            // 
            this.lblUpcomingEvents.AutoSize = true;
            this.lblUpcomingEvents.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpcomingEvents.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblUpcomingEvents.Location = new System.Drawing.Point(54, 298);
            this.lblUpcomingEvents.Name = "lblUpcomingEvents";
            this.lblUpcomingEvents.Size = new System.Drawing.Size(200, 28);
            this.lblUpcomingEvents.TabIndex = 5;
            this.lblUpcomingEvents.Text = "UPCOMING EVENTS";
            // 
            // lstEvents
            // 
            this.lstEvents.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstEvents.FormattingEnabled = true;
            this.lstEvents.ItemHeight = 23;
            this.lstEvents.Location = new System.Drawing.Point(59, 360);
            this.lstEvents.Name = "lstEvents";
            this.lstEvents.Size = new System.Drawing.Size(390, 211);
            this.lstEvents.TabIndex = 6;
            this.lstEvents.SelectedIndexChanged += new System.EventHandler(this.lstEvents_SelectedIndexChanged);
            // 
            // lblEventDetailsHeading
            // 
            this.lblEventDetailsHeading.AutoSize = true;
            this.lblEventDetailsHeading.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventDetailsHeading.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblEventDetailsHeading.Location = new System.Drawing.Point(532, 298);
            this.lblEventDetailsHeading.Name = "lblEventDetailsHeading";
            this.lblEventDetailsHeading.Size = new System.Drawing.Size(159, 28);
            this.lblEventDetailsHeading.TabIndex = 7;
            this.lblEventDetailsHeading.Text = "EVENT DETAILS";
            // 
            // grpEventDetails
            // 
            this.grpEventDetails.Controls.Add(this.lblDetailDescription);
            this.grpEventDetails.Controls.Add(this.lblDetailLocation);
            this.grpEventDetails.Controls.Add(this.lblDetailCategory);
            this.grpEventDetails.Controls.Add(this.lblDetailDate);
            this.grpEventDetails.Controls.Add(this.lblDetailTitle);
            this.grpEventDetails.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpEventDetails.Location = new System.Drawing.Point(537, 351);
            this.grpEventDetails.Name = "grpEventDetails";
            this.grpEventDetails.Size = new System.Drawing.Size(390, 220);
            this.grpEventDetails.TabIndex = 8;
            this.grpEventDetails.TabStop = false;
            this.grpEventDetails.Text = "Selected Event";
            // 
            // lblDetailDescription
            // 
            this.lblDetailDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetailDescription.Location = new System.Drawing.Point(23, 174);
            this.lblDetailDescription.Name = "lblDetailDescription";
            this.lblDetailDescription.Size = new System.Drawing.Size(300, 43);
            this.lblDetailDescription.TabIndex = 4;
            this.lblDetailDescription.Text = "Description: -";
            // 
            // lblDetailLocation
            // 
            this.lblDetailLocation.AutoSize = true;
            this.lblDetailLocation.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetailLocation.Location = new System.Drawing.Point(23, 140);
            this.lblDetailLocation.Name = "lblDetailLocation";
            this.lblDetailLocation.Size = new System.Drawing.Size(79, 20);
            this.lblDetailLocation.TabIndex = 3;
            this.lblDetailLocation.Text = "Location: -";
            // 
            // lblDetailCategory
            // 
            this.lblDetailCategory.AutoSize = true;
            this.lblDetailCategory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetailCategory.Location = new System.Drawing.Point(23, 104);
            this.lblDetailCategory.Name = "lblDetailCategory";
            this.lblDetailCategory.Size = new System.Drawing.Size(82, 20);
            this.lblDetailCategory.TabIndex = 2;
            this.lblDetailCategory.Text = "Category: -";
            // 
            // lblDetailDate
            // 
            this.lblDetailDate.AutoSize = true;
            this.lblDetailDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetailDate.Location = new System.Drawing.Point(23, 70);
            this.lblDetailDate.Name = "lblDetailDate";
            this.lblDetailDate.Size = new System.Drawing.Size(54, 20);
            this.lblDetailDate.TabIndex = 1;
            this.lblDetailDate.Text = "Date: -";
            // 
            // lblDetailTitle
            // 
            this.lblDetailTitle.AutoSize = true;
            this.lblDetailTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetailTitle.Location = new System.Drawing.Point(23, 38);
            this.lblDetailTitle.Name = "lblDetailTitle";
            this.lblDetailTitle.Size = new System.Drawing.Size(145, 20);
            this.lblDetailTitle.TabIndex = 0;
            this.lblDetailTitle.Text = "Title: Select an event";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(62, 596);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(176, 45);
            this.btnBack.TabIndex = 9;
            this.btnBack.Text = "Back to Main Menu";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnRecommended
            // 
            this.btnRecommended.BackColor = System.Drawing.Color.SteelBlue;
            this.btnRecommended.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecommended.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecommended.ForeColor = System.Drawing.Color.White;
            this.btnRecommended.Location = new System.Drawing.Point(702, 596);
            this.btnRecommended.Name = "btnRecommended";
            this.btnRecommended.Size = new System.Drawing.Size(225, 45);
            this.btnRecommended.TabIndex = 10;
            this.btnRecommended.Text = "Recommend an Event";
            this.btnRecommended.UseVisualStyleBackColor = false;
            this.btnRecommended.Click += new System.EventHandler(this.btnRecommended_Click);
            // 
            // dtpEventDate
            // 
            this.dtpEventDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEventDate.Location = new System.Drawing.Point(295, 260);
            this.dtpEventDate.Name = "dtpEventDate";
            this.dtpEventDate.Size = new System.Drawing.Size(200, 22);
            this.dtpEventDate.TabIndex = 11;
            this.dtpEventDate.ValueChanged += new System.EventHandler(this.dtpEventDate_ValueChanged);
            // 
            // chkFilterDate
            // 
            this.chkFilterDate.AutoSize = true;
            this.chkFilterDate.Location = new System.Drawing.Point(517, 262);
            this.chkFilterDate.Name = "chkFilterDate";
            this.chkFilterDate.Size = new System.Drawing.Size(108, 20);
            this.chkFilterDate.TabIndex = 12;
            this.chkFilterDate.Text = "Filter by Date";
            this.chkFilterDate.UseVisualStyleBackColor = true;
            this.chkFilterDate.CheckedChanged += new System.EventHandler(this.chkFilterDate_CheckedChanged);
            // 
            // LocalEventsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(982, 653);
            this.Controls.Add(this.chkFilterDate);
            this.Controls.Add(this.dtpEventDate);
            this.Controls.Add(this.btnRecommended);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.grpEventDetails);
            this.Controls.Add(this.lblEventDetailsHeading);
            this.Controls.Add(this.lstEvents);
            this.Controls.Add(this.lblUpcomingEvents);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LocalEventsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Local Events & Announcements";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.grpEventDetails.ResumeLayout(false);
            this.grpEventDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblUpcomingEvents;
        private System.Windows.Forms.ListBox lstEvents;
        private System.Windows.Forms.Label lblEventDetailsHeading;
        private System.Windows.Forms.GroupBox grpEventDetails;
        private System.Windows.Forms.Label lblDetailDate;
        private System.Windows.Forms.Label lblDetailTitle;
        private System.Windows.Forms.Label lblDetailDescription;
        private System.Windows.Forms.Label lblDetailLocation;
        private System.Windows.Forms.Label lblDetailCategory;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnRecommended;
        private System.Windows.Forms.DateTimePicker dtpEventDate;
        private System.Windows.Forms.CheckBox chkFilterDate;
    }
}