using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mary_tshabalala_MunicipalServicesApp
{
    public partial class ReportIssuesForm : Form
    {
        public ReportIssuesForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "All files (*.*)|*.*";
                openFileDialog.Title = "Select a file to attach";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the selected file path
                    string filePath = openFileDialog.FileName;

                    // Implement logic to handle the attached file, e.g., store the file path
                    // or upload the file to a server
                    MessageBox.Show($"Attached file: {filePath}");
                }
            }
        }

        private void Submit_Click(object sender, EventArgs e)
        {

            ServiceRequest newRequest = new ServiceRequest
            {
                Id = ServiceRequestIdGenerator.GenerateNewRequestId(),
                Description = richTextBox1.Text,
                Location = textBox2.Text,
                Category = comboBox1.SelectedItem.ToString(),
                Status = "Pending",
                SubmittedDate = DateTime.Now
            };

            ServiceRequestManager.AddRequest(newRequest);
            MessageBox.Show("Service request submitted successfully!");
            this.Close();
        }
    }
}
