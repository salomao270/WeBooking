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
        public BookingController()
        {
            bookingBO = new BookingBO();
        }

        [Route("api/booking/listreservations")]
        [HttpGet]
        public IEnumerable<Reservation> GetReservations()
        {
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
                return Ok("The room is NOT avaible for this date! Please choose another date");
            }
        }

        [Route("api/booking/reservation")]
        [HttpPost]
        public IHttpActionResult Post([FromBody] Reservation reservation)
        {
            if (reservation == null)
            {
                return NotFound();
            }
            var result = bookingBO.CreateReservation(reservation.Customer, reservation.StartDate, reservation.EndDate);

            return Ok(result.Message);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] Reservation reservation)
        {

            //TODO
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            //TODO
            Reservation reservationToRemove = bookingBO.Reservations.Find(r => r.Id.Equals(id));
            bookingBO.Reservations.Remove(reservationToRemove);
        }
    }
}
