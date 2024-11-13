using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace mary_tshabalala_MunicipalServicesApp
{
    public partial class ServiceRequestDetailsForm : Form
    {
        private ServiceRequest serviceRequest;

        public ServiceRequestDetailsForm(ServiceRequest request)
        {
            InitializeComponent();
            serviceRequest = request;
            LoadRequestDetails();
        }

        private void LoadRequestDetails()
        {
            idTextBox.Text = serviceRequest.Id.ToString();
            descriptionTextBox.Text = serviceRequest.Description;
            statusComboBox.SelectedItem = serviceRequest.Status; // Assuming statusComboBox has status options.
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            // Save changes to the service request
            serviceRequest.Description = descriptionTextBox.Text;
            serviceRequest.Status = statusComboBox.SelectedItem.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}