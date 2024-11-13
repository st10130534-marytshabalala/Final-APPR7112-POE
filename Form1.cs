using System;
using System.Drawing;
using System.Windows.Forms;

namespace mary_tshabalala_MunicipalServicesApp
{
    public partial class Form1 : Form
    {
        private FlowLayoutPanel mainMenuPanel; // Declare the mainMenuPanel

        public Form1()
        {
            InitializeComponent(); // Call to the designer's InitializeComponent
            SetupMainMenu();
        }

        private void SetupMainMenu()
        {
            // Initialize and set up mainMenuPanel
            mainMenuPanel = new FlowLayoutPanel
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Dock = DockStyle.Top
            };

            // Add menu buttons
            AddMenuButton("Report Issues", ReportIssues_Click);
            AddMenuButton("Local Events and Announcements", LocalEventsandAnnouncements_Click);
            AddMenuButton("Services Request Status", ServicesRequestStatus_Click);

            // Add the panel to the form's controls
            this.Controls.Add(mainMenuPanel);
        }

        private void AddMenuButton(string text, EventHandler clickHandler)
        {
            Button button = new Button
            {
                Text = text,
                AutoSize = true,
                Margin = new Padding(10)
            };
            button.Click += clickHandler;
            mainMenuPanel.Controls.Add(button);
        }

        private void ReportIssues_Click(object sender, EventArgs e)
        {
            using (var reportIssuesForm = new ReportIssuesForm())
            {
                reportIssuesForm.ShowDialog();
            }
        }

        private void LocalEventsandAnnouncements_Click(object sender, EventArgs e)
        {
            using (var localEventsForm = new LocalEventsAndAnnouncementsForm())
            {
                localEventsForm.ShowDialog();
            }
        }

        private void ServicesRequestStatus_Click(object sender, EventArgs e)
        {
            using(var servicesRequestForm = new ServiceRequestStatusForm())
            {
                servicesRequestForm.ShowDialog();
            }
        }
    }
}