using RentAPark.Domain.HelperClasses;
using RentAPark.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAPark.Domain.Repositories {
    public interface IReservationRepository {
        List<Reservation> GetReservationsByName(string name);
        List<Reservation> GetReservationsByDateAndPark(DateTime startDate, DateTime endDate, Park park);
        void MakeReservation(ReservationMaker reservationVO);
        List<Reservation> GetconflictedReservations(int houseId);
        void DeleteReservationById(int reservationId);
    }
}
