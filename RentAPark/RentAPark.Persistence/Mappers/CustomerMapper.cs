using Microsoft.Data.SqlClient;
using RentAPark.Domain.Exceptions;
using RentAPark.Domain.Models;
using RentAPark.Domain.Repositories;

namespace RentAPark.Persistence.Mappers {
    public class CustomerMapper : ICustomerRepository {
        private SqlConnection _connection;

        public CustomerMapper() {
            _connection = new SqlConnection(DbInfo.ConnectionString);
        }

        public List<Customer> GetCustomersByName(string name) {
            List<Customer> customers = new List<Customer>();
            try {
                _connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Customers WHERE Name LIKE @Name", _connection);
                command.Parameters.AddWithValue("@Name", "%" + name + "%");
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows) {
                    while (reader.Read()) {
                        int id = (int)reader["Id"];
                        string customerName = (string)reader["Name"];
                        string address = (string)reader["Address"];
                        customers.Add(new Customer(id, customerName, address));
                    }
                }
            }
            catch (SqlException ex) {
                throw new DatabaseException("Error in CustomerMapper GetCustomersByName: ", ex);
            }
            catch (InvalidOperationException ex) {
                throw new DatabaseException("Error in CustomerMapper GetCustomersByName: ", ex);
            }
            finally {
                _connection.Close();
            }
            return customers;
        }

        public List<Customer> GetCustomersByIds(List<int> customerIds) {
            List<Customer> customers = new List<Customer>();

            try {
                _connection.Open();
                string query = "SELECT * FROM Customers WHERE Id IN (" + string.Join(",", customerIds.Select((id, index) => "@Id" + index)) + ")";
                SqlCommand command = new SqlCommand(query, _connection);
                for (int i = 0; i < customerIds.Count; i++) {
                    command.Parameters.AddWithValue("@Id" + i, customerIds[i]);
                }
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows) {
                    while (reader.Read()) {
                        int customerId = (int)reader["Id"];
                        string customerName = (string)reader["Name"];
                        string address = (string)reader["Address"];
                        customers.Add(new Customer(customerId, customerName, address));
                    }
                }
            }
            catch (SqlException ex) {
                throw new DatabaseException("Error in CustomerMapper GetCustomersByIds: ", ex);
            }
            catch (InvalidOperationException ex) {
                throw new DatabaseException("Error in CustomerMapper GetCustomersByIds: ", ex);
            }
            finally {
                _connection.Close();
            }
            return customers;
        }
    }
}
