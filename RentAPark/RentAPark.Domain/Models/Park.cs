namespace RentAPark.Domain.Models {
    public class Park {
        private int _id;
        private string _name;
        private string _location;

        public Park(int id, string name, string location) {
            Id = id;
            Name = name;
            Location = location;
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
            set {
                ArgumentException.ThrowIfNullOrWhiteSpace(value);
                _name = value;
            }
        }
        public string Location {
            get => _location;
            set {
                ArgumentException.ThrowIfNullOrWhiteSpace(value);
                _location = value; 
            }
        }

        public override string? ToString() {
            return $"{Name} - {Location}";
        }
    }
}
