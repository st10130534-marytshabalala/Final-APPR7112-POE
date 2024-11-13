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
    public partial class LocalEventsAndAnnouncementsForm : Form
    {
        private BindingList<LocalEvent> events;
        private Dictionary<string, List<LocalEvent>> eventsByCategory;
        private Stack<LocalEvent> recentEvents = new Stack<LocalEvent>();
        private Queue<LocalEvent> upcomingEvents = new Queue<LocalEvent>();
        private SortedSet<LocalEvent> priorityEvents = new SortedSet<LocalEvent>(new EventComparer());
        private SortedDictionary<DateTime, LocalEvent> eventsByDate = new SortedDictionary<DateTime, LocalEvent>();
        private HashSet<string> uniqueCategories = new HashSet<string>();


        public LocalEventsAndAnnouncementsForm()
        {
            InitializeComponent();
            LoadEvents();
            PopulateEventCategories();
        }

        public class EventComparer : IComparer<LocalEvent>
        {
            public int Compare(LocalEvent x, LocalEvent y)
            {
                // Implement your custom comparison logic for priority events
                return x.DateTime.CompareTo(y.DateTime);
            }
        }

        private void LoadEvents()
        {
            events = new BindingList<LocalEvent>(GetEventData());
            eventsByCategory = GroupEventsByCategory(events);
            eventsDataGridView.DataSource = events;
        }

        private void PopulateEventCategories()
        {
            categoryComboBox.Items.AddRange(eventsByCategory.Keys.ToArray());
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            FilterEvents();
        }

        private void FilterEvents()
        {
            var filteredEvents = events;

            // Filter by date
            if (dateTimePicker.Checked)
            {
                filteredEvents = new BindingList<LocalEvent>(
                    filteredEvents.Where(e => e.DateTime.Date == dateTimePicker.Value.Date).ToList());
            }

            // Filter by category
            if (categoryComboBox.SelectedItem != null)
            {
                string selectedCategory = categoryComboBox.SelectedItem.ToString();
                filteredEvents = new BindingList<LocalEvent>(eventsByCategory[selectedCategory]);
            }

            eventsDataGridView.DataSource = filteredEvents;
        }

        private List<LocalEvent> GetEventData()
        {
            return new List<LocalEvent>
            {
                new LocalEvent { Title = "Community Cleanup", DateTime = new DateTime(2024, 11, 15), Category = "Community", Description = "Join us for a community cleanup day." },
                new LocalEvent { Title = "City Council Meeting", DateTime = new DateTime(2024, 11, 20), Category = "Government", Description = "Attend the city council meeting to discuss local issues." },
                new LocalEvent { Title = "Farmers Market", DateTime = new DateTime(2024, 11, 18), Category = "Community", Description = "Visit the farmers market for fresh produce." },
                new LocalEvent { Title = "Road Closure Notice", DateTime = new DateTime(2024, 11, 22), Category = "Infrastructure", Description = "Road closure due to construction." }
            };
        }

        private Dictionary<string, List<LocalEvent>> GroupEventsByCategory(BindingList<LocalEvent> events)
        {
            return events.GroupBy(e => e.Category)
                          .ToDictionary(g => g.Key, g => g.ToList());
        }
    }
}