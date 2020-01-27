using RentC.Core.Contracts;
using RentC.Core.Models;
using RentC.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentC.WebUI.Controllers
{

    //[Authorize(Roles = "Admin")]
    [Authorize]
    public class ReservationController : Controller
    {
        IRepository<Reservation> context;
        IRepository<Car> cars;
        IRepository<Client> clients;

        public ReservationController(IRepository<Reservation> context, IRepository<Car> cars, IRepository<Client> clients)
        {
            this.context = context;
            this.cars = cars;
            this.clients = clients;
        }

        // GET: ProductManager
        public ActionResult Index()
        {
            string userName = System.Web.HttpContext.Current.User.Identity.Name;
            string tempUser = null;
            List<Reservation> tempReserv = new List<Reservation>();

            foreach (Client item in clients.Collection().ToList()) 
            {
                if (item.Email == userName) 
                {
                    tempUser = item.ClientName;
                }
            }
            //List<Reservation> reservations = context.Collection().ToList();
            foreach (Reservation item in context.Collection().ToList())
            {
                if (DateTime.Compare(item.EndDate, DateTime.Now) < 0)
                {
                    item.ReservStatsID = "Expired";
                }
                else {
                    item.ReservStatsID = "Active";
                }

                if (item.CustomerID == tempUser) 
                {
                    tempReserv.Add(item);
                }
            }

            
            return View(tempReserv);
            //return View(context.Collection().ToList());
        }

        //public ActionResult Create()
        //{
        //    Reservation reservations = new Reservation();
        //    return View(reservations);
        //}

        public ActionResult Create()
        {
            ReservationViewModel viewModel = new ReservationViewModel();

            viewModel.Reservation = new Reservation();
            viewModel.Cars = cars.Collection();
            viewModel.Clients = clients.Collection();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(ReservationViewModel viewModel)
        {           
            List<Reservation> reservations = context.Collection().ToList();
            List<Reservation> compareReservations = new List<Reservation>();
            bool dateIncorrect = false;
            List<DateTime> compareDateTimes = new List<DateTime>();
            foreach(Reservation item in reservations)
            {
                if (item.CarID == viewModel.Reservation.CarID)
                {
                    compareReservations.Add(item);                   
                }
            }

            foreach(Reservation item in compareReservations) 
            {
                compareDateTimes.Add(item.StartDate);
                compareDateTimes.Add(item.EndDate);
            }

            foreach(DateTime item in compareDateTimes) 
            {
                if(DateTime.Compare(item, viewModel.Reservation.EndDate) < 0 && DateTime.Compare(item, viewModel.Reservation.StartDate) > 0) 
                {
                    dateIncorrect = true;
                } else if (DateTime.Compare(item, viewModel.Reservation.EndDate) == 0 || DateTime.Compare(item, viewModel.Reservation.StartDate) == 0)
                {
                    dateIncorrect = true;
                }
            }

            if (dateIncorrect)
            {
                ModelState.AddModelError("EndDate", "Car is busy at this dates");
            }

            if (DateTime.Compare(viewModel.Reservation.EndDate, viewModel.Reservation.StartDate) < 0)
            {
                ModelState.AddModelError("EndDate", "End date is earlier than start date");
            }
            else if (DateTime.Compare(viewModel.Reservation.StartDate, DateTime.Now) < 0)
            {
                ModelState.AddModelError("StartDate", "Start date is earlier than now");
            }

            if (!ModelState.IsValid)
            {
                viewModel.Cars = cars.Collection();
                viewModel.Clients = clients.Collection();
                return View(viewModel);
            } 
            else
            {        
                 
                    context.Insert(viewModel.Reservation);
                    context.Commit();

                    return RedirectToAction("Index");
                
                    
            }
        }

        public ActionResult Edit(string Id)
        {
            ReservationViewModel reservation = new ReservationViewModel();
            reservation.Reservation = context.Find(Id);
            reservation.Cars = cars.Collection();
            reservation.Clients = clients.Collection();

            if (reservation.Reservation == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(reservation);
            }
        }
        [HttpPost]
        public ActionResult Edit(ReservationViewModel reservation, string Id)
        {
            ReservationViewModel reservationToEdit = new ReservationViewModel();
            reservationToEdit.Reservation = context.Find(Id);
            reservationToEdit.Cars = cars.Collection();
            reservationToEdit.Clients = clients.Collection();

            if (reservationToEdit.Reservation == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(reservationToEdit);
                }

                reservationToEdit.Reservation.CarID = reservation.Reservation.CarID;
                reservationToEdit.Reservation.CustomerID = reservation.Reservation.CustomerID;
                reservationToEdit.Reservation.CreatedAt = reservation.Reservation.CreatedAt;
                reservationToEdit.Reservation.CouponCode = reservation.Reservation.CouponCode;
                reservationToEdit.Reservation.EndDate = reservation.Reservation.EndDate;
                reservationToEdit.Reservation.StartDate = reservation.Reservation.StartDate;
                reservationToEdit.Reservation.ReservStatsID = reservation.Reservation.ReservStatsID;
                reservationToEdit.Reservation.Location = reservation.Reservation.Location;

                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {
            Reservation reservationToDelete = context.Find(Id);

            if (reservationToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(reservationToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Reservation reservationToDelete = context.Find(Id);

            if (reservationToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}