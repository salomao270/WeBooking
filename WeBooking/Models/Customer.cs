using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeBooking.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int DocumentNumber { get; set; }
    }
}