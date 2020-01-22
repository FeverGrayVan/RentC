using RentC.Core.Contracts;
using RentC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentC.WebUI.Controllers
{
    public class CarController : Controller
    {
        IRepository<Car> context;

        public CarController(IRepository<Car> context)
        {
            this.context = context;
        }

        // GET: ProductManager
        public ActionResult Index()
        {
            List<Car> cars = context.Collection().ToList();
            return View(cars);
        }

        //public ActionResult Create()
        //{
        //    Reservation reservations = new Reservation();
        //    return View(reservations);
        //}

        public ActionResult Create()
        {
            Car car = new Car();
            return View(car);
        }

        [HttpPost]
        public ActionResult Create(Car car)
        {

            if (!ModelState.IsValid)
            {
                return View(car);
            }
            else
            {
                context.Insert(car);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            Car car = context.Find(Id);
            if (car == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(car);
            }
        }
        [HttpPost]
        public ActionResult Edit(Car car, string Id)
        {
            Car carToEdit = context.Find(Id);
            if (carToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(car);
                }

                carToEdit.Plate = car.Plate;
                carToEdit.Manufacturer = car.Manufacturer;
                carToEdit.Model = car.Model;
                carToEdit.PricePerDay = car.PricePerDay;

                context.Commit();
                return RedirectToAction("Index");

            }
        }

        public ActionResult Delete(string Id)
        {
            Car carToDelete = context.Find(Id);

            if (carToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(carToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Car carToDelete = context.Find(Id);

            if (carToDelete == null)
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