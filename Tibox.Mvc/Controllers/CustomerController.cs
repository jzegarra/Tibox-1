using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tibox.Models;
using Tibox.Mvc.FilterActions;
using Tibox.UnitOfWork;

namespace Tibox.Mvc.Controllers
{
    [OutputCache(Duration = 0)]
    [ErrorHandler]
    public class CustomerController : Controller
    {
        private readonly IUnitOfWork _unit;
        public CustomerController(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public ActionResult Index()
        {
            return View(_unit.Customers.GetAll());
        }
        public PartialViewResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid) return PartialView("Create", customer);
            var id = _unit.Customers.Insert(customer);
            return RedirectToAction("Index");
        }

        public PartialViewResult Edit(int id)
        {
            return PartialView(_unit.Customers.GetEntityById(id));
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (!ModelState.IsValid) return PartialView("Edit", customer);
            var id = _unit.Customers.Update(customer);
            return RedirectToAction("Index");
        }

        public PartialViewResult Delete(int id)
        {
            return PartialView(_unit.Customers.GetEntityById(id));
        }

        [HttpPost]
        public ActionResult Delete(Customer customer)
        {
            var id = _unit.Customers.Delete(customer);
            return RedirectToAction("Index");
        }

        public ActionResult Error()
        {
            throw new TimeZoneNotFoundException();            
        }
    }
}