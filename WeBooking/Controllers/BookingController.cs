using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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

        [Route("api/booking/status")]
        [HttpGet]
        public string GetRoomAvailability([FromBody] DateTime dateTime)
        {
            //TODO
            if (bookingBO.IsRoomAvailable(dateTime))
            {
                return "Room available for this date";
            }
            else
            {
                return "Room is unavailable for this date";
            }
        }

        [Route("api/booking/reservation")]
        [HttpPost]
        public void BookReservation([FromBody] Reservation reservation)
        {
            bookingBO.Reservations.Add(reservation);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            //TODO
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            //TODO
        }
    }
}
