using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFCodeFirstDemo.Domain;
using EFCodeFirstDemo.RepositoryInterfaces;
using SSW.Framework.Data.Interfaces;

namespace EFCodeFirstDemo.WebUI.Controllers
{
    public class CustomerController : Controller
    {


        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerController(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }

        //
        // GET: /Customer/

        public ActionResult Index()
        {
            var customers = _customerRepository.Get().OrderBy(c => c.LastName);
            return View(customers);
        }

        //
        // GET: /Customer/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Customer/Create

        public ActionResult Create()
        {
            var newCustomer = new Customer();
            return View(newCustomer);
        }

        //
        // POST: /Customer/Create

        [HttpPost]
        public ActionResult Create(Customer model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _customerRepository.Add(model);
                    _unitOfWork.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View();
        }

        //
        // GET: /Customer/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Customer/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Customer/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Customer/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
