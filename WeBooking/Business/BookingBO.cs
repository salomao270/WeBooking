using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeBooking.Models;

namespace WeBooking.Business
{
    public class BookingBO
    {
        public Customer Customer1 { get; set; }
        public Customer Customer2 { get; set; }
        public Customer Customer3 { get; set; }
        public Room Room { get; set; }
        public Reservation Reservation { get; set; }
        public List<Reservation> Reservations { get; set; }

        public BookingBO()
        {
            //MOCK FOR TESTS IN BROWSER BY API
            //Customer1 = new Customer();
            //Customer1.Id = 1;
            //Customer1.Name = "Justin Trudeau";
            //Customer1.Phone = "+1 1212-3434";
            //Customer1.Email = "justin@email.com";
            //Customer1.DocumentNumber = 123456;
            //Customer1.DateOfBirth = new DateTime(1971, 12, 25);

            //Customer2 = new Customer();
            //Customer2.Id = 2;
            //Customer2.Name = "Joseph Macron";
            //Customer2.Phone = "+1 9000-9000";
            //Customer2.Email = "joseph@email.com";
            //Customer2.DocumentNumber = 67890;
            //Customer2.DateOfBirth = new DateTime(1980, 04, 02);

            //Customer3 = new Customer();
            //Customer3.Id = 3;
            //Customer3.Name = "Mary Williams";
            //Customer3.Phone = "+1 8000-8000";
            //Customer3.Email = "joseph@email.com";
            //Customer3.DocumentNumber = 98765;
            //Customer3.DateOfBirth = new DateTime(1992, 02, 10);

            //Room = new Room() { Id = 1 };

            //Reservations = new List<Reservation>();
            //Reservations.Add(new Reservation() { Id = 1, Customer = Customer1, Room = Room, StartDate = new DateTime(2021, 04, 07), EndDate = new DateTime(2021, 04, 08) });
            //Reservations.Add(new Reservation() { Id = 2, Customer = Customer2, Room = Room, StartDate = new DateTime(2021, 04, 09), EndDate = new DateTime(2021, 04, 10) });
            //Reservations.Add(new Reservation() { Id = 3, Customer = Customer3, Room = Room, StartDate = new DateTime(2021, 04, 11), EndDate = new DateTime(2021, 04, 13) });
        }

        public IEnumerable<Reservation> GetReservations()
        {
            return Reservations;
        }

        public bool IsRoomAvailable(DateTime desiredStartDate, DateTime desiredEndDate)
        {
            return !(Reservations.Any(r => desiredStartDate.AddDays(1) >= r.StartDate && desiredEndDate.AddDays(1) <= r.EndDate));
        }

        public ResponseContainer CreateReservation(Customer customer, DateTime desiredStartDate, DateTime desiredEndDate)
        {
            ResponseContainer response = new ResponseContainer();
            try
            {
                if (customer != null && desiredStartDate != null && desiredEndDate != null)
                {
                    if (IsRoomAvailable(desiredStartDate, desiredEndDate))
                    {
                        Reservation = new Reservation()
                        {
                            Id = Reservations.Count + 1,
                            Customer = customer,
                            Room = Room,
                            StartDate = desiredStartDate,
                            EndDate = desiredEndDate
                        };
                        Reservations.Add(Reservation);
                        response.Content = Reservation;
                        response.Message = "Reservation has been successfully booked !";
                    }
                    else
                    {
                        response.Message = "This Reservation date is not available! Please try another date.";
                    }
                }
                else
                {
                    response.Message = "Please enter a valid information";
                }
            }
            catch (Exception)
            {
                throw new ArgumentException("It occurs an error, please try anoter day");
            }
            return response;
        }

        public ResponseContainer UpdateReservation(Reservation reservation, DateTime changeStartDate, DateTime changeEndDate)
        {
            ResponseContainer response = new ResponseContainer();

            foreach (var item in Reservations)
            {
                if (item.Id == reservation.Id )
                {
                    item.StartDate = changeStartDate;
                    item.EndDate = changeEndDate;
                    response.Content = item;
                    break;
                }
            }
            response.Message = "This Reservation date has been successfully updated";
            return response;
        }

        public ResponseContainer RemoveReservation(Reservation reservationToRemove)
        {
            ResponseContainer response = new ResponseContainer();
            if (reservationToRemove != null)
            {
                Reservations.Remove(reservationToRemove);
                response.Message = "This reservation has been successfuly canceled";
            }
            return response;            
        }
    }
}