using RentAPark.Domain.HelperClasses;
using RentAPark.Domain.Models;
using RentAPark.Domain.VO;
using System.Windows;

namespace RentAPark.Presentation.Windows {
    /// <summary>
    /// Interaction logic for SelectHouse.xaml
    /// </summary>
    public partial class SelectHouse : Window {
        internal EventHandler<House> MakeReservationRequested;
        public SelectHouse(ReservationMaker reservationMaker) {
            InitializeComponent();

            HousesListView.ItemsSource = reservationMaker.Houses
            .Select(r => new HouseVO {
                DisplayText = $"{reservationMaker.Park.Name} - {r.Street} {r.Number} {reservationMaker.Park.Location} " +
                              $"{reservationMaker.StartDate.ToShortDateString()} - {reservationMaker.EndDate.ToShortDateString()}",
                House = r
            })
            .ToList();

        }
        private void MakeReservationButton_Click(object sender, RoutedEventArgs e) {
            if (HousesListView.SelectedItem is HouseVO selectedItem) {
                House house = selectedItem.House;
                MakeReservationRequested?.Invoke(this, house);
                MessageBox.Show($"Reservation made for {selectedItem.House.Street} {selectedItem.House.Number}");
                Close();
            }
            else {
                MessageBox.Show("Please select a house");
            }
        }
    }
}
