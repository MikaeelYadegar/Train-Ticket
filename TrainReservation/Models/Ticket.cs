using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainReservation.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public int TrainId { get; set; }
        public string PassengerName { get; set; }
        public string DepratureRoute { get; set; }
        public string ReturnRoute { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime ReturnTime { get; set; }
        public DateTime DepartureTime { get; set; }
    }
}