using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainReservation.Models
{
    public class Train
    {
        public int TrainId { get; set; }
        public string TrainName { get; set; }
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int AvailableSeats { get; set; }
        public string DepratureRoute { get; set; }
        public string ReturnRoute { get; set; }
        public DateTime ReturnTime { get; set; }
    }
}