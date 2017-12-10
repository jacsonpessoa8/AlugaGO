using AlugaGo.Models;
using AlugaGo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlugaGo.Controllers
{
    public class MotorcyclesController : Controller
    {
        private ApplicationDbContext _context;

        public MotorcyclesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Motorcycles
        public ActionResult Index()
        {
            var Motorcycle = _context.Motorcycles/**.Include(t => t.Category)*/.ToList();

            if (User.IsInRole("PodeGerenciarClientes"))
                return View(Motorcycle);
            else
                return View("ReadOnlyIndex", Motorcycle);
        }

        // GET: Cars/Detais/id
        public ActionResult Details(int Id)
        {
            var motorcycle = _context.Motorcycles.SingleOrDefault(m => m.Id == Id);

            if (motorcycle == null)
                return HttpNotFound();

            if (User.IsInRole("PodeGerenciarClientes"))
                return View(motorcycle);
            else
                return View("ReadOnlyDetails", motorcycle);
        }

        [Authorize(Roles = "PodeGerenciarClientes")]
        public ActionResult New()
        {
            var category = _context.Categories.ToList();
            var viewModel = new MotorcycleFormViewModel
            {
                Motorcycle = new Motorcycle(),
                Category = category
            };

            return View("MotorcycleForm", viewModel);
        }


        [HttpPost]
        public ActionResult Create(Motorcycle motocycle)
        {
            var autom = motocycle;

            _context.Motorcycles.Add(autom);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "PodeGerenciarClientes")]
        public ActionResult Edit(int id)
        {
            var motorcycle = _context.Motorcycles.SingleOrDefault(c => c.Id == id);
            if (motorcycle == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MotorcycleFormViewModel
            {
                Motorcycle = motorcycle,
                Category = _context.Categories.ToList()
            };

            return View("MotorcycleForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Motorcycle motorcycle)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MotorcycleFormViewModel
                {
                    Motorcycle = motorcycle,
                    Category = _context.Categories.ToList()
                };

                return View("MotorcycleForm", viewModel);
            }

            if (motorcycle.Id == 0)
            {
                _context.Motorcycles.Add(motorcycle);
            }
            else
            {
                var carInDb = _context.Motorcycles.Single(c => c.Id == motorcycle.Id);
                carInDb.Name = motorcycle.Name;
                carInDb.Fabricante = motorcycle.Fabricante;
                carInDb.CylinderCapacity = motorcycle.CylinderCapacity;
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var motorcycle = _context.Motorcycles.SingleOrDefault(c => c.Id == id);

            if (motorcycle == null)
                return HttpNotFound();

            _context.Motorcycles.Remove(motorcycle);
            _context.SaveChanges();

            return new HttpStatusCodeResult(200);
        }

    }
}