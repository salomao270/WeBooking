using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeBooking.Business;
using WeBooking.Models;

namespace WeBooking.UnitTests
{
    [TestClass]
    public class BookingTests
    {
        private BookingBO booking;
        List<Reservation> reservations;

        [TestInitialize]
        public void Initializer()
        {
            booking = new BookingBO();
            reservations = new List<Reservation>();
            booking.Reservations = reservations;
        }

        [TestMethod]
        public void IsRoomAvailable_WhenUserDateExistInRoomBooked_ReturnFalse()
        {
            //Arrange
            reservations.Add(new Reservation()
            {
                Id = 1,
                Customer = new Customer() { Name = "Justin Trudeau" },
                Room = new Room() { Id = 1 },
                StartDate = new DateTime(2021, 04, 10),
                EndDate = new DateTime(2021, 04, 12)
            });

            //Act
            string dateTimeToBook = "10-04-2021 07:50:00:AM";
            var result = booking.IsRoomAvailable(DateTime.ParseExact(dateTimeToBook, "dd-MM-yyyy hh:mm:ss:tt", CultureInfo.InvariantCulture));

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsRoomAvailable_WhenUserDateDontExistInRoomBooked_ReturnTrue()
        {
            //Arrange
            reservations.Add(new Reservation()
            {
                Id = 1,
                Customer = new Customer() { Name = "Justin Trudeau" },
                Room = new Room() { Id = 1 },
                StartDate = new DateTime(2021, 04, 06),
                EndDate = new DateTime(2021, 04, 09)
            });

            //Act
            string dateTimeToBook = "15-04-2021 07:50:00:AM";
            var result = booking.IsRoomAvailable(DateTime.ParseExact(dateTimeToBook, "dd-MM-yyyy hh:mm:ss:tt", CultureInfo.InvariantCulture));

            //Assert
            Assert.IsTrue(result);
        }

    }
}
