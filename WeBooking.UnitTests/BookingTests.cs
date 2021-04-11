using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeBooking.Business;
using WeBooking.Models;

namespace WeBooking.UnitTests
{
    [TestClass]
    public class BookingTests
    {
        private BookingBO booking;
        private List<Reservation> reservations;
        private Customer customer;

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

        [TestMethod]
        public void CreateReservation_WhenRoomAvailableForUser_CreateReservation()
        {
            //Arrange
            Customer customer = new Customer();
            DateTime desiredStartDate = new DateTime(2021, 05, 01);
            DateTime desiredEndDate = new DateTime(2021, 05, 03);

            //Act
            var result = booking.CreateReservation(customer, desiredStartDate, desiredEndDate);

            //Assert
            //Assert.IsInstanceOfType(result, typeof(Reservation));
            Assert.AreEqual("Room booked in the disired date successfuly.", result);
        }

        [TestMethod]
        public void CreateReservation_WhenRoomUnavailableForUser_ReturnAMessange()
        {
            //Arrange
            Customer customer = new Customer();
            DateTime desiredStartDate = new DateTime(2021, 04, 10);
            DateTime desiredEndDate = new DateTime(2021, 04, 13);

            //Act
            var result = booking.CreateReservation(customer, desiredStartDate, desiredEndDate);

            //Assert
            Assert.AreEqual("This disired date is already booked, please choose another one", result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateReservation_WhenDateInvalid_ReturnAnErrorMessange()
        {
            //Arrange
            Customer customer = new Customer();
            DateTime desiredStartDate = new DateTime(2021, 04, 10);
            DateTime desiredEndDate = new DateTime(2021, 04, 13);

            //Act
            var result = booking.CreateReservation(customer, desiredStartDate, desiredEndDate);
        }

        public void UpdateReservationDate_WhenUserChangeStartDateBooked_UpdateDateBooked()
        {
            //Arrange
            Customer customer = new Customer() { Id = 2 };
            DateTime changeStartDate = new DateTime(2021, 04, 25);

            //Act
            var result = booking.UpdateReservation(customer, changeStartDate);

            //Assert
            Assert.AreEqual(changeStartDate, result.StartDate);
        }

        public void UpdateReservationDate_WhenUserChangeEndDateBooked_UpdateDateBooked()
        {
            //Arrange
            Customer customer = new Customer() { Id = 2 };
            DateTime changeEndDate = new DateTime(2021, 04, 28);

            //Act
            var result = booking.UpdateReservation(customer, changeEndDate);

            //Assert
            Assert.AreEqual(changeEndDate, result.EndDate);
        }


    } 
}
