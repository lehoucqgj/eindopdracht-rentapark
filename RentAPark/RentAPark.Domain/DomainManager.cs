using RentAPark.Domain.HelperClasses;
using RentAPark.Domain.Models;
using RentAPark.Domain.Repositories;
using RentAPark.Domain.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAPark.Domain {
    public class DomainManager {
        private readonly IParkRepository _parkRepository;
        private readonly IReservationRepository _reservationRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IFacilityRepository _facilityRepository;
        private readonly IHouseRepository _houseRepository;
        internal ReservationMaker _reservationMaker;

        public DomainManager(IParkRepository parkRepository, IReservationRepository reservationRepository, ICustomerRepository customerRepository,
                                IFacilityRepository facilityRepository, IHouseRepository houseRepository) {
            _parkRepository = parkRepository;
            _reservationRepository = reservationRepository;
            _customerRepository = customerRepository;
            _facilityRepository = facilityRepository;
            _houseRepository = houseRepository;
        }

        // DATABASE OPERATIONS
        //-------------------------------
        public List<Park> GetParks() {
            return _parkRepository.GetParks();
        }

        public List<Reservation> GetReservationsByName(string e) {
            return _reservationRepository.GetReservationsByName(e);
        }
        public List<Reservation> GetReservationsByDateAndPark(DateTime startDate, DateTime endDate, Park park) {
            return _reservationRepository.GetReservationsByDateAndPark(startDate, endDate, park);
        }

        public List<Customer> GetCustomersByName(string e) {
            return _customerRepository.GetCustomersByName(e);
        }

        public List<Facility> GetFacilities() {
            return _facilityRepository.GetFacilities();
        }

        public List<House> GetHouses(ReservationMaker reservantionMaker) {
            return _houseRepository.GetAvailableHouses(reservantionMaker.Park, reservantionMaker.StartDate, reservantionMaker.EndDate, reservantionMaker.NumberOfPersons);
        }
        public List<Park> GetParksByFacilities(List<Facility> facilities) {
            return _parkRepository.GetparksByFacilities(facilities);
        }
        public void MakeReservation(ReservationMaker reservationMaker) {
            _reservationRepository.MakeReservation(reservationMaker);
        }



        // maintenance window stuff
        public List<House>GetHouseByAddressAndPark(int parkId, string address, string houseNumber) {
            return _houseRepository.GetHouseByAddressAndPark(parkId, address, houseNumber);
        }

        public List<Reservation> GetConflictedReservations(int houseId) {
            return _reservationRepository.GetconflictedReservations(houseId);
        }

        public List<Customer> GetCustomersByIds(List<int> reservationId) {
            return _customerRepository.GetCustomersByIds(reservationId);
        }

        public void SetHouseInactive(int houseId) {
            _houseRepository.SetHouseInactive(houseId);
        }
        public void SetHouseActive(int houseId) {
            _houseRepository.SetHouseActive(houseId);
        }
        public void DeleteReservationById(int reservationId) {
            _reservationRepository.DeleteReservationById(reservationId);
        }


        // MaintenanceVO OPERATIONS
        //-----------------------------------

        public List<ConflictReservationsVO> GetConflictReservationsVO(int houseId, List<Reservation> reservations, List<Customer> customers) {
        List<ConflictReservationsVO> conflictReservations = reservations
        .Join(customers, reservation => reservation.CustomerId, customer => customer.Id, (reservation, customer) => new ConflictReservationsVO(
            reservation.Id,
            houseId,
            customer.Id,
            customer.Name,
            reservation.StartDate,
            reservation.Enddate)).ToList();

            return conflictReservations;
        }




        // ReservationMaker OPERATIONS
        //-----------------------------------
        public void CreateReservationMaker() {
            _reservationMaker = new ReservationMaker();
        }
        public void AddCustomerToReservationMaker(Customer customer) {
            if (customer != null) {
                _reservationMaker.Customer = customer;
            }
        }
        public void AddParkToReservationMaker(Park park) {
            if (park != null) {
                _reservationMaker.Park = park;
            }
        }
        public void AddHousesToReservationMaker(List<House> houses) {
            if (houses != null) {
                _reservationMaker.Houses = houses;
            }
            else { throw new InvalidOperationException("No house selected"); }
        }   
        public void AddStartDateToReservationMaker(DateTime startDate) {
            if (startDate <= DateTime.Now) {
                throw new ArgumentOutOfRangeException("Start date is before current date");
            }
            else if (startDate >= _reservationMaker.EndDate && _reservationMaker.EndDate != default) {
                throw new ArgumentOutOfRangeException("Start date is after end date");
            }
            if (startDate != default) {
                _reservationMaker.StartDate = startDate;
            }
        }
        public void AddEndDateToReservationMaker(DateTime endDate) {
            if (endDate <= _reservationMaker.StartDate) {
                throw new ArgumentOutOfRangeException("End date is before start date");
            }
            else if (endDate <= DateTime.Now) {
                throw new ArgumentOutOfRangeException("End date is before current date");
            }
            if (endDate != default) {
                _reservationMaker.EndDate = endDate;
            }
        }
        public void AddNumberOfPersonsToReservationMaker(int numberOfPersons) {
            if (numberOfPersons != default) {
                _reservationMaker.NumberOfPersons = numberOfPersons;
            }
        }
        public void AddSelectedHouseToReservationMaker(House house) {
            if (house != null) {
                _reservationMaker.House = house;
            }
        }
        public ReservationMaker GetReservationMaker() {
            if(CheckReservationMaker()) {
                return _reservationMaker;
            }
            throw new InvalidOperationException("ReservationMaker is not created");
        }
        public bool CheckReservationMaker() {
            if (_reservationMaker == null) {
                throw new InvalidOperationException("ReservationVO is not created");
            }
            if (_reservationMaker.Customer == default) {
                throw new InvalidOperationException("Customer is not selected");
            }
            else if (_reservationMaker.Park == null) {
                throw new InvalidOperationException("Park is not selected");
            }
            else if (_reservationMaker.StartDate == default) {
                throw new InvalidOperationException("Start date is not selected");
            }
            else if (_reservationMaker.EndDate == default) {
                throw new InvalidOperationException("End date is not selected");
            }
            else if (_reservationMaker.NumberOfPersons == default) {
                throw new InvalidOperationException("Number of persons is not selected");
            }
            //else if (_reservationMaker.Houses.Count == 0) {
            //    throw new InvalidOperationException("HouseList is not selected");
          
            //}
            return true;
        }


    }
}
