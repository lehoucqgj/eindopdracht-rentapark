using RentAPark.Domain;
using RentAPark.Domain.Repositories;
using RentAPark.Persistence.Mappers;
using RentAPark.Presentation;
using System.Configuration;
using System.Data;
using System.Windows;

namespace RentAPark.Startup {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {

private void Application_Startup(object sender, StartupEventArgs e) {
            IParkRepository parkRepository = new ParkMapper();
            IReservationRepository reservationRepository = new ReservationMapper();
            ICustomerRepository customerRepository = new CustomerMapper();
            IFacilityRepository facilityRepository = new FacilityMapper();
            IHouseRepository houseRepository = new HouseMapper();
            DomainManager domainManager = new(parkRepository, reservationRepository, customerRepository, facilityRepository, houseRepository);
            _ = new RentAParkApplication(domainManager);
        }
    }

}
