using RentAPark.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAPark.Domain.Repositories {
    public interface IHouseRepository {
        List<House> GetAvailableHouses(Park park, DateTime startDate, DateTime endDate, int maxPersons);
        List<House>GetHouseByAddressAndPark(int parkId, string address, string houseNumber);
        void SetHouseActive(int houseId);
        void SetHouseInactive(int houseId);
    }
}
