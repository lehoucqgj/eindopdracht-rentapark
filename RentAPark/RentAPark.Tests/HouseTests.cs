using RentAPark.Domain.Models;
using System;
using Xunit;

namespace RentAPark.Tests {
    public class HouseTests {
        [Fact]
        public void Constructor_ShouldInitializeProperties() {
            // Arrange
            int id = 1;
            string street = "Sleepstraat";
            string number = "211";
            bool active = true;
            int maxGuests = 4;

            // Act
            House house = new House(id, street, number, active, maxGuests);

            // Assert
            Assert.Equal(id, house.Id);
            Assert.Equal(street, house.Street);
            Assert.Equal(number, house.Number);
            Assert.Equal(active, house.Active);
            Assert.Equal(maxGuests, house.MaxGuests);
        }

        [Fact]
        public void Constructor_ShouldThrowArgumentOutOfRangeException_ForInvalidId() {
            // Arrange
            int invalidId = 0;
            string street = "Arsenaalstraat";
            string number = "31";
            bool active = true;
            int maxGuests = 4;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new House(invalidId, street, number, active, maxGuests));
        }

        [Fact]
        public void Constructor_ShouldThrowArgumentOutOfRangeException_ForInvalidMaxGuests() {
            // Arrange
            int id = 1;
            string street = "Vijverhof";
            string number = "354";
            bool active = true;
            int invalidMaxGuests = 0;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new House(id, street, number, active, invalidMaxGuests));
        }

        [Fact]
        public void Street_Setter_ShouldThrowArgumentException_ForNullStreet() {
            // Arrange
            House house = new House(1, "Heidestraat", "54", true, 4);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => house.Street = null);
        }

        [Fact]
        public void Street_Setter_ShouldThrowArgumentException_ForWhiteSpaceStreet() {
            // Arrange
            House house = new House(1, "kapellestraat", "1", true, 4);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => house.Street = "   ");
        }

        [Fact]
        public void Number_Setter_ShouldThrowArgumentException_ForNullNumber() {
            // Arrange
            House house = new House(1, "hakkerstraat", "354", true, 4);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => house.Number = null);
        }

        [Fact]
        public void Number_Setter_ShouldThrowArgumentException_ForWhiteSpaceNumber() {
            // Arrange
            House house = new House(1, "pijnboompitstraat", "54", true, 4);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => house.Number = "   ");
        }

        [Fact]
        public void ToString_ShouldReturnCorrectFormat() {
            // Arrange
            int id = 1;
            string street = "dezestraat";
            string number = "13";
            House house = new House(id, street, number, true, 4);

            // Act
            string result = house.ToString();

            // Assert
            Assert.Equal("dezestraat 13", result);
        }
    }
}