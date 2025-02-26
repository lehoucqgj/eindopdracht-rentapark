using RentAPark.Domain.Models;

namespace RentAPark.Domain.Repositories {
    public interface IFacilityRepository {
        public List<Facility> GetFacilities();
    }
}
