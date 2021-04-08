﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeBooking.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public Room Room { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool isAvailable { get; set; }
    }
}