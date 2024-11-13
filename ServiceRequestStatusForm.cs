using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace mary_tshabalala_MunicipalServicesApp
{
    public partial class ServiceRequestStatusForm : Form
    {
        private SortedSet<ServiceRequest> serviceRequestTree;
        private Dictionary<ServiceRequest, List<ServiceRequest>> serviceRequestGraph;

        public ServiceRequestStatusForm()
        {
            InitializeComponent();
            serviceRequestTree = new SortedSet<ServiceRequest>(new ServiceRequestComparer());
            serviceRequestGraph = new Dictionary<ServiceRequest, List<ServiceRequest>>();
            LoadServiceRequests();
        }

        private void LoadServiceRequests()
        {
            var requests = ServiceRequestManager.GetAllRequests();
            foreach (var request in requests)
            {
                serviceRequestTree.Add(request);
                // Build the service request graph
                if (!serviceRequestGraph.ContainsKey(request))
                {
                    serviceRequestGraph[request] = new List<ServiceRequest>();
                }
            }

            UpdateDataGridView(serviceRequestTree);
        }

        private void UpdateDataGridView(SortedSet<ServiceRequest> requests)
        {
            var bindingList = new BindingList<ServiceRequest>(requests.ToList());
            serviceRequestsDataGridView.DataSource = bindingList;
        }

        private void RefreshDataGridView()
        {
            UpdateDataGridView(serviceRequestTree);
        }

        private void UpdateFilteredServiceRequests()
        {
            string filterText = filterTextBox.Text.ToLower();
            var filteredRequests = serviceRequestTree.Where(sr => sr.Description.ToLower().Contains(filterText) ||
                                                                 sr.Location.ToLower().Contains(filterText) ||
                                                                 sr.Category.ToLower().Contains(filterText))
                                                    .ToList();
            UpdateDataGridView(new SortedSet<ServiceRequest>(filteredRequests));
        }

        private void SearchServiceRequests(string searchText)
        {
            var searchResults = serviceRequestTree.Where(sr => sr.Description.Contains(searchText) ||
                                                              sr.Location.Contains(searchText) ||
                                                              sr.Category.Contains(searchText))
                                                 .ToList();
            UpdateDataGridView(new SortedSet<ServiceRequest>(searchResults));
        }

        private void filterTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateFilteredServiceRequests();
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            UpdateFilteredServiceRequests();
        }

        private void serviceRequestsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ServiceRequest selectedRequest = (ServiceRequest)serviceRequestsDataGridView.CurrentRow.DataBoundItem;
            ShowServiceRequestDetails(selectedRequest);
        }

        private void updateStatusButton_Click(object sender, EventArgs e)
        {
            ServiceRequest selectedRequest = (ServiceRequest)serviceRequestsDataGridView.CurrentRow.DataBoundItem;
            UpdateServiceRequestStatus(selectedRequest);
        }

        private void ShowServiceRequestDetails(ServiceRequest serviceRequest)
        {
            MessageBox.Show($"ID: {serviceRequest.Id}\nDescription: {serviceRequest.Description}\nStatus: {serviceRequest.Status}");
        }

        private void UpdateServiceRequestStatus(ServiceRequest serviceRequest)
        {
            serviceRequest.Status = "Completed"; // Example update
            MessageBox.Show($"Status updated for request ID: {serviceRequest.Id}");
            RefreshDataGridView(); // Reload to reflect changes
        }
    }

    public class ServiceRequestComparer : IComparer<ServiceRequest>
    {
        public int Compare(ServiceRequest x, ServiceRequest y)
        {
            return x.Id.CompareTo(y.Id);
        }
    }
}