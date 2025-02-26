using RentAPark.Domain.Models;
using System;
using Xunit;

namespace RentAPark.Tests {
    public class FacilityTests {
        [Fact]
        public void Constructor_ShouldInitializeProperties() {
            // Arrange
            int id = 1;
            string description = "Vuurput";

            // Act
            Facility facility = new Facility(id, description);

            // Assert
            Assert.Equal(id, facility.Id);
            Assert.Equal(description, facility.Description);
        }

        [Fact]
        public void Constructor_ShouldThrowArgumentException_ForNullDescription() {
            // Arrange
            int id = 1;
            string nullDescription = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Facility(id, nullDescription));
        }

        [Fact]
        public void Constructor_ShouldThrowArgumentException_ForWhiteSpaceDescription() {
            // Arrange
            int id = 1;
            string whiteSpaceDescription = "   ";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Facility(id, whiteSpaceDescription));
        }

        [Fact]
        public void Description_Setter_ShouldThrowArgumentException_ForNullDescription() {
            // Arrange
            Facility facility = new Facility(1, "Schoenpoetsstation");

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => facility.Description = null);
        }

        [Fact]
        public void Description_Setter_ShouldThrowArgumentException_ForWhiteSpaceDescription() {
            // Arrange
            Facility facility = new Facility(1, "Petanque");

            // Act & Assert
            Assert.Throws<ArgumentException>(() => facility.Description = "   ");
        }

        [Fact]
        public void ToString_ShouldReturnCorrectFormat() {
            // Arrange
            int id = 1;
            string description = "Turnhal";
            Facility facility = new Facility(id, description);

            // Act
            string result = facility.ToString();

            // Assert
            Assert.Equal("Turnhal", result);
        }
    }
}