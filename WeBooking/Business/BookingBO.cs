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
        public Customer Customer { get; set; }
        public Room Room { get; set; }

        public BookingBO()
        {
            //mock
            Customer = new Customer();
            Customer.Id = 1;
            Customer.Name = "Justin Trudeau";
            Customer.Phone = "+1 1212-3434";
            Customer.Email = "justin@email.com";
            Customer.DocumentNumber = 123456;
            Customer.DateOfBirth = new DateTime(1971, 12, 25);

            Customer = new Customer();
            Customer.Id = 2;
            Customer.Name = "Joseph Macron";
            Customer.Phone = "+1 9000-9000";
            Customer.Email = "joseph@email.com";
            Customer.DocumentNumber = 67890;
            Customer.DateOfBirth = new DateTime(1980, 04, 02);

            Customer = new Customer();
            Customer.Id = 3;
            Customer.Name = "Mary Williams";
            Customer.Phone = "+1 8000-8000";
            Customer.Email = "joseph@email.com";
            Customer.DocumentNumber = 98765;
            Customer.DateOfBirth = new DateTime(1992, 02, 10);

            Room = new Room() { Id = 1 };

            Reservations = new List<Reservation>();
            Reservations.Add(new Reservation() { Id = 1, Customer = Customer, Room = Room, StartDate = new DateTime(2021, 04, 08), EndDate = new DateTime(2021, 04, 09) });
            Reservations.Add(new Reservation() { Id = 2, Customer = Customer, Room = Room, StartDate = new DateTime(2021, 04, 09), EndDate = new DateTime(2021, 04, 11) });
            Reservations.Add(new Reservation() { Id = 3, Customer = Customer, Room = Room, StartDate = new DateTime(2021, 04, 12), EndDate = new DateTime(2021, 04, 14) });
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