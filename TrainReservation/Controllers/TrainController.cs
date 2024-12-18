using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainReservation.Models;
namespace TrainReservation.Controllers
{
    public class TrainController : Controller
    {
        private static List<Ticket> tickets = new List<Ticket>();
        private static List<Train> trains = new List<Train>
        {
            new Train {TrainId=1,TrainName="قطار 1",Departure="تهران",Arrival="مشهد",DepartureTime=DateTime.Now.AddHours(2),ArrivalTime=DateTime.Now.AddHours(6),AvailableSeats=50 },
                new Train {TrainId=2,TrainName="قطار 2",Departure="تهران",Arrival="شیراز",DepartureTime=DateTime.Now.AddHours(4),ArrivalTime=DateTime.Now.AddHours(8),AvailableSeats=30 }
        };
       
        // GET: Train
        public ActionResult Index()
        {
            return View(trains);
        }
        [HttpGet]
        public ActionResult ReserveTicket(int id)
        {
            Console.WriteLine($"TrainId Recived:{id}");
            var train = trains.FirstOrDefault(t => t.TrainId == id);
                if(train==null)
            {
                return HttpNotFound();
             
            }    
            return View(train);
        }
        [HttpPost]
        public ActionResult ReserveTicket(int trainId,string passengerName)
        {
            var train = trains.FirstOrDefault(t => t.TrainId == trainId);
            if (train == null||train.AvailableSeats<=0)
            {
                ViewBag.ErrorMessage = "قطار موجود نیست";
                return View(train);
            }
            var ticket = new Ticket
            {
                TicketId = tickets.Count + 1,
                TrainId = trainId,
                PassengerName = passengerName,
                ReturnRoute = train.ReturnRoute,
                DepratureRoute = train.DepratureRoute,
               ReturnTime=train.ReturnTime,
               ReservationDate = DateTime.Now,
               DepartureTime=train.DepartureTime
            };
            tickets.Add(ticket);
            train.AvailableSeats--;
            return RedirectToAction("TicketList");
        }
        public ActionResult TicketList()
        {
            return View(tickets);

        }
    }
}