using RentAPark.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace RentAPark.Presentation {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        internal EventHandler OpenReservationsWindowRequested;
        internal EventHandler OpenMakeReservationsWindowRequested;
        internal EventHandler OpenMaintenanceWindowRequested;

        public MainWindow() {
            InitializeComponent();
        }

        private void ViewReservations_Click(object sender, RoutedEventArgs e) {
            OpenReservationsWindowRequested?.Invoke(this, EventArgs.Empty);
        }

        private void MakeReservation_Click(object sender, RoutedEventArgs e) {
            OpenMakeReservationsWindowRequested?.Invoke(this, EventArgs.Empty);
        }
        private void Maintenance_Click(object sender, RoutedEventArgs e) {
            if (sender is Button button) {
                if (button.Name == MaintenanceButton.Name) {
                    OpenMaintenanceWindowRequested?.Invoke(this, EventArgs.Empty);
                }
            }

        }
    }
}
