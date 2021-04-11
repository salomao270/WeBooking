using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeBooking.Models;

namespace WeBooking.Business
{
    public class BookingBO
    {
        public List<Reservation> Reservations { get; set; }
        public Room Room { get; set; }

        public BookingBO()
        {
            //mock
            Customer Customer1 = new Customer();
            Customer1.Id = 1;
            Customer1.Name = "Justin Trudeau";
            Customer1.Phone = "+1 1212-3434";
            Customer1.Email = "justin@email.com";
            Customer1.DocumentNumber = 123456;
            Customer1.DateOfBirth = new DateTime(1971, 12, 25);

            Customer Customer2 = new Customer();
            Customer2.Id = 2;
            Customer2.Name = "Joseph Macron";
            Customer2.Phone = "+1 9000-9000";
            Customer2.Email = "joseph@email.com";
            Customer2.DocumentNumber = 67890;
            Customer2.DateOfBirth = new DateTime(1980, 04, 02);

            Customer Customer3 = new Customer();
            Customer3.Id = 3;
            Customer3.Name = "Mary Williams";
            Customer3.Phone = "+1 8000-8000";
            Customer3.Email = "joseph@email.com";
            Customer3.DocumentNumber = 98765;
            Customer3.DateOfBirth = new DateTime(1992, 02, 10);

            Room = new Room() { Id = 1 };

            Reservations = new List<Reservation>();
            Reservations.Add(new Reservation() { Id = 1, Customer = Customer1, Room = Room, StartDate = new DateTime(2021, 04, 08), EndDate = new DateTime(2021, 04, 09) });
            Reservations.Add(new Reservation() { Id = 2, Customer = Customer2, Room = Room, StartDate = new DateTime(2021, 04, 09), EndDate = new DateTime(2021, 04, 11) });
            Reservations.Add(new Reservation() { Id = 3, Customer = Customer3, Room = Room, StartDate = new DateTime(2021, 04, 12), EndDate = new DateTime(2021, 04, 14) });
        }

        public IEnumerable<Reservation> GetReservations()
        {
            return Reservations;
        }

        public bool IsRoomAvailable(DateTime dateTime)
        {
            bool isAvailable = true;
            if (Reservations.Any(r => r.StartDate <= dateTime.AddDays(1) && dateTime.AddDays(1) <= r.EndDate))
            {
                isAvailable = false;
            }
            return isAvailable;
        }
    }
}