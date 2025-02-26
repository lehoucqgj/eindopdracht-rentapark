using Microsoft.Data.SqlClient;
using RentAPark.Domain.Exceptions;
using RentAPark.Domain.Models;
using RentAPark.Domain.Repositories;

namespace RentAPark.Persistence.Mappers {
    public class ParkMapper : IParkRepository {
        private SqlConnection _connection;

        public ParkMapper() {
            _connection = new SqlConnection(DbInfo.ConnectionString);
        }

        public List<Park> GetParks() {
            List<Park> parks = new List<Park>();
            try {
                _connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Parks", _connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows) {
                    while (reader.Read()) {
                        int id = (int)reader["Id"];
                        string name = (string)reader["Name"];
                        string location = (string)reader["Location"];
                        parks.Add(new Park(id, name, location));
                    }
                }

            }
            catch (SqlException ex) {
                throw new DatabaseException("Error in ParkMapper GetParks: ", ex);
            }
            catch (InvalidOperationException ex) {
                throw new DatabaseException("Error in ParkMapper GetParks: ", ex);
            }
            finally {
                _connection.Close();
            }



            return parks;
        }

        public List<Park> GetparksByFacilities(List<Facility> facilities) {
            List<string> facilityPlaceholder = new List<string>();
            for (int i = 0; i < facilities.Count; i++) {
                facilityPlaceholder.Add($"@FacilityId{i}");
            }
            string facilityIdsString = string.Join(", ", facilityPlaceholder);

            List<Park> parks = new List<Park>();
            try {
                _connection.Open();
                SqlCommand command = new SqlCommand($"SELECT DISTINCT Parks.Id, Parks.Name, Parks.Location " +
                                                    $"FROM Parks " +
                                                    $"INNER JOIN ParksFacilities ON Parks.Id = ParksFacilities.Park_id " +
                                                    $"INNER JOIN Facilities ON ParksFacilities.Facility_id = Facilities.Id " +
                                                    $"WHERE Facilities.Id IN ({facilityIdsString})", _connection);
                for (int i  = 0; i  < facilities.Count; i ++) {
                    command.Parameters.AddWithValue($"@FacilityId{i}", facilities[i].Id);
                }

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows) {
                    while (reader.Read()) {
                        int id = (int)reader["Id"];
                        string name = (string)reader["Name"];
                        string location = (string)reader["Location"];
                        parks.Add(new Park(id, name, location));
                    }
                }
            }
            catch (SqlException ex) {
                throw new DatabaseException("Error in ParkMapper GetparksByFacilities: ", ex);
            }
            catch (InvalidOperationException ex) {
                throw new DatabaseException("Error in ParkMapper GetparksByFacilities: ", ex);
            }
            finally {
                _connection.Close();
            }
            return parks;
        }
    }
}
