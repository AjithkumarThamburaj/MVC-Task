using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using mvctask111.Models;

namespace mvctask111.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeContext db = new EmployeeContext();
        // View
        public ActionResult Index()
        {
            return View(db.EmployeesTable.ToList());
        }
        //Details of the products

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Product Id Required");
            }
            var employee = db.EmployeesTable.Find(id);
            if (employee == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Product Not Found");
            }
            return View(employee);
        }
        //Create New product

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Create(int Id, string Name, int Age, string State, string Country)
        {
            try
            {
                var employee = new Employee();
                employee.Id = Id;
                employee.Name = Name;
                employee.Age = Age;
                employee.State = State;
                employee.Country = Country;
                db.EmployeesTable.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //update products in database
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Product Id Required");
            }
            var employee = db.EmployeesTable.Find(id);
            if (employee == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Product Not Found");
            }
            return View(employee);
        }
        [HttpPost]

        public ActionResult Edit(int id)
        {
            try
            {
                var employee = db.EmployeesTable.Find(id);
                UpdateModel(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Delete the database products
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Product Id Required");
            }
            var employee = db.EmployeesTable.Find(id);
            if (employee == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Product Not Found");
            }
            return View(employee);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {

            try
            {
                var employee = db.EmployeesTable.Find(id);
                db.EmployeesTable.Remove(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}