using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RentAPark.Domain.Models {
    public class House {
        private int _id;
        private string _street;
        private string _number;
        private int _maxGuests;

        public House(int id, string street, string number, bool active, int maxGuests) {
            Id = id;
            Street = street;
            Number = number;
            Active = active;
            MaxGuests = maxGuests;
        }

        public int Id {
            get => _id;
            init {
                ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value);
                _id = value;
            }
        }
        public string Street {
            get => _street;
            set {
                ArgumentException.ThrowIfNullOrWhiteSpace(value);
                _street = value;
            }
        }
        public string Number {
            get => _number;
            set {
                ArgumentException.ThrowIfNullOrWhiteSpace(value);
                _number = value;
            }
        }
        public bool Active { get; set; }
        public int MaxGuests {
            get => _maxGuests;
            init {
                ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value);
                _maxGuests = value;
            }
        }

        public override string? ToString() {
            return $"{Street} {Number}";
        }
    }
}
