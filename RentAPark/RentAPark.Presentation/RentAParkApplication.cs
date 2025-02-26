using RentAPark.Domain;
using RentAPark.Domain.Exceptions;
using RentAPark.Domain.Models;
using RentAPark.Domain.VO;
using RentAPark.Presentation.Windows;
using System.Windows;

namespace RentAPark.Presentation {
    public class RentAParkApplication {
        private readonly DomainManager _domainManager;
        private MainWindow _mainWindow;
        private LookupReservations _lookupReservationsWindow;
        private MakeReservationWindow _makeReservationWindow;
        private SelectCustomerWindow _selectCustomerWindow;
        private SelectParkByLocation _selectParkByLocationWindow;
        private SelectParkByFacilities _selectParkByFacilityWindow;
        private SelectHouse _viewHousesWindow;
        private MaintenanceWindow _maintenanceWindow;

        public RentAParkApplication(DomainManager domainManager) {
            _domainManager = domainManager;
            _mainWindow = new MainWindow();

            _mainWindow.OpenReservationsWindowRequested += _mainWindow_OpenLookUpReservationWindow;
            _mainWindow.OpenMakeReservationsWindowRequested += _mainWindow_openMakeReservationWindow;
            _mainWindow.OpenMaintenanceWindowRequested += _mainWindow_OpenMaintenanceWindowRequested;
            _mainWindow.Show();
        }


        //-------------------------------------------------------------------------
        //------- MainWindow Event Handlers----------------------------------------
        //-------------------------------------------------------------------------
        private void _mainWindow_OpenLookUpReservationWindow(object? sender, EventArgs e) {
            try {
                _lookupReservationsWindow = new LookupReservations(_domainManager.GetParks());
                _lookupReservationsWindow.ByNameRequested += _lookupReservationsWindow_ByNameRequested;
                _lookupReservationsWindow.ByDateAndParkRequested += _lookupReservationsWindow_ByDateAndParkRequested;

                _lookupReservationsWindow.ShowDialog();
            }
            catch (DatabaseException ex) {
                MessageBox.Show(ex.Message + "\n" + ex.InnerException?.Message, "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex) {
                MessageBox.Show("An unexpected error occurred. Please try again later." + "\n" + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void _mainWindow_openMakeReservationWindow(object? sender, EventArgs e) {
            _makeReservationWindow = new MakeReservationWindow();
            _domainManager.CreateReservationMaker();
            _makeReservationWindow.OpenCustomerWindowRequested += _makeReservationWindow_OpenCustomerWindowRequested;
            _makeReservationWindow.OpenParkByLocationWindowRequested += _makeReservationWindow_OpenSelectParkByLocationWindowRequested;
            _makeReservationWindow.OpenParkByFacilitiesWindowRequested += _makeReservationWindow_OpenSelectParkByFacilityWindowRequested;
            _makeReservationWindow.StartDateSelected += _makeReservationWindow_StartDateSelected;
            _makeReservationWindow.EndDateSelected += _makeReservationWindow_EndDateSelected;
            _makeReservationWindow.NumberOfPersonsSelected += _makeReservationWindow_NumberOfPersonsSelected;
            _makeReservationWindow.OpenViewHousesWindowRequested += _makeReservationWindow_OpenViewHousesWindowRequested;
            _makeReservationWindow.ShowDialog();
        }

        private void _mainWindow_OpenMaintenanceWindowRequested(object? sender, EventArgs e) {
            try {
                _maintenanceWindow = new MaintenanceWindow(_domainManager.GetParks());
                _maintenanceWindow.InMaintenanceDisplayConflictsRequested += _MaintenanceWindow_InMaintenanceDisplayConflictsRequested;
                _maintenanceWindow.OutMaintenanceRequested += _MaintenanceWindow_OutMaintenanceRequested;
                _maintenanceWindow.DeleteSelectedReservationRequested += _maintenanceWindow_DeleteSelectedReservation;
                _maintenanceWindow.ShowDialog();
            }
            catch (DatabaseException ex) {
                MessageBox.Show(ex.Message + "\n" + ex.InnerException?.Message, "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex) {
                MessageBox.Show("An unexpected error occurred. Please try again later." + "\n" + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }







        //-------------------------------------------------------------------------
        // --------LookupReservationsWindow Event Handlers-------------------------
        //-------------------------------------------------------------------------
        private void _lookupReservationsWindow_ByDateAndParkRequested(object? sender, (DateTime startDate, DateTime endDate, Park park) e) {
            try {  
                _lookupReservationsWindow.Reservations = _domainManager.GetReservationsByDateAndPark(e.startDate, e.endDate, e.park).OrderBy(r => r.StartDate).ToList();
            }
            catch (DatabaseException ex) {
                MessageBox.Show(ex.Message + "\n" + ex.InnerException?.Message, "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex) {
                MessageBox.Show("An unexpected error occurred. Please try again later." + "\n" + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void _lookupReservationsWindow_ByNameRequested(object? sender, string e) {
            //try {
                _lookupReservationsWindow.Reservations = _domainManager.GetReservationsByName(e).OrderBy(r => r.CustomerId).ToList();
            //}
            //catch (DatabaseException ex) {
            //    MessageBox.Show(ex.Message + "\n" + ex.InnerException?.Message , "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
            //catch (Exception ex) {
            //    MessageBox.Show("An unexpected error occurred. Please try again later." + "\n" + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
        }

        //-------------------------------------------------------------------------
        //-------- MakeReservationWindow Event Handlers----------------------------
        //-------------------------------------------------------------------------
        private void _makeReservationWindow_OpenCustomerWindowRequested(object? sender, EventArgs e) {
            _selectCustomerWindow = new SelectCustomerWindow();
            _selectCustomerWindow.CustomerSearchRequested += _selectcustomerWindow_CustomerSearch;
            _selectCustomerWindow.CustomerSelected += _selectCustomerWindow_CustomerSelected;

            _selectCustomerWindow.ShowDialog();
        }

        private void _makeReservationWindow_OpenSelectParkByLocationWindowRequested(object? sender, EventArgs e) {
            try {
                _selectParkByLocationWindow = new SelectParkByLocation(_domainManager.GetParks());
                _selectParkByLocationWindow.ParkSelected += _selectParkByLocationWindow_ParkSelected;

                _selectParkByLocationWindow.ShowDialog();
            }
            catch (DatabaseException ex) {
                MessageBox.Show(ex.Message + "\n" + ex.InnerException?.Message, "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex) {
                MessageBox.Show("An unexpected error occurred. Please try again later." + "\n" + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void _makeReservationWindow_OpenSelectParkByFacilityWindowRequested(object? sender, EventArgs e) {
            try {
                _selectParkByFacilityWindow = new SelectParkByFacilities(_domainManager.GetFacilities());
                _selectParkByFacilityWindow.AddSelectedFacilitiyToListRequested += _selectParkByFacilityWindow_AddFacilityToList;
                _selectParkByFacilityWindow.AddParksToParkListviewRequested += _selectParkByFacilityWindow_ShowParksFromFacilities;
                _selectParkByFacilityWindow.SelectParkRequested += _selectParkByFacilityWindow_AddParkToReservation;
                _selectParkByFacilityWindow.ShowDialog();
            }
            catch (DatabaseException ex) {
                MessageBox.Show(ex.Message + "\n" + ex.InnerException?.Message, "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex) {
                MessageBox.Show("An unexpected error occurred. Please try again later." + "\n" + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void _makeReservationWindow_StartDateSelected(object? sender, DateTime e) {
            try {
                _domainManager.AddStartDateToReservationMaker(e);
            }
            catch (ArgumentOutOfRangeException ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void _makeReservationWindow_EndDateSelected(object? sender, DateTime e) {
            try { 
                _domainManager.AddEndDateToReservationMaker(e);
            }
            catch (ArgumentOutOfRangeException ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void _makeReservationWindow_NumberOfPersonsSelected(object? sender, int e) {
            _domainManager.AddNumberOfPersonsToReservationMaker(e);
        }

        private void _makeReservationWindow_OpenViewHousesWindowRequested(object? sender, EventArgs e) {
            try {
                    _domainManager.AddHousesToReservationMaker(_domainManager.GetHouses(_domainManager.GetReservationMaker()));
                if (_domainManager.GetReservationMaker().Houses.Count != 0) {
                    _viewHousesWindow = new SelectHouse(_domainManager.GetReservationMaker());
                    _viewHousesWindow.MakeReservationRequested += _viewHousesWindow_AddHouseToReservation;
                    _viewHousesWindow.MakeReservationRequested += _viewHousesWindow_MakeReservation;
                    _viewHousesWindow.ShowDialog();
                }
                else MessageBox.Show("No houses available", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (InvalidOperationException ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error");
            }
        }


                //MakeReservationWindow - SelectCustomerWindow Event Handlers
                //-------------------------------------------------------------------------
        private void _selectcustomerWindow_CustomerSearch(object? sender, string e) {
            try { 
                _selectCustomerWindow.Customers = _domainManager.GetCustomersByName(e);
                _selectCustomerWindow.CustomerListBox.ItemsSource = _selectCustomerWindow.Customers;
            }
            catch (DatabaseException ex) {
                MessageBox.Show(ex.Message + "\n" + ex.InnerException?.Message, "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex) {
                MessageBox.Show("An unexpected error occurred. Please try again later." + "\n" + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void _selectCustomerWindow_CustomerSelected(object? sender, Customer e) {
            try {
                _domainManager.AddCustomerToReservationMaker(e);
                _makeReservationWindow.CustomerLabel.Content = e.Name;
            }
            catch (InvalidOperationException ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
                //MakeReservationWindow - SelectParkByLocationWindow Event Handlers
                //-------------------------------------------------------------------------

        private void _selectParkByLocationWindow_ParkSelected(object? sender, Park e) {
            _domainManager.AddParkToReservationMaker(e);
            _makeReservationWindow.ParkLabel.Content = e.Location;
        }

                //MakeReservationWindow - SelectParkByFacilityWindow Event Handlers
                //-------------------------------------------------------------------------
        private void _selectParkByFacilityWindow_AddFacilityToList(object? sender, Facility e) {
            _selectParkByFacilityWindow.SelectedFacilitiesListView.Items.Add(e);
        }

        private void _selectParkByFacilityWindow_ShowParksFromFacilities(object? sender, List<Facility> e) {
            try { 
                _selectParkByFacilityWindow.ParksListview.ItemsSource = _domainManager.GetParksByFacilities(e);
            }
            catch (DatabaseException ex) {
                MessageBox.Show(ex.Message + "\n" + ex.InnerException?.Message, "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex) {
                MessageBox.Show("An unexpected error occurred. Please try again later." + "\n" + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void _selectParkByFacilityWindow_AddParkToReservation(object? sender, Park e) {
            _makeReservationWindow.ParkLabel.Content = e.Name;
            _domainManager.AddParkToReservationMaker(e);
        }

                //MakeReservationWindow - SelectHouse Event Handlers
                //-------------------------------------------------------------------------
        private void _viewHousesWindow_AddHouseToReservation(object? sender, House e) {
            _domainManager.AddSelectedHouseToReservationMaker(e);
        }
        private void _viewHousesWindow_MakeReservation(object? sender, House e) {
            try {
                _domainManager.MakeReservation(_domainManager.GetReservationMaker());
            }
            catch (InvalidOperationException ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (DatabaseException ex) {
                MessageBox.Show(ex.Message, "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (RollBackException ex) {
                MessageBox.Show(ex.Message, "Rollback Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex) {
                MessageBox.Show("An unexpected error occurred. Please try again later.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //-------------------------------------------------------------------------
        //----------- Maintenance Window Event Handlers----------------------------
        //-------------------------------------------------------------------------
        private void _MaintenanceWindow_InMaintenanceDisplayConflictsRequested(object? sender, (Park park, string address, string houseNumber) e) {
            try {
                List<House> houses = _domainManager.GetHouseByAddressAndPark(e.park.Id, e.address, e.houseNumber);
                List<int> houseIds = houses.Select(h => h.Id).ToList();
                if (houseIds.Count > 1) {
                    throw new ArgumentOutOfRangeException("There appears to be more than one house in this park on the same address. \n " +
                                                          "Contact your supervisor!");
                }
                else if (houseIds.Count <= 0) {
                    throw new ArgumentOutOfRangeException("There are no houses in our system with the data you provided. \n " +
                                                          "Check for typos or contact your supervisor!");
                }
                int houseId = houseIds.First();

                List<Reservation> ConflictedReservations = _domainManager.GetConflictedReservations(houseId);
                
                List<int> CustomerId = ConflictedReservations.Select(r => r.CustomerId).ToList();
                List<Customer> customers = _domainManager.GetCustomersByIds(CustomerId);

                List<ConflictReservationsVO> conflicts = _domainManager.GetConflictReservationsVO(houseId, ConflictedReservations, customers);

                _maintenanceWindow.HousesListView.ItemsSource = conflicts;
                
                _domainManager.SetHouseInactive(houseId);

            }
            catch (ArgumentOutOfRangeException ex) {
                MessageBox.Show(ex.Message, "Ambiguity", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (DatabaseException ex) {
                MessageBox.Show(ex.Message + "\n" + ex.InnerException?.Message, "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex) {
                MessageBox.Show("An unexpected error occurred. Please try again later." + "\n" + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
        private void _MaintenanceWindow_OutMaintenanceRequested(object? sender, (Park park, string address, string houseNumber) e) {
            List<House> houses = _domainManager.GetHouseByAddressAndPark(e.park.Id, e.address, e.houseNumber);
            List<int> houseIds = houses.Select(h => h.Id).ToList();
            if (houseIds.Count > 1) {
                throw new ArgumentOutOfRangeException("There appears to be more than one house in this park on the same address. \n " +
                                                      "Contact your supervisor!");
            }
            else if (houseIds.Count <= 0) {
                throw new ArgumentOutOfRangeException("There are no houses in our system with the data you provided. \n " +
                                                      "Check for typos or contact your supervisor!");
            }
            int houseId = houseIds.First();
            _domainManager.SetHouseActive(houseId);
        }

        private void _maintenanceWindow_DeleteSelectedReservation(object? sender, int e) {
            try {
                _domainManager.DeleteReservationById(e);
                MessageBox.Show("Reservation Deleted", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (InvalidOperationException ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (DatabaseException ex) {
                MessageBox.Show(ex.Message, "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (RollBackException ex) {
                MessageBox.Show(ex.Message, "Rollback Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex) {
                MessageBox.Show("An unexpected error occurred. Please try again later.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        }
}
