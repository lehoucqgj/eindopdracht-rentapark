using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAPark.Domain.Models {
    public class Facility {
        private string _description;

        public Facility(int id, string description) {
            Id = id;
            Description = description;
        }

        public int Id { get; set; }
        public string Description {
            get => _description;
            set {
                ArgumentException.ThrowIfNullOrWhiteSpace(value);
                _description = value;
            }
        }

        public override string? ToString() {
            return $"{Description}";
        }
    }
}
