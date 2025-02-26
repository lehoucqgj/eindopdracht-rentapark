using RentAPark.Domain.Models;
using System;
using Xunit;

namespace RentAPark.Tests {
    public class ReservationTests {
        [Fact]
        public void Constructor_ShouldInitializeProperties() {
            // Arrange
            int id = 1;
            int customerId = 2;
            DateTime startDate = new DateTime(2023, 1, 1);
            DateTime endDate = new DateTime(2023, 1, 10);

            // Act
            Reservation reservation = new Reservation(id, startDate, endDate, customerId);

            // Assert
            Assert.Equal(id, reservation.Id);
            Assert.Equal(customerId, reservation.CustomerId);
            Assert.Equal(startDate, reservation.StartDate);
            Assert.Equal(endDate, reservation.Enddate);
        }

        [Fact]
        public void Constructor_ShouldThrowArgumentOutOfRangeException_ForInvalidId() {
            // Arrange
            int invalidId = 0;
            int customerId = 2;
            DateTime startDate = new DateTime(2023, 1, 1);
            DateTime endDate = new DateTime(2023, 1, 10);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Reservation(invalidId, startDate, endDate, customerId));
        }

        [Fact]
        public void Constructor_ShouldThrowArgumentOutOfRangeException_ForInvalidCustomerId() {
            // Arrange
            int id = 1;
            int invalidCustomerId = 0;
            DateTime startDate = new DateTime(2023, 1, 1);
            DateTime endDate = new DateTime(2023, 1, 10);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Reservation(id, startDate, endDate, invalidCustomerId));
        }

        [Fact]
        public void ToString_ShouldReturnCorrectFormat() {
            // Arrange
            int id = 1;
            int customerId = 2;
            DateTime startDate = new DateTime(2023, 1, 1);
            DateTime endDate = new DateTime(2023, 1, 10);
            Reservation reservation = new Reservation(id, startDate, endDate, customerId);

            // Act
            string result = reservation.ToString();

            // Assert
            Assert.Equal("Reservation: 1 Customer: 2 | 01/01/2023 - 10/01/2023 ", result);
        }
    }
}