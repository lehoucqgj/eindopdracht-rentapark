using RentAPark.Domain.Models;
using System.Windows;

namespace RentAPark.Presentation.Windows {
    /// <summary>
    /// Interaction logic for SelectCustomerWindow.xaml
    /// </summary>
    public partial class SelectCustomerWindow : Window {
        internal List<Customer> Customers { get; set; }

        internal event EventHandler<string> CustomerSearchRequested;
        internal event EventHandler<Customer> CustomerSelected;
        public SelectCustomerWindow() {
            InitializeComponent();
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e) {
            if (CustomerListBox.SelectedItem is Customer customer) {
                CustomerSelected?.Invoke(this, customer);
                Close();
            }
            else MessageBox.Show("Please select a customer", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e) {
            if (!string.IsNullOrWhiteSpace(NameTextBox.Text)) {
                CustomerSearchRequested?.Invoke(this, NameTextBox.Text);
            }
            else MessageBox.Show("Please enter a name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
