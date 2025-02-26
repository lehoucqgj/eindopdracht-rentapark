using RentAPark.Domain.Models;
using RentAPark.Domain.VO;
using System.Windows;

namespace RentAPark.Presentation.Windows {
    /// <summary>
    /// Interaction logic for MaintenanceWindow.xaml
    /// </summary>
    public partial class MaintenanceWindow : Window {

        internal event EventHandler<(Park, string, string)> InMaintenanceDisplayConflictsRequested;
        internal event EventHandler<(Park, string, string)> OutMaintenanceRequested;
        internal event EventHandler<int> DeleteSelectedReservationRequested;
        public MaintenanceWindow(List<Park> parks) {
            InitializeComponent();
            ParksCombobox.ItemsSource = parks;
        }

        private void InMaintenanceButton_Click(object sender, RoutedEventArgs e) {
            if (ParksCombobox.SelectedItem is Park park && !string.IsNullOrEmpty(StreetTextBox.Text) && !string.IsNullOrEmpty(NumberTextBox.Text)) {
                InMaintenanceDisplayConflictsRequested?.Invoke(this, (park, StreetTextBox.Text, NumberTextBox.Text));
            }
            else MessageBox.Show("Please Fill in all the fields!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void OutMaintenanceButton_Click(object sender, RoutedEventArgs e) {
            if (ParksCombobox.SelectedItem is Park park && !string.IsNullOrEmpty(StreetTextBox.Text) && !string.IsNullOrEmpty(NumberTextBox.Text)) {
                InMaintenanceDisplayConflictsRequested?.Invoke(this, (park, StreetTextBox.Text, NumberTextBox.Text));
            }
            else MessageBox.Show("Please Fill in all the fields!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e) {
            if (HousesListView.SelectedItem is ConflictReservationsVO conflictReservation) {
                DeleteSelectedReservationRequested?.Invoke(this, conflictReservation.ReservationId);
            }
        }
    }
}

