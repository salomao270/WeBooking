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
        private Customer customer1;
        private Customer customer2;
        private Customer customer3;

        [TestInitialize]
        public void Initializer()
        {
            //MOCK FOR UNIT TESTS
            booking = new BookingBO();
            reservations = new List<Reservation>();

            customer1 = new Customer();
            customer1.Id = 1;
            customer1.Name = "Justin Trudeau";
            customer1.Phone = "+1 1212-3434";
            customer1.Email = "justin@email.com";
            customer1.DocumentNumber = 123456;
            customer1.DateOfBirth = new DateTime(1971, 12, 25);

            customer2 = new Customer();
            customer2.Id = 2;
            customer2.Name = "Joseph Macron";
            customer2.Phone = "+1 9000-9000";
            customer2.Email = "joseph@email.com";
            customer2.DocumentNumber = 67890;
            customer2.DateOfBirth = new DateTime(1980, 04, 02);

            customer3 = new Customer();
            customer3.Id = 3;
            customer3.Name = "Mary Williams";
            customer3.Phone = "+1 8000-8000";
            customer3.Email = "joseph@email.com";
            customer3.DocumentNumber = 98765;
            customer3.DateOfBirth = new DateTime(1992, 02, 10);

            Room Room = new Room() { Id = 1 };

            List<Reservation> Reservations = new List<Reservation>();
            Reservations.Add(new Reservation() { Id = 1, Customer = customer1, Room = Room, StartDate = new DateTime(2021, 04, 07), EndDate = new DateTime(2021, 04, 08) });
            Reservations.Add(new Reservation() { Id = 2, Customer = customer2, Room = Room, StartDate = new DateTime(2021, 04, 09), EndDate = new DateTime(2021, 04, 10) });
            Reservations.Add(new Reservation() { Id = 3, Customer = customer3, Room = Room, StartDate = new DateTime(2021, 04, 11), EndDate = new DateTime(2021, 04, 13) });
            booking.Reservations = Reservations;
        }

        [TestMethod]
        public void IsRoomAvailable_WhenCustomerDateExistInRoomBooked_ReturnFalse()
        {
            //Arrange
            reservations.Add(new Reservation()
            {
                Id = 1,
                Customer = new Customer() { Name = "Justin Trudeau", Id = 4 },
                Room = new Room() { Id = 1 },
                StartDate = new DateTime(2021, 04, 10),
                EndDate = new DateTime(2021, 04, 13)
            });

            //Act
            string desiredStartDateToBook = "10-04-2021 07:50:00:AM";
            string desiredEndDateToBOok = "11-04-2021 07:50:00:AM";
            var result = booking.IsRoomAvailable(DateTime.ParseExact(desiredStartDateToBook, "dd-MM-yyyy hh:mm:ss:tt", CultureInfo.InvariantCulture),
                                                DateTime.ParseExact(desiredEndDateToBOok, "dd-MM-yyyy hh:mm:ss:tt", CultureInfo.InvariantCulture));

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsRoomAvailable_WhenCustomerDateDontExistInRoomBooked_ReturnTrue()
        {
            //Arrange
            reservations.Add(new Reservation()
            {
                Id = 2,
                Customer = new Customer() { Name = "Justin Trudeau", Id = 5 },
                Room = new Room() { Id = 1 },
                StartDate = new DateTime(2021, 04, 06),
                EndDate = new DateTime(2021, 04, 09)
            });

            //Act
            string desiredStartDateToBook = "15-05-2021 07:50:00:AM";
            string desiredEndDateToBOok = "16-05-2021 07:50:00:AM";
            var result = booking.IsRoomAvailable(DateTime.ParseExact(desiredStartDateToBook, "dd-MM-yyyy hh:mm:ss:tt", CultureInfo.InvariantCulture),
                                                DateTime.ParseExact(desiredEndDateToBOok, "dd-MM-yyyy hh:mm:ss:tt", CultureInfo.InvariantCulture));

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CreateReservation_WhenRoomAvailableForCustomer_CreateReservation()
        {
            //Arrange
            Customer customer = new Customer() { Name = "Justin Trudeau", Id = 6 };
            DateTime desiredStartDate = new DateTime(2021, 05, 01);
            DateTime desiredEndDate = new DateTime(2021, 05, 03);

            //Act
            var result = booking.CreateReservation(customer, desiredStartDate, desiredEndDate);

            //Assert
            CollectionAssert.Contains(booking.Reservations, result.Content);
        }

        [TestMethod]
        public void CreateReservation_WhenRoomUnavailableForCustomer_DontCreateReservation()
        {
            //Arrange
            Customer customer = new Customer() { Name = "Justin Trudeau", Id = 7 };
            DateTime desiredStartDate = new DateTime(2021, 04, 10);
            DateTime desiredEndDate = new DateTime(2021, 04, 12);

            //Act
            var result = booking.CreateReservation(customer, desiredStartDate, desiredEndDate);

            //Assert
            CollectionAssert.DoesNotContain(booking.Reservations, result.Content);
        }

        [TestMethod]
        public void UpdateReservationDate_WhenCustomerChangeEndDateBooked_UpdateDateBooked()
        {
            //Arrange
            DateTime changeStartDate = new DateTime(2021, 05, 10);
            DateTime changeEndDate = new DateTime(2021, 05, 13);
            Reservation reservation = booking.Reservations.Find(r => r.Id == 1);

            //Act
            booking.UpdateReservation(reservation, changeStartDate, changeEndDate);

            //Assert
            Assert.AreEqual(changeStartDate, reservation.StartDate);
            Assert.AreEqual(changeEndDate, reservation.EndDate);
        }

        [TestMethod]
        public void RemoveReservation_WhenCustomerRemoveReservation_RemoveReservationFromBookingList()
        {
            //Arrange
            Reservation reservationToRemove = reservations.Find(r => r.Customer.Id.Equals(customer1.Id));

            //Act
            var result = booking.RemoveReservation(reservationToRemove);

            //Assert
            CollectionAssert.DoesNotContain(booking.Reservations, reservationToRemove);
        }

    } 
}
