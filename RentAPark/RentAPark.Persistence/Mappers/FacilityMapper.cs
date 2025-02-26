using Microsoft.Data.SqlClient;
using RentAPark.Domain.Exceptions;
using RentAPark.Domain.Models;
using RentAPark.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAPark.Persistence.Mappers {
    public class FacilityMapper : IFacilityRepository {
        private SqlConnection _connection;

        public FacilityMapper() {
            _connection = new SqlConnection(DbInfo.ConnectionString);
        }

        public List<Facility> GetFacilities() {
            List<Facility> facilities = new List<Facility>();
            try {
                _connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Facilities", _connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows) {
                    while (reader.Read()) {
                        int id = (int)reader["Id"];
                        string description = (string)reader["Description"];
                        facilities.Add(new Facility(id, description));
                    }
                }
            }
            catch (SqlException ex) {
                throw new DatabaseException("Error in FacilityMapper GetFacilities: ", ex);
            }
            catch (InvalidOperationException ex) {
                throw new DatabaseException("Error in FacilityMapper GetFacilities: ", ex);
            }
            finally {
                _connection.Close();
            }
            return facilities;
        }
    }
}
