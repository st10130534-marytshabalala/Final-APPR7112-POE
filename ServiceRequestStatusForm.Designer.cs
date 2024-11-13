namespace mary_tshabalala_MunicipalServicesApp
{
    partial class ServiceRequestStatusForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.serviceRequestsDataGridView = new System.Windows.Forms.DataGridView();
            this.filterTextBox = new System.Windows.Forms.TextBox();
            this.filterButton = new System.Windows.Forms.Button();
            this.updateStatusButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.serviceRequestsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // serviceRequestsDataGridView
            // 
            this.serviceRequestsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.serviceRequestsDataGridView.Location = new System.Drawing.Point(12, 39);
            this.serviceRequestsDataGridView.Name = "serviceRequestsDataGridView";
            this.serviceRequestsDataGridView.Size = new System.Drawing.Size(776, 350);
            this.serviceRequestsDataGridView.TabIndex = 0;
            this.serviceRequestsDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.serviceRequestsDataGridView_CellDoubleClick);
            // 
            // filterTextBox
            // 
            this.filterTextBox.Location = new System.Drawing.Point(12, 12);
            this.filterTextBox.Name = "filterTextBox";
            this.filterTextBox.Size = new System.Drawing.Size(200, 20);
            this.filterTextBox.TabIndex = 1;
            this.filterTextBox.TextChanged += new System.EventHandler(this.filterTextBox_TextChanged);
            // 
            // filterButton
            // 
            this.filterButton.Location = new System.Drawing.Point(218, 10);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(75, 23);
            this.filterButton.TabIndex = 2;
            this.filterButton.Text = "Filter";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // updateStatusButton
            // 
            this.updateStatusButton.Location = new System.Drawing.Point(713, 10);
            this.updateStatusButton.Name = "updateStatusButton";
            this.updateStatusButton.Size = new System.Drawing.Size(75, 23);
            this.updateStatusButton.TabIndex = 3;
            this.updateStatusButton.Text = "Update Status";
            this.updateStatusButton.UseVisualStyleBackColor = true;
            this.updateStatusButton.Click += new System.EventHandler(this.updateStatusButton_Click);
            // 
            // ServiceRequestStatusForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 401);
            this.Controls.Add(this.updateStatusButton);
            this.Controls.Add(this.filterButton);
            this.Controls.Add(this.filterTextBox);
            this.Controls.Add(this.serviceRequestsDataGridView);
            this.Name = "ServiceRequestStatusForm";
            this.Text = "Service Request Status";
            ((System.ComponentModel.ISupportInitialize)(this.serviceRequestsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView serviceRequestsDataGridView;
        private System.Windows.Forms.TextBox filterTextBox;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.Button updateStatusButton;
    }
}