using DatabasePopulator.Persistence;
using Microsoft.Data.SqlClient;
using System.Globalization;

namespace DatabasePopulator.Main {
    public class TxtToTable {
        private SqlConnection _connection = new(DbInfo.ConnectionString);



        public void UpdateCustomerTable(string path) {
            try {
                StreamReader streamReader = new(path);
                _connection.Open();
                string line;
                while ((line = streamReader.ReadLine()) != null) {
                    string[] columnData = line.Split('|');

                    SqlCommand cmd = new("SET IDENTITY_INSERT Customers ON;" +
                                         "IF NOT EXISTS (SELECT Id FROM Customers WHERE Id = @Id) " +
                                         "BEGIN " +
                                         "INSERT INTO Customers (Id, Name, Address) VALUES (@Id, @Name, @Address);" +
                                         "END;" +
                                         "SET IDENTITY_INSERT Customers OFF;", _connection);

                    cmd.Parameters.Add(new SqlParameter("@Id", columnData[0]));
                    cmd.Parameters.Add(new SqlParameter("@Name", columnData[1]));
                    cmd.Parameters.Add(new SqlParameter("@Address", columnData[2]));

                    cmd.ExecuteNonQuery();

                }
            }
            //catch { }
            finally { _connection.Close(); }
        }

        public void UpdateFacilitiesTable(string path) {
            try {
                StreamReader streamReader = new(path);
                _connection.Open();

                string line;
                while ((line = streamReader.ReadLine()) != null) {
                    string[] columnData = line.Split(',');

                    SqlCommand cmd = new("SET IDENTITY_INSERT Facilities ON;" +
                                         "IF NOT EXISTS (SELECT Id FROM Facilities WHERE Id = @Id)" +
                                         "BEGIN " +
                                         "INSERT INTO Facilities (Id, Description) VALUES (@Id, @Description); " +
                                         "END;" +
                                         "SET IDENTITY_INSERT Facilities OFF;", _connection);

                    cmd.Parameters.Add(new SqlParameter("@Id", columnData[0]));
                    cmd.Parameters.Add(new SqlParameter("@Description", columnData[1]));

                    cmd.ExecuteNonQuery();

                }
            }
            //catch { }
            finally { _connection.Close(); }
        }
        public void UpdateHouseReservationsTable(string path) {
            try {
                StreamReader streamReader = new(path);
                _connection.Open();

                string line;
                while ((line = streamReader.ReadLine()) != null) {
                    string[] columnData = line.Split(',');

                    SqlCommand cmd = new("IF NOT EXISTS (SELECT House_id, Reservation_id " +
                                        "FROM HouseReservations WHERE House_id = @House_id " +
                                                                   "AND Reservation_id = @Reservation_id)" +
                                         "BEGIN " +
                                         "INSERT INTO HouseReservations (House_id, Reservation_id) VALUES (@House_id, @Reservation_id);" +
                                         "END;", _connection);

                    cmd.Parameters.Add(new SqlParameter("@House_id", columnData[0]));
                    cmd.Parameters.Add(new SqlParameter("@Reservation_id", columnData[1]));

                    cmd.ExecuteNonQuery();

                }
            }
            //catch { }
            finally { _connection.Close(); }
        }

        public void UpdateHousesTable(string path) {
            try {
                StreamReader streamReader = new(path);
                _connection.Open();
                string line;
                if (streamReader.ReadLine() == null) {
                    throw new NullReferenceException();
                }
                while ((line = streamReader.ReadLine()) != null) {
                    string[] columnData = line.Split(',');

                    SqlCommand cmd = new("SET IDENTITY_INSERT Houses ON;" +
                                         "IF NOT EXISTS (SELECT Id FROM Houses WHERE Id = @Id) " +
                                         "BEGIN " +
                                         "INSERT INTO Houses (Id, Street, Number, Active, MaxPersons) VALUES (@Id, @Street, @Number, @Active, @MaxPersons);" +
                                         "END;" +
                                         "SET IDENTITY_INSERT Houses OFF;", _connection);

                    cmd.Parameters.Add(new SqlParameter("@Id", columnData[0]));
                    cmd.Parameters.Add(new SqlParameter("@Street", columnData[1]));
                    cmd.Parameters.Add(new SqlParameter("@Number", columnData[2]));
                    cmd.Parameters.Add(new SqlParameter("@Active", columnData[3]));
                    cmd.Parameters.Add(new SqlParameter("@MaxPersons", columnData[4]));

                    cmd.ExecuteNonQuery();

                }
            }

            finally { _connection.Close(); }
        }
        public void UpdateParksTable(string path) {
            try {
                StreamReader streamReader = new(path);
                _connection.Open();
                string line;
                while ((line = streamReader.ReadLine()) != null) {
                    string[] columnData = line.Split(',');

                    SqlCommand cmd = new("SET IDENTITY_INSERT Parks ON;" +
                                         "IF NOT EXISTS (SELECT Id FROM Parks WHERE Id = @Id) " +
                                         "BEGIN " +
                                         "INSERT INTO Parks (Id, Name, Location) VALUES (@Id, @Name, @Location);" +
                                         "END;" +
                                         "SET IDENTITY_INSERT Parks OFF;", _connection);

                    cmd.Parameters.Add(new SqlParameter("@Id", columnData[0]));
                    cmd.Parameters.Add(new SqlParameter("@Name", columnData[1]));
                    cmd.Parameters.Add(new SqlParameter("@Location", columnData[2]));

                    cmd.ExecuteNonQuery();

                }
            }
            //catch { }
            finally { _connection.Close(); }
        }

        public void UpdateParksFacilitiesTable(string path) {
            try {
                StreamReader streamReader = new(path);
                _connection.Open();

                string line;
                while ((line = streamReader.ReadLine()) != null) {
                    string[] columnData = line.Split(',');

                    SqlCommand cmd = new("IF NOT EXISTS (SELECT Park_id, Facility_id " +
                                        "FROM ParksFacilities WHERE Park_id = @Park_id " +
                                                                   "AND Facility_id = @Facility_id)" +
                                         "BEGIN " +
                                         "INSERT INTO ParksFacilities (Park_id, Facility_id) VALUES (@Park_id, @Facility_id);" +
                                         "END;", _connection);

                    cmd.Parameters.Add(new SqlParameter("@Park_id", columnData[0]));
                    cmd.Parameters.Add(new SqlParameter("@Facility_id", columnData[1]));

                    cmd.ExecuteNonQuery();

                }
            }
            //catch { }
            finally { _connection.Close(); }
        }
        public void UpdateParksHousesTable(string path) {
            try {
                StreamReader streamReader = new(path);
                _connection.Open();

                string line;
                while ((line = streamReader.ReadLine()) != null) {
                    string[] columnData = line.Split(',');

                    SqlCommand cmd = new("IF NOT EXISTS (SELECT Park_id, House_id " +
                                        "FROM ParksHouses WHERE Park_id = @Park_id " +
                                                                   "AND House_id = @House_id)" +
                                         "BEGIN " +
                                         "INSERT INTO ParksHouses (Park_id, House_id) VALUES (@Park_id, @House_id);" +
                                         "END;", _connection);

                    cmd.Parameters.Add(new SqlParameter("@Park_id", columnData[0]));
                    cmd.Parameters.Add(new SqlParameter("@House_id", columnData[1]));

                    cmd.ExecuteNonQuery();

                }
            }
            //catch { }
            finally { _connection.Close(); }
        }

        public void UpdateReservationsTable(string path) {
            try {
                StreamReader streamReader = new(path);
                _connection.Open();
                string line;
                while ((line = streamReader.ReadLine()) != null) {
                    string[] columnData = line.Split(',');

                    SqlCommand cmd = new("SET IDENTITY_INSERT Reservations ON;" +
                                         "IF NOT EXISTS (SELECT Id FROM Reservations WHERE Id = @Id) " +
                                         "BEGIN " +
                                         "INSERT INTO Reservations (Id, Startdate, Enddate, Customer_id) VALUES (@Id, @Startdate, @Enddate, @Customer_id);" +
                                         "END;" +
                                         "SET IDENTITY_INSERT Reservations OFF;", _connection);

                    cmd.Parameters.Add(new SqlParameter("@Id", columnData[0]));
                    cmd.Parameters.Add(new SqlParameter("@StartDate", ConvertToSqlFormattedDate(columnData[1])));
                    cmd.Parameters.Add(new SqlParameter("@Enddate", ConvertToSqlFormattedDate(columnData[2])));
                    cmd.Parameters.Add(new SqlParameter("@Customer_id", columnData[3]));

                    cmd.ExecuteNonQuery();

                }
            }
            catch (FormatException) {
                throw new FormatException();
            }
            finally { _connection.Close(); }
        }


        private string ConvertToSqlFormattedDate(string date) {
            string[] formats = { "d/M/yyyy H:mm:ss", "dd/MM/yyyy H:mm:ss" };
            if (DateTime.TryParseExact(date, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate)) {
                return parsedDate.ToString("yyyy-MM-dd H:mm:ss");
            }
            else throw new FormatException();
        }



    }
}
