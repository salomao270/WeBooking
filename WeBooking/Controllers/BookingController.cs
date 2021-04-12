using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using System.Web.Mvc;
using WeBooking.Business;
using WeBooking.Models;

namespace WeBooking.Controllers
{
    public class BookingController : ApiController
    {
        private readonly BookingBO bookingBO;
        public List<Reservation> Reservations { get; set; }
        public BookingController()
        {
            bookingBO = new BookingBO();
        }

        [Route("api/booking/reservations")]
        [HttpGet]
        public IEnumerable<Reservation> GetReservations()
        {
            // As this app doesn't have database to store data. It will works only with mocks, to do it uncomment mock code on BookingBO.cs constructor
            return bookingBO.GetReservations();
        }

        [Route("api/booking/roomstatus")]
        [HttpGet]
        public IHttpActionResult GetRoomStatus([FromBody] Reservation reservation)
        {
            if (reservation == null)
            {
                return NotFound();
            }

            if (bookingBO.IsRoomAvailable(reservation.StartDate, reservation.EndDate))
            {
                return Ok("The room is avaible for this date!");
            }
            else
            {
                return Ok("The room is not available for this date! Please choose another date");
            }
        }

        [Route("api/booking/bookreservation")]
        [HttpPost]
        public IHttpActionResult Post([FromBody] Reservation reservation)
        {
            if (reservation == null || reservation.Customer == null || reservation.StartDate == null || reservation.EndDate == null)
            {
                return BadRequest("Please enter a valid informations for the reservation.");
            }

            ResponseContainer result = bookingBO.CreateReservation(reservation.Customer, reservation.StartDate, reservation.EndDate);

            return Ok(result);
        }

        [Route("api/booking/changereservation")]
        public IHttpActionResult Put([FromBody] Reservation reservation)
        {
            if (reservation == null || reservation.Id == 0 || reservation.Customer == null || reservation.StartDate == null || reservation.EndDate == null)
            {
                return BadRequest("Please enter a valid information for the reservation.");
            }

            ResponseContainer result = bookingBO.UpdateReservation(reservation, reservation.StartDate, reservation.EndDate);

            return Ok(result);
        }

        public IHttpActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest("Please enter a valid information for the reservation.");
            }

            Reservation reservationToRemove = bookingBO.Reservations.Find(r => r.Id.Equals(id));
            ResponseContainer result = bookingBO.RemoveReservation(reservationToRemove);

            return Ok(result.Message);
        }
    }
}
