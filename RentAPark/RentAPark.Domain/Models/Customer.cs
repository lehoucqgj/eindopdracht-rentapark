using System.Security.Cryptography;

namespace RentAPark.Domain.Models {
    public class Customer {
        private string _name;
        private string _address;
        private int _id;

        public Customer(int id, string name, string address) {
            Id = id;
            Name = name;
            Address = address;
        }

        public int Id {
            get => _id;
            init {
                ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value);
                _id = value;
            }
        }
        public string Name {
            get => _name;
            init {
                ArgumentNullException.ThrowIfNullOrWhiteSpace(value);
                _name = value;
            }
        }
        public string Address {
            get => _address;
            init { 
                ArgumentNullException.ThrowIfNullOrWhiteSpace(value);
                _address = value; 
            }
        }

        public override string? ToString() {
            return $"{Name} - {Address}";
        }
    }
}
