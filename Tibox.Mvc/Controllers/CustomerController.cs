using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tibox.Models;
using Tibox.UnitOfWork;

namespace Tibox.Mvc.Controllers
{
    public class CustomerController : Controller
    {
        private readonly TiboxUnitOfWork _unit;
        public CustomerController()
        {
            _unit = new TiboxUnitOfWork();
        }
        public ActionResult Index()
        {
            return View(_unit.Customers.GetAll());
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var id = _unit.Customers.Insert(customer);
                if (id > 0) return RedirectToAction("Index");
            }
            return View();
        }
    }
}