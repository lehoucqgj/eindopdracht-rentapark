using RentAPark.Domain.Models;
using System.Windows;

namespace RentAPark.Presentation.Windows {
    /// <summary>
    /// Interaction logic for LookupReservations.xaml
    /// </summary>
    public partial class LookupReservations : Window {
        internal event EventHandler<string> ByNameRequested;
        internal event EventHandler<(DateTime, DateTime, Park)> ByDateAndParkRequested;
        internal List<Reservation> Reservations { set => ReservationsList.ItemsSource = value; }



        public LookupReservations(List<Park> parks) {
            InitializeComponent();
            ParksCombobox.ItemsSource = parks;
        }

        private void ByNameButton_Click(object sender, RoutedEventArgs e) {
            if (!string.IsNullOrWhiteSpace(CustomerTextBox.Text)) {
                ByNameRequested?.Invoke(this, CustomerTextBox.Text);
            }
            else MessageBox.Show("Please enter a name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void ByDateAndParkButton_Click(object sender, RoutedEventArgs e) {
            DateTime? startDate = StartDatePicker.SelectedDate;
            DateTime? endDate = EndDatePicker.SelectedDate;
            Park? park = ParksCombobox.SelectedItem as Park;

            if (startDate != null && endDate != null && park != null) {
                ByDateAndParkRequested?.Invoke(this, (startDate.Value, endDate.Value, park));
            }
            else MessageBox.Show("Please enter a start and end date and select a park", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

        }
    }
}
