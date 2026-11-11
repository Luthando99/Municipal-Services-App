namespace MunicipalServicesApp
{
    partial class ServiceRequestStatusForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblRequests = new System.Windows.Forms.Label();
            this.dgvRequests = new System.Windows.Forms.DataGridView();
            this.lblTrackingID = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblDateReported = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.progressStatus = new System.Windows.Forms.ProgressBar();
            this.btnBack = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDescription = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnHighPriority = new System.Windows.Forms.Button();
            this.btnNetworkAnalysis = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(289, 26);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(393, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "SERVICE REQUEST STATUS";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.ForeColor = System.Drawing.Color.White;
            this.lblSubtitle.Location = new System.Drawing.Point(307, 69);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(353, 23);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Track and monitor municipal service requests";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(93, 149);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(194, 25);
            this.lblSearch.TabIndex = 2;
            this.lblSearch.Text = "Search for a Request";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(96, 183);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(395, 29);
            this.txtSearch.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(683, 161);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(89, 47);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblRequests
            // 
            this.lblRequests.AutoSize = true;
            this.lblRequests.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequests.Location = new System.Drawing.Point(93, 242);
            this.lblRequests.Name = "lblRequests";
            this.lblRequests.Size = new System.Drawing.Size(258, 25);
            this.lblRequests.TabIndex = 5;
            this.lblRequests.Text = "Submitted Service Requests";
            // 
            // dgvRequests
            // 
            this.dgvRequests.AllowUserToAddRows = false;
            this.dgvRequests.AllowUserToDeleteRows = false;
            this.dgvRequests.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRequests.BackgroundColor = System.Drawing.Color.White;
            this.dgvRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRequests.Location = new System.Drawing.Point(96, 269);
            this.dgvRequests.MultiSelect = false;
            this.dgvRequests.Name = "dgvRequests";
            this.dgvRequests.ReadOnly = true;
            this.dgvRequests.RowHeadersVisible = false;
            this.dgvRequests.RowHeadersWidth = 51;
            this.dgvRequests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRequests.Size = new System.Drawing.Size(669, 93);
            this.dgvRequests.TabIndex = 6;
            this.dgvRequests.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRequests_CellClick);
            // 
            // lblTrackingID
            // 
            this.lblTrackingID.AutoSize = true;
            this.lblTrackingID.Location = new System.Drawing.Point(95, 427);
            this.lblTrackingID.Name = "lblTrackingID";
            this.lblTrackingID.Size = new System.Drawing.Size(121, 23);
            this.lblTrackingID.TabIndex = 7;
            this.lblTrackingID.Text = "Tracking ID: —";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(412, 427);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(105, 23);
            this.lblCategory.TabIndex = 8;
            this.lblCategory.Text = "Category: —";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(95, 462);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(101, 23);
            this.lblLocation.TabIndex = 9;
            this.lblLocation.Text = "Location: —";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(412, 462);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(82, 23);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "Status: —";
            // 
            // lblDateReported
            // 
            this.lblDateReported.AutoSize = true;
            this.lblDateReported.Location = new System.Drawing.Point(95, 499);
            this.lblDateReported.Name = "lblDateReported";
            this.lblDateReported.Size = new System.Drawing.Size(147, 23);
            this.lblDateReported.TabIndex = 11;
            this.lblDateReported.Text = "Date Reported: —";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(415, 534);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(350, 77);
            this.txtDescription.TabIndex = 12;
            this.txtDescription.Text = "";
            // 
            // progressStatus
            // 
            this.progressStatus.Location = new System.Drawing.Point(96, 637);
            this.progressStatus.Name = "progressStatus";
            this.progressStatus.Size = new System.Drawing.Size(669, 17);
            this.progressStatus.TabIndex = 13;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(574, 663);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(191, 55);
            this.btnBack.TabIndex = 14;
            this.btnBack.Text = "Back to Main Menu";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.lblSubtitle);
            this.panel1.Location = new System.Drawing.Point(0, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(887, 112);
            this.panel1.TabIndex = 15;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(412, 499);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(105, 23);
            this.lblDescription.TabIndex = 16;
            this.lblDescription.Text = "Description: ";
            // 
            // progressBar
            // 
            this.progressBar.AutoSize = true;
            this.progressBar.Location = new System.Drawing.Point(96, 606);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(141, 23);
            this.progressBar.TabIndex = 17;
            this.progressBar.Text = "Request Progress";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(93, 402);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 25);
            this.label1.TabIndex = 18;
            this.label1.Text = "Request Details";
            // 
            // btnHighPriority
            // 
            this.btnHighPriority.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnHighPriority.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHighPriority.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHighPriority.ForeColor = System.Drawing.Color.White;
            this.btnHighPriority.Location = new System.Drawing.Point(571, 368);
            this.btnHighPriority.Name = "btnHighPriority";
            this.btnHighPriority.Size = new System.Drawing.Size(194, 43);
            this.btnHighPriority.TabIndex = 19;
            this.btnHighPriority.Text = "View Highest Priority";
            this.btnHighPriority.UseVisualStyleBackColor = false;
            this.btnHighPriority.Click += new System.EventHandler(this.btnHighPriority_Click);
            // 
            // btnNetworkAnalysis
            // 
            this.btnNetworkAnalysis.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnNetworkAnalysis.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNetworkAnalysis.ForeColor = System.Drawing.Color.White;
            this.btnNetworkAnalysis.Location = new System.Drawing.Point(397, 663);
            this.btnNetworkAnalysis.Name = "btnNetworkAnalysis";
            this.btnNetworkAnalysis.Size = new System.Drawing.Size(171, 55);
            this.btnNetworkAnalysis.TabIndex = 20;
            this.btnNetworkAnalysis.Text = "Network Analysis";
            this.btnNetworkAnalysis.UseVisualStyleBackColor = false;
            this.btnNetworkAnalysis.Click += new System.EventHandler(this.btnNetworkAnalysis_Click);
            // 
            // ServiceRequestStatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(882, 731);
            this.Controls.Add(this.btnNetworkAnalysis);
            this.Controls.Add(this.btnHighPriority);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.progressStatus);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDateReported);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblTrackingID);
            this.Controls.Add(this.dgvRequests);
            this.Controls.Add(this.lblRequests);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearch);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(700, 600);
            this.Name = "ServiceRequestStatusForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Service Request Status";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblRequests;
        private System.Windows.Forms.DataGridView dgvRequests;
        private System.Windows.Forms.Label lblTrackingID;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblDateReported;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.ProgressBar progressStatus;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label progressBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnHighPriority;
        private System.Windows.Forms.Button btnNetworkAnalysis;
    }
}