using RentAPark.Domain.Models;
using System.Windows;

namespace RentAPark.Presentation.Windows {
    /// <summary>
    /// Interaction logic for SelectParkByFacilities.xaml
    /// </summary>
    public partial class SelectParkByFacilities : Window {
        internal event EventHandler<Facility> AddSelectedFacilitiyToListRequested;
        internal event EventHandler<List<Facility>> AddParksToParkListviewRequested;
        internal event EventHandler <Park>SelectParkRequested;
        public SelectParkByFacilities(List<Facility> facilities) {
            InitializeComponent();
            FacilitiesListView.ItemsSource = facilities;
        }


        private void AddButton_Click(object sender, RoutedEventArgs e) {
            Facility? selectedFacility = FacilitiesListView.SelectedItem as Facility;
            if (selectedFacility != null) {
                AddSelectedFacilitiyToListRequested?.Invoke(this, selectedFacility);
            }
            else MessageBox.Show("Please select a facility", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //TODO: Remove button
            //TODO: Check for double items
        }
        private void SearchButton_Click(object sender, RoutedEventArgs e) {
            if (SelectedFacilitiesListView.Items.IsEmpty) {
                MessageBox.Show("Please select at least one facility", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else {
                List<Facility> selectedFacilities = new List<Facility>();
                foreach (Facility facility in SelectedFacilitiesListView.Items) {
                    selectedFacilities.Add(facility);
                    //MessageBox.Show(facility.Description);
                }
                AddParksToParkListviewRequested?.Invoke(this, selectedFacilities);
                
            }
        }
        
        private void SelectButton_Click(object sender, RoutedEventArgs e) {
            Park? selectedPark = ParksListview.SelectedItem as Park;
            if (selectedPark != null) {
                SelectParkRequested?.Invoke(this, selectedPark);
                Close();
            }
            else MessageBox.Show("Please select a park", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}