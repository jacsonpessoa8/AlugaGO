using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlugaGo.Models;
using AlugaGo.ViewModels;

namespace AlugaGo.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Customer
        public ActionResult Index()
        {
            var customers = _context.Customers.ToList();

            return View(customers);
        }

        public ActionResult Details(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(m => m.Id == Id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult New()
        {
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer()
            };

            return View("CustomerForm", viewModel);
        }
        
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            var cust = customer;

            _context.Customers.Add(cust);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if(customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer ,

            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer

                };

                return View("CustomerForm", viewModel);
            }

            if(customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Cpf = customer.Cpf;
                customerInDb.Birthdate = customer.Birthdate;
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return new HttpStatusCodeResult(200);
        }
    }
}