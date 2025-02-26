using RentAPark.Domain.Models;
using System;
using Xunit;

namespace RentAPark.Tests {
    public class CustomerTests {
        [Fact]
        public void Constructor_ShouldInitializeProperties() {
            // Arrange
            int id = 1;
            string name = "Jan Jannsens";
            string address = "kerkuilstraat 35";

            // Act
            Customer customer = new Customer(id, name, address);

            // Assert
            Assert.Equal(id, customer.Id);
            Assert.Equal(name, customer.Name);
            Assert.Equal(address, customer.Address);
        }

        [Fact]
        public void Constructor_ShouldThrowArgumentOutOfRangeException_ForInvalidId() {
            // Arrange
            int invalidId = 0;
            string name = "Mark Rohart";
            string address = "Dorpsplein 20";

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Customer(invalidId, name, address));
        }

        [Fact]
        public void Constructor_ShouldThrowArgumentNullException_ForNullName() {
            // Arrange
            int id = 1;
            string nullName = null;
            string address = "Arsenaalstraat 69";

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Customer(id, nullName, address));
        }

        [Fact]
        public void Constructor_ShouldThrowArgumentNullException_ForNullAddress() {
            // Arrange
            int id = 1;
            string name = "Wolfgang Amadeus Mozart";
            string nullAddress = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Customer(id, name, nullAddress));
        }

        [Fact]
        public void ToString_ShouldReturnCorrectFormat() {
            // Arrange
            int id = 1;
            string name = "Gertjan Lehoucq";
            string address = "Beukenstraat 420";
            Customer customer = new Customer(id, name, address);

            // Act
            string result = customer.ToString();

            // Assert
            Assert.Equal("Gertjan Lehoucq - Beukenstraat 420", result);
        }
    }
}