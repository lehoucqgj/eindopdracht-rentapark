using RentAPark.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAPark.Domain.Repositories {
    public interface IParkRepository {
        public List<Park> GetParks();
        public List<Park> GetparksByFacilities(List<Facility> facilities);
    }
}
