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
            List<Reservation> reservations = context.Collection().ToList();
            return View(reservations);
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
        public ActionResult Create(Reservation reservation)
        {
            if (!ModelState.IsValid)
            {
                return View(reservation);
            }
            else
            {
                context.Insert(reservation);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            Reservation reservation = context.Find(Id);
            if (reservation == null)
            {
                return HttpNotFound();

            }
            else
            {
                return View(reservation);
            }
        }
        [HttpPost]
        public ActionResult Edit(Reservation reservation, string Id)
        {
            Reservation reservationsToEdit = context.Find(Id);
            if (reservationsToEdit == null)
            {
                return HttpNotFound();

            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(reservation);
                }

                reservationsToEdit.CarID = reservation.CarID;
                reservationsToEdit.CustomerID = reservation.CustomerID;
                reservationsToEdit.CreatedAt = reservation.CreatedAt;
                reservationsToEdit.CouponCode = reservation.CouponCode;
                reservationsToEdit.EndDate = reservation.EndDate;
                reservationsToEdit.StartDate = reservation.StartDate;
                reservationsToEdit.ReservStatsID = reservation.ReservStatsID;
                reservationsToEdit.Location = reservation.Location;

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