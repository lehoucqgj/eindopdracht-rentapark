using RentAPark.Domain.Repositories;
using RentAPark.Domain.Models;
using Microsoft.Data.SqlClient;
using RentAPark.Domain.Exceptions;

namespace RentAPark.Persistence.Mappers {
    public class HouseMapper : IHouseRepository {
        private SqlConnection _connection;
        public HouseMapper() {
            _connection = new SqlConnection(DbInfo.ConnectionString);
        }


        public List<House> GetAvailableHouses(Park park, DateTime startDate, DateTime endDate, int maxPersons) {
            List<House> houses = new List<House>();
            try { 
                _connection.Open();
                SqlCommand command = new SqlCommand("SELECT DISTINCT Houses.Id, Street, Number, Active, MaxPersons " +
                                                    "FROM Houses " +
                                                    "INNER JOIN ParksHouses ON Houses.Id = ParksHouses.House_id " +
                                                    "INNER JOIN Parks ON ParksHouses.Park_id = Parks.Id " +
                                                    "LEFT JOIN HouseReservations ON Houses.Id = HouseReservations.House_id " +
                                                    "LEFT JOIN Reservations ON HouseReservations.Reservation_id = Reservations.Id " +
                                                    "WHERE Parks.Location = @ParkLocation " +
                                                    "AND MaxPersons = @MaxPersons " +
                                                    "AND Active = 1 " +
                                                    "AND (Reservations.Id IS NULL OR " +
                                                    "     @StartDate > Reservations.Enddate OR @EndDate < Reservations.Startdate);", _connection);
                command.Parameters.AddWithValue("@ParkLocation", park.Location);
                command.Parameters.AddWithValue("@MaxPersons", maxPersons);
                command.Parameters.AddWithValue("@StartDate", startDate);
                command.Parameters.AddWithValue("@EndDate", endDate);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows) {
                    while (reader.Read()) {
                        int id = (int)reader["Id"];
                        string street = (string)reader["Street"];
                        string number = (string)reader["Number"];
                        bool active = (bool)reader["Active"];
                        int maxGuests = (int)reader["MaxPersons"];
                        houses.Add(new House(id, street, number, active, maxGuests));
                    }
                }
            }
            catch (SqlException ex) {
                throw new DatabaseException("Error in HouseMapper GetAvailableHouses: ", ex);
            }
            catch (InvalidOperationException ex) {
                throw new DatabaseException("Error in HouseMapper GetAvailableHouses: ", ex);
            }
            finally {
                _connection.Close();
            }
            return houses;
        }

        public List<House> GetHouseByAddressAndPark(int parkId, string street, string houseNumber) {
            List<House> houses = new List<House>();
            _connection.Open();
            try {
                SqlCommand command = new($"SELECT DISTINCT h.Id, h.Street, h.Number, h.Active, h.MaxPersons " +
                                         $"FROM Houses h " +
                                         $"INNER JOIN ParksHouses ph " +
                                         $"ON h.Id = ph.House_id " +
                                         $"WHERE ph.Park_id = @parkId " +
                                         $"AND h.Street = @Street " +
                                         $"AND h.Number = @Number;", _connection);
                command.Parameters.AddWithValue("@ParkId", parkId);
                command.Parameters.AddWithValue("@Street", street);
                command.Parameters.AddWithValue("@Number", houseNumber);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows) {
                    while (reader.Read()) {
                        int id = (int)reader["Id"];
                        string streetName = (string)reader["Street"];
                        string number = (string)reader["Number"];
                        bool active = (bool)reader["Active"];
                        int maxGuests = (int)reader["MaxPersons"];
                        houses.Add(new House(id, streetName, number, active, maxGuests));
                    }
                }
            }
            catch (SqlException ex) {
                throw new DatabaseException("Error in HouseMapper GetHouseByAddressAndPark - check if entered fields are correct. ", ex);
            }
            catch (InvalidOperationException ex) {
                throw new DatabaseException("Error in HouseMapper GetHouseByAddressAndPark - check if entered fields are correct. ", ex);
            }
            finally {
                _connection.Close();
            }
            return houses;
        }

        public void SetHouseInactive(int houseId) {
            try { 
                _connection.Open();
                SqlCommand command = new SqlCommand("UPDATE Houses " +
                                                    "SET Active = 0 " +
                                                    "WHERE Id = @HouseId;", _connection);
                command.Parameters.AddWithValue("@HouseId", houseId);
                command.ExecuteNonQuery();
            }
            catch (SqlException ex) {
                throw new DatabaseException("Error in HouseMapper SetHouseInactive", ex);
            }
            catch (InvalidOperationException ex) {
                throw new DatabaseException("Error in HouseMapper SetHouseInactive", ex);
            }
            finally {
                _connection.Close();
            }
        }
        public void SetHouseActive(int houseId) {
            try {
                _connection.Open();
                SqlCommand command = new SqlCommand("UPDATE Houses " +
                                                    "SET Active = 1 " +
                                                    "WHERE Id = @HouseId;", _connection);
                command.Parameters.AddWithValue("@HouseId", houseId);
                command.ExecuteNonQuery();
            }
            catch (SqlException ex) {
                throw new DatabaseException("Error in HouseMapper SetHouseInactive", ex);
            }
            catch (InvalidOperationException ex) {
                throw new DatabaseException("Error in HouseMapper SetHouseInactive", ex);
            }
            finally {
                _connection.Close();
            }
        }
    }
}
