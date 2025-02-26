using DatabasePopulator.Main;
using System.Windows;
using System.Windows.Controls;
using Path = System.IO.Path;

namespace DatabasePopulator.Presentation {
    public partial class MainWindow : Window {
        private TxtToTable _txtToTable;
        private string _filePath;
        private Action<string> _selectedRadioButtonAction;

        public MainWindow() {
            _txtToTable = new();
            InitializeComponent();
        }


        private void Window_Drop(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                string[] file = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (file.Length == 1 && Path.GetExtension(file[0]).Equals(".txt", StringComparison.OrdinalIgnoreCase)) {
                    _filePath = file[0];
                    MessageBox.Show($"Dropped file: {_filePath}", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    Dropzone.Text = Path.GetFileName(_filePath);
                }
                else if (file.Length > 1) {
                    MessageBox.Show("Please drop only one file", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else {
                    MessageBox.Show("Please drop a .txt file", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e) {
            if (!string.IsNullOrEmpty(_filePath)) {
                _selectedRadioButtonAction?.Invoke(_filePath);
            }
            if (string.IsNullOrEmpty(_filePath)) {
                MessageBox.Show("No file selected", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (_selectedRadioButtonAction == null) { 
                MessageBox.Show("No table selected", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else MessageBox.Show($"{Path.GetFileName(_filePath)} inserted into database", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Radiobuttons_Click(object sender, RoutedEventArgs e) {
            if (sender is RadioButton rb) {
                switch (rb.Name) {
                    case ("Customers"):
                        _selectedRadioButtonAction = _txtToTable.UpdateCustomerTable;
                        break;
                    case ("Facilities"):
                        _selectedRadioButtonAction = _txtToTable.UpdateFacilitiesTable;
                        break;
                    case ("HouseReservations"):
                        _selectedRadioButtonAction = _txtToTable.UpdateHouseReservationsTable;
                        break;
                    case ("Houses"):
                        _selectedRadioButtonAction = _txtToTable.UpdateHousesTable;
                        break;
                    case ("Parks"):
                        _selectedRadioButtonAction = _txtToTable.UpdateParksTable;
                        break;
                    case ("ParksFacilities"):
                        _selectedRadioButtonAction = _txtToTable.UpdateParksFacilitiesTable;
                        break;
                    case ("ParksHouses"):
                        _selectedRadioButtonAction = _txtToTable.UpdateParksHousesTable;
                        break;
                    case ("Reservations"):
                        _selectedRadioButtonAction = _txtToTable.UpdateReservationsTable;
                        break;
                    default:
                        break;
                }


            }
        }
    }
}