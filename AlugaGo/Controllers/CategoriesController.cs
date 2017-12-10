using AlugaGo.Models;
using AlugaGo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlugaGo.Controllers
{
    public class CategoriesController : Controller
    {
        
        private ApplicationDbContext _context;

        public CategoriesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Categories
        public ActionResult Index()
        {
            var category = _context.Categories.ToList();

            if (User.IsInRole("PodeGerenciarClientes"))
                return View(category);
            else
                return View("ReadOnlyIndex", category);
        }

        // GET: Cars/Detais/id
        public ActionResult Details(int Id)
        {
            var category = _context.Categories.SingleOrDefault(m => m.Id == Id);

            if (category == null)
                return HttpNotFound();

            if (User.IsInRole("PodeGerenciarClientes"))
                return View(category);
            else
                return View("ReadOnlyDetails", category);
        }

        [Authorize(Roles = "PodeGerenciarClientes")]
        public ActionResult New()
        {
            var category = _context.Categories.ToList();
            var viewModel = new CategoryFormViewModel
            {
                Category = new Category(),
            };

            return View("CategoryForm", viewModel);
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "PodeGerenciarClientes")]
        public ActionResult Edit(int id)
        {
            var category = _context.Categories.SingleOrDefault(c => c.Id == id);
            if (category == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CategoryFormViewModel
            {
                Category = category
            };

            return View("CategoryForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Category category)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CategoryFormViewModel
                {
                    Category = category
                };

                return View("CategoryForm", viewModel);
            }

            if (category.Id == 0)
            {
                _context.Categories.Add(category);
            }
            else
            {
                var carInDb = _context.Categories.Single(c => c.Id == category.Id);
                carInDb.Name = category.Name;
                carInDb.Price = category.Price;
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var category = _context.Categories.SingleOrDefault(c => c.Id == id);

            if (category == null)
                return HttpNotFound();

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return new HttpStatusCodeResult(200);
        }

    }
}
