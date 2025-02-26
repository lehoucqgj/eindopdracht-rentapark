using RentAPark.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAPark.Domain.VO {
    public class HouseVO {
        private string _displayText;

        public string DisplayText {
            get => _displayText;
            set {
                ArgumentException.ThrowIfNullOrWhiteSpace(value);
                _displayText = value;
            }
        }
        public House House { get; set; }
    }
}
