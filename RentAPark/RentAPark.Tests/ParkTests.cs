using RentAPark.Domain.Models;
using System;
using Xunit;

namespace RentAPark.Tests {
    public class ParkTests {
        [Fact]
        public void Constructor_ShouldInitializeProperties() {
            // Arrange
            int id = 1;
            string name = "Liedemeerspark";
            string location = "Merelbeke";

            // Act
            Park park = new Park(id, name, location);

            // Assert
            Assert.Equal(id, park.Id);
            Assert.Equal(name, park.Name);
            Assert.Equal(location, park.Location);
        }

        [Fact]
        public void Constructor_ShouldThrowArgumentOutOfRangeException_ForInvalidId() {
            // Arrange
            int invalidId = 0;
            string name = "Meersen";
            string location = "Gentbrugge";

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Park(invalidId, name, location));
        }

        [Fact]
        public void Name_Setter_ShouldThrowArgumentException_ForNullName() {
            // Arrange
            Park park = new Park(1, "Kiekespark", "Gent");

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => park.Name = null);
        }

        [Fact]
        public void Name_Setter_ShouldThrowArgumentException_ForWhiteSpaceName() {
            // Arrange
            Park park = new Park(1, "Ertvelde park", "Ertvelde");

            // Act & Assert
            Assert.Throws<ArgumentException>(() => park.Name = "   ");
        }

        [Fact]
        public void Location_Setter_ShouldThrowArgumentException_ForNullLocation() {
            // Arrange
            Park park = new Park(1, "Meersen", "Gentbrugge");

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => park.Location = null);
        }

        [Fact]
        public void Location_Setter_ShouldThrowArgumentException_ForWhiteSpaceLocation() {
            // Arrange
            Park park = new Park(1, "Magiepark", "Dilbeek");

            // Act & Assert
            Assert.Throws<ArgumentException>(() => park.Location = "   ");
        }

        [Fact]
        public void ToString_ShouldReturnCorrectFormat() {
            // Arrange
            int id = 1;
            string name = "Meersen";
            string location = "Gentbrugge";
            Park park = new Park(id, name, location);

            // Act
            string result = park.ToString();

            // Assert
            Assert.Equal("Meersen - Gentbrugge", result);
        }
    }
}