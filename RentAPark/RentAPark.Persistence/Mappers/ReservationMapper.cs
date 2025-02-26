using Microsoft.Data.SqlClient;
using RentAPark.Domain.Exceptions;
using RentAPark.Domain.HelperClasses;
using RentAPark.Domain.Models;
using RentAPark.Domain.Repositories;
using System.Linq.Expressions;

namespace RentAPark.Persistence.Mappers {
    public class ReservationMapper : IReservationRepository {
        private SqlConnection _conection;

        public ReservationMapper() {
            _conection = new SqlConnection(DbInfo.ConnectionString);
        }

            //TODO: Make that name is also in the listview
        public List<Reservation> GetReservationsByName(string name) {
            List<Reservation> reservations = new List<Reservation>();
            try {
                _conection.Open();
                SqlCommand command = new($"SELECT Reservations.Id as reservation_id, Reservations.Startdate, Reservations.Enddate, Reservations.Customer_id as customer_id " +
                                         $"FROM Reservations " +
                                         $"INNER JOIN Customers ON Reservations.Customer_id = Customers.ID " +
                                         $"WHERE Customers.Name LIKE @CustomerName", _conection);
                command.Parameters.AddWithValue("@CustomerName", "%" + name + "%");
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows) {
                    while (reader.Read()) {
                        int reservationId = (int)reader["reservation_id"];
                        DateTime startDate = (DateTime)reader["Startdate"];
                        DateTime endDate = (DateTime)reader["Enddate"];
                        int customerId = (int)reader["customer_id"];
                        reservations.Add(new Reservation(reservationId, startDate, endDate, customerId));
                    }
                }
            }
            catch  (SqlException ex) { 
                throw new DatabaseException("Error in ReservationMapper GetReservationsByName: ", ex);
            }
            catch (InvalidOperationException ex) {
                throw new DatabaseException("Error in ReservationMapper GetReservationsByName: ", ex);
            }
            finally {
                _conection.Close();
            }
            return reservations;
        }

        public List<Reservation> GetReservationsByDateAndPark(DateTime startDate, DateTime endDate, Park park) {
            List<Reservation> reservations = new List<Reservation>();
            try {
                _conection.Open();
                SqlCommand command = new($"SELECT Reservations.Id AS reservations_id, Startdate, Enddate, Customer_id, Parks.Name FROM Reservations " +
                                        $"INNER JOIN HouseReservations ON Reservations.Id = HouseReservations.Reservation_id " +
                                        $"INNER JOIN ParksHouses ON HouseReservations.House_id = ParksHouses.House_id " +
                                        $"INNER JOIN Parks ON ParksHouses.Park_id = Parks.Id " +
                                        $"WHERE Parks.Name = @ParkName " +
                                        $"AND (@StartDate BETWEEN Startdate and Enddate OR @StartDate BETWEEN Startdate and Enddate)", _conection);
                command.Parameters.AddWithValue("@ParkName", park.Name);
                command.Parameters.AddWithValue("@StartDate", startDate);
                command.Parameters.AddWithValue("@EndDate", endDate);
                SqlDataReader reader = command.ExecuteReader();
                if ( reader.HasRows) {
                    while (reader.Read()) {
                        int reservationId = (int)reader["reservations_id"];
                        DateTime start = (DateTime)reader["Startdate"];
                        DateTime end = (DateTime)reader["Enddate"];
                        int customerId = (int)reader["customer_id"];
                        reservations.Add(new Reservation(reservationId, start, end, customerId));
                    }
                }
            }

            catch (SqlException ex) {
                throw new DatabaseException("Error in ReservationMapper GetReservationsByDateAndPark: ", ex);
            }
            catch (InvalidOperationException ex) {
                throw new DatabaseException("Error in ReservationMapper GetReservationsByDateAndPark: ", ex);
            }
            finally {
                _conection.Close();
            }
            return reservations;

        }

        public void MakeReservation(ReservationMaker reservationMaker) {
                _conection.Open();
                SqlTransaction transaction = _conection.BeginTransaction();
            try {

                SqlCommand commandReservation = new($"INSERT INTO Reservations (Startdate, Enddate, Customer_id) " +
                                                    $"VALUES (@Startdate, @Enddate, @Customer_id); " +
                                                    $"SELECT SCOPE_IDENTITY();", _conection, transaction);
                commandReservation.Parameters.AddWithValue("@Startdate", reservationMaker.StartDate);
                commandReservation.Parameters.AddWithValue("@Enddate", reservationMaker.EndDate);
                commandReservation.Parameters.AddWithValue("@Customer_id", reservationMaker.Customer.Id);
                int reservationId = Convert.ToInt32(commandReservation.ExecuteScalar());

                SqlCommand commandHouseReservations = new($"INSERT INTO HouseReservations (House_id, Reservation_id) " +
                                                          $"VALUES (@House_id, @Reservation_id);", _conection, transaction);
                commandHouseReservations.Parameters.AddWithValue("@Reservation_id", reservationId);
                commandHouseReservations.Parameters.AddWithValue("@House_id", reservationMaker.House.Id);
                commandHouseReservations.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (SqlException ex) {
                try { 
                    transaction.Rollback(); 
                }
                catch (Exception RBex) {
                    throw new RollBackException("Error in transaction rollback: " + RBex.Message, ex);
                } 
                throw new DatabaseException("Error in ReservationMapper MakeReservation: " + ex.Message);
            }
            catch (InvalidOperationException ex) {
                try {
                    transaction.Rollback();
                }
                catch (Exception RBex) {
                    throw new RollBackException("Error in transaction rollback: " + RBex.Message, ex);
                }
                throw new DatabaseException("Error in ReservationMapper MakeReservation: " + ex.Message);
            }
            finally { _conection.Close(); }
        }

        public List<Reservation> GetconflictedReservations(int houseId) {
            List<Reservation> reservations = new List<Reservation>();
            _conection.Open();
            try {
                SqlCommand command = new($"SELECT r.Id, r.Startdate, r.Enddate, r.Customer_id " +
                                         $"FROM Reservations r " +
                                         $"INNER JOIN HouseReservations hr ON  r.Id = hr.Reservation_id " +
                                         $"WHERE hr.House_id = @HouseId", _conection);
                command.Parameters.AddWithValue("@HouseId", houseId);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows) {
                    while (reader.Read()) {
                        int reservationId = (int)reader["Id"];
                        DateTime start = (DateTime)reader["Startdate"];
                        DateTime end = (DateTime)reader["Enddate"];
                        int customerId = (int)reader["Customer_id"];
                        reservations.Add(new Reservation(reservationId, start, end, customerId));
                    }
                }
            }
            catch (SqlException ex) {
                throw new DatabaseException("Error in ReservationMapper GetconflictedReservations: ", ex);
            }
            catch (InvalidOperationException ex) {
                throw new DatabaseException("Error in ReservationMapper GetconflictedReservations: ", ex);
            }
            finally{ _conection.Close(); }
            return reservations;
        }

        // Werkt niet---------------------------
        public void DeleteReservationById(int reservationId) {
            _conection.Open();
            SqlTransaction transaction = _conection.BeginTransaction();

            try {
                SqlCommand command = new("DELETE FROM Reservations " +
                                         "WHERE Id = @ReservationId;", _conection);
                command.Parameters.AddWithValue("ReservationId", reservationId);
                command.ExecuteNonQuery();
                SqlCommand cmd = new("DELETE FROM HouseReservations WHERE Reservation_id = @ReservationId");
                command.Parameters.AddWithValue("ReservationId", reservationId);
                command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (SqlException ex) {
                try {
                    transaction.Rollback();
                }
                catch (Exception RBex) {
                    throw new RollBackException("Error in transaction rollback: " + RBex.Message, ex);
                }
                throw new DatabaseException("Error in ReservationMapper DeleteReservationById: " + ex.Message);
            }
            catch (InvalidOperationException ex) {
                try {
                    transaction.Rollback();
                }
                catch (Exception RBex) {
                    throw new RollBackException("Error in transaction rollback: " + RBex.Message, ex);
                }
                throw new DatabaseException("Error in ReservationMapper DeleteReservationById: " + ex.Message);
            }
            finally { _conection.Close(); }
        }
    }
}
