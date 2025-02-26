using System.Security.Cryptography;

namespace RentAPark.Domain.Models {
    public class Reservation {
        private int _customerId;
        private DateTime _startDate;
        private DateTime _endDate;
        private int _id;

        public Reservation(int id, DateTime startdate, DateTime enddate, int customerId) {
            Id = id;
            CustomerId = customerId;
            StartDate = startdate;
            Enddate = enddate;
        }

        public int Id {
            get => _id;
            init {
                ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value);
                _id = value;
            }
        }
        public int CustomerId {
            get => _customerId;
            init {
                ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value);
                _customerId = value;
            }
        }
        public DateTime StartDate { get => _startDate; set => _startDate = value; }
        public DateTime Enddate { get => _endDate; set => _endDate = value; }

        public override string ToString() {
            return $"Reservation: {Id} Customer: {CustomerId} | {StartDate.ToString("dd/MM/yyyy")} - {Enddate.ToString("dd/MM/yyyy")} ";
        }
    }
}
