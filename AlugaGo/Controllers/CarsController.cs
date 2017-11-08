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
            var carros = _context.Cars.ToList();

            return View(carros);
        }

        // GET: Cars/Detais/1
        public ActionResult Details(int Id)
        {
            var carro = _context.Cars.SingleOrDefault(m => m.Id == Id);

            if (carro == null)
                return HttpNotFound();

            return View(carro);
        }
    }
}