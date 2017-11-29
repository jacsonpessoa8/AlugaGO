using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlugaGo.Models;
using AlugaGo.ViewModels;

namespace AlugaGo.Controllers
{
    public class CarsController : Controller
    {
        private ApplicationDbContext _context;

        public CarsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Cars
        public ActionResult Index()
        {   
            var cars = _context.Cars.ToList();

            if (User.IsInRole("PodeGerenciarClientes"))
                return View(cars);
            else
                return View("ReadOnlyIndex", cars);
        }

        // GET: Cars/Detais/id
        public ActionResult Details(int Id)
        {
            var cars = _context.Customers.SingleOrDefault(m => m.Id == Id);

            if (cars == null)
                return HttpNotFound();

            if (User.IsInRole("PodeGerenciarClientes"))
                return View(cars);
            else
                return View("ReadOnlyDetails", cars);
        }

        [Authorize(Roles = "PodeGerenciarClientes")]
        public ActionResult New()
        {
            var viewModel = new CarFormViewModel
            {
                Car = new Car()
            };

            return View("CarForm", viewModel);
        }
        // ready

        [HttpPost]
        public ActionResult Create(Car car)
        {
            var autom = car;

            _context.Cars.Add(autom);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "PodeGerenciarClientes")]
        public ActionResult Edit(int id)
        {
            var car = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (car == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel
            {
                Customer = car,

            };

            return View("CarForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Car car)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CarFormViewModel
                {
                    Car = car

                };

                return View("CarForm", viewModel);
            }

            if (car.Id == 0)
            {
                _context.Cars.Add(car);
            }
            else
            {
                var carInDb = _context.Cars.Single(c => c.Id == car.Id);
                carInDb.Name = car.Name;
                carInDb.Fabricante = car.Fabricante;
                carInDb.Door = car.Door;
                carInDb.Direction = car.Direction;
                carInDb.Air = car.Air;
                carInDb.EletricWindows = car.EletricWindows;
                carInDb.SoundSystem = car.SoundSystem;
                carInDb.Lock = car.Lock;
                carInDb.Alarm = car.Alarm;
                carInDb.Airbag = car.Airbag;
                carInDb.ABS = car.ABS;
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var car = _context.Cars.SingleOrDefault(c => c.Id == id);

            if (car == null)
                return HttpNotFound();

            _context.Cars.Remove(car);
            _context.SaveChanges();

            return new HttpStatusCodeResult(200);
        }

    }
}