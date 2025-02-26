using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RentAPark.Domain.VO {
    public class ConflictReservationsVO {
        private int _reservationId;
        private int _houseId;
        private int _customerId;
        private string _customerName;

        public ConflictReservationsVO(int reservationId, int houseId, int customerId, string customerName, DateTime startDate, DateTime endDate) {
            ReservationId = reservationId;
            HouseId = houseId;
            CustomerId = customerId;
            CustomerName = customerName;
            StartDate = startDate;
            EndDate = endDate;
        }

        public int ReservationId {
            get => _reservationId;
            set {
                ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value);
                _reservationId = value;
            }
        }
        public int HouseId {
            get => _houseId;
            set {
                ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value);
                _houseId = value;
            }
        }

        public int CustomerId {
            get => _customerId;
            set {
                ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value);
                _customerId = value;
            }
        }
        public string CustomerName {
            get => _customerName;
            init {
                ArgumentNullException.ThrowIfNullOrWhiteSpace(value);
                _customerName = value;
            }
        }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public override string? ToString() {
            return $"reservation ID: {ReservationId} - {CustomerName} - from {StartDate.ToShortDateString()} til {EndDate.ToShortDateString()}";
        }
    }
}
