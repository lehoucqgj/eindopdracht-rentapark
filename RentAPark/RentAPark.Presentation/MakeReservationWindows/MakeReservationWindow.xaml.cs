using RentAPark.Domain.Models;
using RentAPark.Domain.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RentAPark.Presentation.Windows
{
    /// <summary>
    /// Interaction logic for MakeReservationWindow.xaml
    /// </summary>
    public partial class MakeReservationWindow : Window
    {
        private static readonly List<int> _numberOfPersons = new List<int> { 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        internal EventHandler OpenCustomerWindowRequested;
        internal EventHandler OpenParkByLocationWindowRequested;
        internal EventHandler OpenParkByFacilitiesWindowRequested;
        internal EventHandler OpenViewHousesWindowRequested;
        internal EventHandler <DateTime>StartDateSelected;
        internal EventHandler <DateTime>EndDateSelected;
        internal EventHandler<int> NumberOfPersonsSelected;

        internal bool _isCustomerSelected = false,
                      _isParkSelected = false,
                      _isFacilitySelected = false,
                      _isStardDateSelected = false,
                      _isEndDateSelected = false, 
                      _isNuberGuestsSelected = false;

        public MakeReservationWindow()
        {
            InitializeComponent();
            NumberOfPersons.ItemsSource = _numberOfPersons;
        }

        private void CustomerButton_Click(object sender, RoutedEventArgs e) {
            OpenCustomerWindowRequested?.Invoke(this, EventArgs.Empty);
        }

        private void ParkByLocationButton_Click(object sender, RoutedEventArgs e) {
            OpenParkByLocationWindowRequested?.Invoke(this, EventArgs.Empty);
        }

        private void ParksByFaciliesButton_Click(object sender, RoutedEventArgs e) {
            OpenParkByFacilitiesWindowRequested?.Invoke(this, EventArgs.Empty);
        }


        private void StartDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e) {
            DateTime? startDate = StartDatePicker.SelectedDate;
            if (startDate != null) {
                StartDateSelected?.Invoke(this, startDate.Value);
                _isStardDateSelected = true;
            }
            else MessageBox.Show("Please select a start date", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void EndDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e) {
            DateTime? endDate = EndDatePicker.SelectedDate;
            if (endDate != null) {
                EndDateSelected?.Invoke(this, endDate.Value);
                _isEndDateSelected = true;
            }
            else MessageBox.Show("Please select an end date", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }


        private void NumberOfPersons_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (NumberOfPersons != null) {
                int numberOfPersons = (int)NumberOfPersons.SelectedItem;
                NumberOfPersonsSelected?.Invoke(this, numberOfPersons);
                _isNuberGuestsSelected = true;
            }
            else MessageBox.Show("Please select the number of persons", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e) {
            Close();
        }

        private void ViewHousesButton_Click(object sender, RoutedEventArgs e) {
            OpenViewHousesWindowRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
