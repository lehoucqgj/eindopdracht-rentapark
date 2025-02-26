using RentAPark.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAPark.Domain.HelperClasses {
    public class ReservationMaker {
        //public Customer Customer { get; internal set; }
        //public Park Park { get; internal set; }
        //public List<Facility> Facilities { get; internal set; }
        //public DateTime StartDate { get; internal set; }
        //public DateTime EndDate { get; internal set; }
        //public int NumberOfPersons { get; internal set; }
        //public List<House> Houses { get; internal set; }
        //public House House { get; internal set; }

        private Customer _customer;
        private Park _park;
        private List<Facility> _facilities;
        private DateTime _startDate;
        private DateTime _endDate;
        private int _numberOfPersons;
        private List<House> _houses;
        private House _house;

        public Customer Customer {
            get => _customer;
            internal set {
                ArgumentNullException.ThrowIfNull(value);
                _customer = value;
            }
        }

        public Park Park {
            get => _park;
            internal set {
                ArgumentNullException.ThrowIfNull(value);
                _park = value;
            }
        }

        public List<Facility> Facilities {
            get => _facilities;
            internal set {
                ArgumentNullException.ThrowIfNull(value);
                _facilities = value;
            }
        }

        public DateTime StartDate {
            get => _startDate;
            internal set {
                if (value <= DateTime.Now) {
                    throw new ArgumentOutOfRangeException(nameof(StartDate), "Start date must be in the future.");
                }
                _startDate = value;
            }
        }

        public DateTime EndDate {
            get => _endDate;
            internal set {
                if (value <= StartDate) {
                    throw new ArgumentOutOfRangeException(nameof(EndDate), "End date must be after start date.");
                }
                _endDate = value;
            }
        }

        public int NumberOfPersons {
            get => _numberOfPersons;
            internal set {
                ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value);
                _numberOfPersons = value;
            }
        }

        public List<House> Houses {
            get => _houses;
            internal set {
                ArgumentNullException.ThrowIfNull(value);
                _houses = value;
            }
        }

        public House House {
            get => _house;
            internal set {
                ArgumentNullException.ThrowIfNull(value);
                _house = value;
            }
        }


    }
}
