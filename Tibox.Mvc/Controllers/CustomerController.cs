using System;
using System.Web.Mvc;
using Tibox.Models;
using Tibox.Mvc.FilterActions;
using Tibox.UnitOfWork;

namespace Tibox.Mvc.Controllers
{
    [OutputCache(Duration = 0)]
    [ErrorHandler]
    [RoutePrefix("Customer")]
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
        [Route("List/{page:int}/{rows:int}")]
        public PartialViewResult List(int page, int rows)
        {
            var startRecord = (rows * (page - 1)) + 1;
            var endRecord = rows * page;            
            return PartialView(_unit.Customers.PagedList(startRecord, endRecord));
        }

        [Route("Count/{rows:int}")]
        public JsonResult Count(int rows)
        {
            var totalRecords = _unit.Customers.Count();
            var totalPages = totalRecords % rows != 0 ? (totalRecords / rows) + 1 : totalRecords / rows;
            var page = new
            {
                TotalRecords= totalRecords,
                TotalPages=totalPages
            };
            return Json(page, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Error()
        {
            throw new TimeZoneNotFoundException();            
        }

        private bool PageValidation(int page, int rows)
        {
            
            return false;
        }
    }
}