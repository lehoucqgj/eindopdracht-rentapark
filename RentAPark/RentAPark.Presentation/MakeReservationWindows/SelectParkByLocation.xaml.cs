using RentAPark.Domain.Models;
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

namespace RentAPark.Presentation.Windows {
    /// <summary>
    /// Interaction logic for SelectParkByLocation.xaml
    /// </summary>
    public partial class SelectParkByLocation : Window {
        internal event EventHandler<Park> ParkSelected;
        public SelectParkByLocation(List<Park> parks) {
            InitializeComponent();
            CityComboBox.ItemsSource = parks;
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e) {
            if (CityComboBox.SelectedItem is Park park) {
                ParkSelected?.Invoke(this, park);
                Close();
            }
            else MessageBox.Show("Please select a park", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
